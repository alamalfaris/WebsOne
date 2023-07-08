using Models.Entities;
using Shared.Constants;
using Shared.Request;
using Shared.Responses;
using WebsOne.Api.Contracts;
using WebsOne.Api.Databases;
using WebsOne.Api.Helpers;

namespace WebsOne.Api.Repositories
{
    public class AuthRepository: RepositoryBase<User>, IAuthRepository
    {
        private readonly IJwtHelper _jwtHelper;

        public AuthRepository(SqlServerContext context, IJwtHelper jwtHelper) : base(context)
        {
            _jwtHelper = jwtHelper;
        }

        public async Task<LoginResponse> LoginLogic(LoginRequest request)
        {
            string message = string.Empty;

            //1. cek ke table user
            var userDb = await FindOneByCondition(x => x.UserName == request.UserName);
            //1.1. cek user ada atau tidak
            if (userDb is null)
            {
                message = "User with user name: " + request.UserName + " " + MessageConstants.NotFound;
                throw new BadRequestException(message);
            }
            //1.2. cek password benar atau salah
            if (!BCrypt.Net.BCrypt.Verify(request.Password, userDb.Password))
            {
                message = MessageConstants.Wrong + " " + "Username!";
                throw new BadRequestException(message);
            }

            //2. generate token
            var token = _jwtHelper.GenerateToken(userDb);

            var loginResponse = new LoginResponse() { Token = token, UserName = request.UserName };
            return loginResponse;
        }
    }
}
