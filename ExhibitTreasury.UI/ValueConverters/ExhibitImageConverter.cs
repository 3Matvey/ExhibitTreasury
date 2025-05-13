using System.Globalization;

namespace ExhibitTreasury.UI.ValueConverters
{
    public class ExhibitImageConverter : IValueConverter
    {
        // Если файл <AppData>/Images/{Id}.jpg есть – возвращаем его, иначе placeholder
        public object Convert(object? value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int id)
            {
                var imagesDir = Path.Combine(FileSystem.AppDataDirectory, "Images");
                var file = Path.Combine(imagesDir, $"{id}.jpg");
                if (File.Exists(file))
                    return ImageSource.FromFile(file);
            }
            // Положите в Resources/Images файл placeholder.jpg (BuildAction = MauiImage)
            return ImageSource.FromFile("placeholder.jpg");
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
            => throw new NotSupportedException();
    }
}
