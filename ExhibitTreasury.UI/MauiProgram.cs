using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using ExhibitTreasury.Application;
using ExhibitTreasury.Persistence;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using ExhibitTreasury.Persistence.Data;

namespace ExhibitTreasury.UI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            string settingsStream = "ExhibitTreasury.UI.appsettings.json";

            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            var a = Assembly.GetExecutingAssembly();
            using var stream = a.GetManifestResourceStream(settingsStream);

            builder.Configuration.AddJsonStream(stream!);

            var connStr = builder.Configuration
                          .GetConnectionString("SqliteConnection");
            string dataDirectory = FileSystem.Current.AppDataDirectory + "/";

            connStr = string.Format(connStr!, dataDirectory);

            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite(connStr)
                .Options;

#region DI
            builder.Services
                .AddApplication()       // Регистрация MediatR и обработчиков запросов
                .AddPersistence(options)       // Регистрируем FakeUnitOfWork
                .RegisterPages()        // Регистрируем страницы (например, HallsPage)
                .RegisterViewModels();  // Регистрируем ViewModel, включая HallsViewModel
#endregion

           

            DbInitializer
                .Initialize(builder.Services.BuildServiceProvider())
                .Wait();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
