using System.Globalization;

namespace ExhibitTreasury.UI.ValueConverters
{
    public class AppraisedValueToColorConverter : IValueConverter
    {
        // подобрать цвета
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is decimal appraisedValue)
            {
                return appraisedValue switch
                {
                    < 100000m => Colors.LightPink,
                    >= 100000m and < 500000m => Colors.LightYellow,
                    >= 500000m and < 1000000m => Colors.LightGreen,
                    _ => Colors.Aquamarine,
                };
            }
            return Colors.WhiteSmoke;
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
