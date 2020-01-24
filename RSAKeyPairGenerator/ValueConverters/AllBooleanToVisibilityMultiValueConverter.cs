using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace RSAKeyPairGenerator.ValueConverters
{
    public class AllBooleanToVisibilityMultiValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) =>
            (values?.All(value => value is bool boolean && boolean) ?? true) ? Visibility.Visible : Visibility.Collapsed;

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) =>
            new object[] { DependencyProperty.UnsetValue };
    }
}
