using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace RSAKeyPairGenerator.ValueConverters
{
    public class EqualityToVisibilityValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
            value.Equals(parameter) ? Visibility.Visible : Visibility.Collapsed;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            Binding.DoNothing;
    }
}
