using BCrypt.Net;
using Models.Entities;
using Shared.Constants;
using Shared.Request;
using WebsOne.Api.Contracts;
using WebsOne.Api.Databases;

namespace WebsOne.Api.Repositories
{
    public class AuthRepository: RepositoryBase<User>, IAuthRepository
    {
        public AuthRepository(SqlServerContext context) : base(context) { }
        
        public async Task LoginLogic(LoginRequest request)
        {
            //1. cek ke table user
            var userDb = await FindOneByCondition(x => x.UserName == request.UserName);
            //1.1. cek user ada atau tidak
            if (userDb is null)
            {
                var message = "User with user name: " + request.UserName + " " + MessageConstants.NotFound;
                throw new KeyNotFoundException(message);
            }
            //1.2. cek password benar atau salah
            if (!BCrypt.Net.BCrypt.Verify(request.Password, userDb.Password))
            {
                throw new KeyNotFoundException(MessageConstants.WrongPassword);
            }

            //2. generate token
        }
    }
}
