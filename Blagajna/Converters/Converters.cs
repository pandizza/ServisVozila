using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ServisVozila.Converters
{
    public class VisibilityConverters : IValueConverter
    {
        public enum Mode
        {
            NullToVisible,
            NullToCollapsed,
            GreaterThanZero
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var mode = parameter?.ToString();

            return mode switch
            {
                "NullToVisible" => value == null ? Visibility.Visible : Visibility.Collapsed,
                "NullToCollapsed" => value == null ? Visibility.Collapsed : Visibility.Visible,
                "GreaterThanZero" => value is int i && i > 0 ? Visibility.Visible : Visibility.Collapsed,
                _ => Visibility.Collapsed
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
