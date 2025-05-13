using System.Globalization;
using ExhibitTreasury.UI.Services;

namespace ExhibitTreasury.UI.ValueConverters
{
    public class ExhibitIdToImageSourceConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is int exhibitId)
            {
                var path = FileStorageService.GetExhibitImagePath(exhibitId);
                if (!string.IsNullOrEmpty(path))
                {
                    // Если файл существует, возвращаем ImageSource из файла
                    return ImageSource.FromFile(path);
                }
            }
            // Если файл не найден, возвращаем placeholder
            return "placeholder.png";
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}
