using Models.Entities;

namespace WebsOne.Api.Contracts
{
    public interface IJwtHelper
    {
        string GenerateToken(User user);
    }
}
