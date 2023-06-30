using Models.Entities;
using WebsOne.Api.Contracts;
using WebsOne.Api.Databases;

namespace WebsOne.Api.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(SqlServerContext context) : base(context) { }
        
    }
}
