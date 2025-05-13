namespace ExhibitTreasury.UI.Services
{
    public static class FileStorageService
    {
        /// <summary>
        /// Сохраняет выбранное изображение в папке Images с именем {exhibitId}.jpg.
        /// </summary>
        /// <param name="exhibitId">ID экспоната.</param>
        /// <param name="photo">Результат выбора файла изображения.</param>
        /// <returns>Полный путь к сохранённому файлу.</returns>
        public static async Task<string> SaveExhibitImageAsync(int exhibitId, FileResult photo)
        {
            // Определяем путь к папке Images во внутренней директории приложения
            var imagesFolder = Path.Combine(FileSystem.AppDataDirectory, "Images");
            if (!Directory.Exists(imagesFolder))
            {
                Directory.CreateDirectory(imagesFolder);
            }

            // Формируем имя файла по Id экспоната
            var fileName = $"{exhibitId}.jpg"; // или .png в зависимости от формата
            var filePath = Path.Combine(imagesFolder, fileName);

            using Stream sourceStream = await photo.OpenReadAsync();
            using FileStream targetStream = File.Create(filePath);
            await sourceStream.CopyToAsync(targetStream);
            return filePath;
        }

        /// <summary>
        /// Возвращает путь к изображению для указанного Id, если файл существует, иначе null.
        /// </summary>
        public static string? GetExhibitImagePath(int exhibitId)
        {
            var imagesFolder = Path.Combine(FileSystem.AppDataDirectory, "Images");
            var filePath = Path.Combine(imagesFolder, $"{exhibitId}.jpg");
            return File.Exists(filePath) ? filePath : null;
        }
    }
}
