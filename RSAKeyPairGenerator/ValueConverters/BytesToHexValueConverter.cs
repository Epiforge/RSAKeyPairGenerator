﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace RSAKeyPairGenerator.ValueConverters
{
    public class BytesToHexValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
            value is IReadOnlyCollection<byte> bytes ? Utilities.ConvertToHex(bytes) : Binding.DoNothing;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            Binding.DoNothing;
    }
}
