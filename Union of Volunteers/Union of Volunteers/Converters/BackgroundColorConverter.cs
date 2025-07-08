using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using Union_of_Volunteers.Models;

namespace Union_of_Volunteers.Converters
{
    class BackgroundColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            string color = BackgroundColor.GetColor;
            return new SolidColorBrush((Color)System.Windows.Media.ColorConverter.ConvertFromString(color));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
