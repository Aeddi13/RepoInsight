using Avalonia;
using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace RepoInsight.Avalonia.View.Converter
{
    /// <summary>
    /// Converts a double value to a <see cref="Thickness"/> value.
    /// </summary>
    public class DoubleToThicknessConverter : IValueConverter
    {
        /// <summary>
        /// Gets or sets the multiplier for the double value.
        /// </summary>
        public double Multiplier { get; set; } = 1;

        /// <inheritdoc/>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double doubleValue = System.Convert.ToDouble(value);

            return new Thickness(doubleValue * Multiplier);
        }

        /// <inheritdoc/>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
