using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using ExhibitTreasury.Application;
using ExhibitTreasury.Persistence;

namespace ExhibitTreasury.UI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services
                .AddApplication()       // Регистрация MediatR и обработчиков запросов
                .AddPersistence()       // Регистрируем FakeUnitOfWork
                .RegisterPages()        // Регистрируем страницы (например, HallsPage)
                .RegisterViewModels();  // Регистрируем ViewModel, включая HallsViewModel
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
