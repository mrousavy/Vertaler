using System;
using System.Globalization;
using System.Windows.Data;

namespace Vertaler.Implementation
{
    [ValueConversion(typeof(double), typeof(double), ParameterType = typeof(double))]
    public class AdditionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool parsed = double.TryParse(parameter?.ToString(), out double operand);

            switch (value)
            {
                case double d:
                    return parsed ? d + operand : d;
                case int i:
                    return parsed ? i + operand : i;
                default:
                    return value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool parsed = double.TryParse(parameter?.ToString(), out double operand);

            switch (value)
            {
                case double d:
                    return parsed ? d + operand : d;
                case int i:
                    return parsed ? i + operand : i;
                default:
                    return value;
            }
        }
    }
}
