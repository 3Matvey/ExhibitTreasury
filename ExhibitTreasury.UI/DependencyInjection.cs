using ExhibitTreasury.UI.Pages;
using ExhibitTreasury.UI.ViewModels;

namespace ExhibitTreasury.UI
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterPages(this IServiceCollection services)
        {
            services.AddTransient<HallsPage>();
            return services;
        }

        public static IServiceCollection RegisterViewModels(this IServiceCollection services)
        {
            services.AddTransient<HallsViewModel>();
            return services;
        }
    }
}
