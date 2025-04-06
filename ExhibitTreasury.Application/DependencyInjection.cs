using Microsoft.Extensions.DependencyInjection;

namespace ExhibitTreasury.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(conf =>
            {
                conf.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            });
            return services;
        }
    }
}
