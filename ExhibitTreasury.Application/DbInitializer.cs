using Microsoft.Extensions.DependencyInjection;

namespace ExhibitTreasury.Application
{
    public static class DbInitializer
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            // Получаем IUnitOfWork из DI
            var unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();

            // Удаляем и создаём базу данных заново
            await unitOfWork.DeleteDataBaseAsync();
            await unitOfWork.CreateDataBaseAsync();

            // Создаём несколько залов музея
            var hall1 = new Hall
            {
                Name = "Ancient Art",
                Description = "Artifacts from ancient civilizations"
            };

            var hall2 = new Hall
            {
                Name = "Modern Art",
                Description = "Modern masterpieces"
            };

            // Добавляем залы в репозиторий
            await unitOfWork.HallRepository.AddAsync(hall1);
            await unitOfWork.HallRepository.AddAsync(hall2);

            // Сохраняем изменения, чтобы получить присвоенные Id
            await unitOfWork.SaveAllAsync();

            // Создаём экспонаты, используя HallId из созданных залов
            var exhibit1 = new Exhibit
            {
                Name = "Statue of Zeus",
                AppraisedValue = 150000m,
                YearCreated = -450, // пример: год до нашей эры
                Material = "Marble",
                Artist = "Unknown",
                HallId = hall1.Id
            };

            var exhibit2 = new Exhibit
            {
                Name = "Mona Lisa",
                AppraisedValue = 850000000m,
                YearCreated = 1503,
                Material = "Oil on poplar",
                Artist = "Leonardo da Vinci",
                HallId = hall2.Id
            };

            // Добавляем экспонаты в репозиторий
            await unitOfWork.ExhibitRepository.AddAsync(exhibit1);
            await unitOfWork.ExhibitRepository.AddAsync(exhibit2);

            // Сохраняем все изменения
            await unitOfWork.SaveAllAsync();
        }
    }
}
