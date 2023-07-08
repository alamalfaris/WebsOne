using Models.Entities;
using Shared.Request;
using Shared.Responses;

namespace WebsOne.Api.Contracts
{
    public interface IAuthRepository : IRepositoryBase<User>
    {
        Task<LoginResponse> LoginLogic(LoginRequest request);
    }
}
