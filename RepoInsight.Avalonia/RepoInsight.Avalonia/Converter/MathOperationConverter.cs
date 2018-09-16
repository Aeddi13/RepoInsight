using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace RepoInsight.Avalonia.View.Converter
{
    /// <summary>
    /// Performs a simple math operation on a value that can be converted to <see cref="double"/>.
    /// </summary>
    public class MathOperationConverter : IValueConverter
    {
        /// <summary>
        /// Gets or sets the operator for the math operation.
        /// Allowed values:
        /// "+" Addition
        /// "-" Substraction
        /// "*" Multiplication
        /// "/" Division
        /// </summary>
        public string Operator { get; set; } = "+";

        /// <inheritdoc/>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double doubleValue = System.Convert.ToDouble(value);
            double doubleParameter = System.Convert.ToDouble(parameter);
            double? returnValue = null;
            
            switch (Operator)
            {
                case "+":
                    returnValue = doubleValue + doubleParameter;
                    break;
                case "-":
                    returnValue = doubleValue - doubleParameter;
                    break;
                case "*":
                    returnValue = doubleValue * doubleParameter;
                    break;
                case "/":
                    returnValue = doubleValue / doubleParameter;
                    break;
            }
            
            return returnValue;
        }

        /// <inheritdoc/>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
