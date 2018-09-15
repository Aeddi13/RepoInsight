using Avalonia.Markup;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace RepoInsight.Avalonia.View
{
    public class MathOperationConverter : IValueConverter
    {
        public string Operator { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double doubleValue = (double)value;
            double doubleParameter = (double)parameter;

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
