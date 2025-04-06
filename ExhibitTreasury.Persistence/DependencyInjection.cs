using ExhibitTreasury.Persistence.Data;
using ExhibitTreasury.Persistence.Fakes;
using ExhibitTreasury.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ExhibitTreasury.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddSingleton<IUnitOfWork, FakeUnitOfWork>();
            return services;
        }

        public static IServiceCollection AddPersistence(this IServiceCollection services, DbContextOptions<AppDbContext> options)
        {
            services.AddSingleton<AppDbContext>(new AppDbContext(options));
            services.AddSingleton<IUnitOfWork, EfUnitOfWork>();
            return services;
        }
    }
}
