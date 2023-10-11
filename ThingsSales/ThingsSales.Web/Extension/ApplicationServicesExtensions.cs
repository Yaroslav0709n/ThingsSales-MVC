using ThingsSales.Data.Repositories;
using ThingsSales.Data.Repositories.IRepository;
using ThingsSales.Service.IService;
using ThingsSales.Service.Service;

namespace ThingsSales.Web.Extension
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IItemRepository, ItemRepository>();

            return services;
        }
    }
}
