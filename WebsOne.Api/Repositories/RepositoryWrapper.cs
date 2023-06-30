using WebsOne.Api.Contracts;
using WebsOne.Api.Databases;

namespace WebsOne.Api.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly SqlServerContext _context;
        private IUserRepository? _userRepository;
        private IAuthRepository? _authRepository;

        public RepositoryWrapper(SqlServerContext context)
        {
            _context = context;
        }

        public IUserRepository User
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_context);
                }
                return _userRepository;
            }
        }

        public IAuthRepository Auth
        {
            get
            {
                if (_authRepository == null)
                {
                    _authRepository = new AuthRepository(_context);
                }
                return _authRepository;
            }
        }
    }
}
