using Microsoft.Extensions.DependencyInjection;

namespace ThingsSales.Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            return services;
        }
    }
}
