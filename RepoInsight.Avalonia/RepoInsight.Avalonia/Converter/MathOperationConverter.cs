﻿using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace RepoInsight.Avalonia.View.Converter
{
    public class MathOperationConverter : IValueConverter
    {
        public string Operator { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double doubleValue = System.Convert.ToDouble(value);
            double doubleParameter = System.Convert.ToDouble(parameter);

            if (Operator.Equals("/"))
            {
                return doubleValue / doubleParameter;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
