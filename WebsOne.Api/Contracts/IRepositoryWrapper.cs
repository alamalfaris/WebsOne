namespace WebsOne.Api.Contracts
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        IAuthRepository Auth { get; }
    }
}
