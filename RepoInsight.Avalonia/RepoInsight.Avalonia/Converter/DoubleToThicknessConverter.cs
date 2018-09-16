using Avalonia;
using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace RepoInsight.Avalonia.View.Converter
{
    public class DoubleToThicknessConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double doubleValue = System.Convert.ToDouble(value);

            return new Thickness(doubleValue);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
