using Microsoft.Extensions.DependencyInjection;
using ExhibitTreasury.UI.Pages;
using ExhibitTreasury.UI.ViewModels;

namespace ExhibitTreasury.UI
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterPages(this IServiceCollection services)
        {
            services.AddTransient<HallsPage>();
            services.AddTransient<ExhibitDetailsPage>();
            return services;
        }

        public static IServiceCollection RegisterViewModels(this IServiceCollection services)
        {
            services.AddTransient<HallsViewModel>();
            services.AddTransient<ExhibitDetailsViewModel>();
            return services;
        }
    }
}
