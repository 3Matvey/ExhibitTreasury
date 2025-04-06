using Microsoft.Extensions.DependencyInjection;
using ExhibitTreasury.Application.HallUseCases.Queries; // Здесь должен быть ваш обработчик

namespace ExhibitTreasury.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Используем тип одного из обработчиков, чтобы точно указать нужную сборку
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblyContaining<GetAllHallsQueryHandler>();
            });
            return services;
        }
    }
}
