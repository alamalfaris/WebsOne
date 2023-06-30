using WebsOne.Api.Contracts;
using WebsOne.Api.Repositories;

namespace WebsOne.Api.Helpers
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepository(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
