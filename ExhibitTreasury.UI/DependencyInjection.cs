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
            services.AddTransient<CreateHallPage>();
            services.AddTransient<CreateExhibitPage>();
            services.AddTransient<EditExhibitPage>();
            services.AddTransient<MoveExhibitPage>();

            return services;
        }

        public static IServiceCollection RegisterViewModels(this IServiceCollection services)
        {
            services.AddTransient<HallsViewModel>();
            services.AddTransient<ExhibitDetailsViewModel>();
            services.AddTransient<CreateHallViewModel>();
            services.AddTransient<CreateExhibitViewModel>();
            services.AddTransient<EditExhibitViewModel>();
            services.AddTransient<MoveExhibitViewModel>();
            return services;
        }
    }
}
