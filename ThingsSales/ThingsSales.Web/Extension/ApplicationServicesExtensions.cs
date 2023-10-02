using ThingsSales.Data.Repositories;
using ThingsSales.Data.Repositories.IRepository;

namespace ThingsSales.Web.Extension
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddScoped<ITokenRepository, TokenRepository>();
 
            return services;
        }
    }
}
