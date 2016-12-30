using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace ReporteFacturasXmlSAT.Converters
{
    public class BooleanToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is Boolean && (bool)value)
            {
                return new SolidColorBrush(Colors.SeaGreen);
            }

            return new SolidColorBrush(Colors.Transparent);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is Visibility && (Visibility)value == Visibility.Visible)
            {
                return new SolidColorBrush(Colors.DarkRed);
            }

            return new SolidColorBrush(Colors.Transparent);
        }
    }
}