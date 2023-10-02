using ThingsSales.Data.Repositories;
using ThingsSales.Data.Repositories.IRepository;
using ThingsSales.Service;
using ThingsSales.Service.IService;

namespace ThingsSales.Web.Extension
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
