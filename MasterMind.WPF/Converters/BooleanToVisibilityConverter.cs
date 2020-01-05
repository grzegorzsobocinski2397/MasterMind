using System;
using System.Globalization;
using System.Windows;

namespace MasterMind.WPF
{
    /// <summary>
    /// Value converter that converts bool into a Visibility value.
    /// </summary>
    public class BooleanToVisibilityConverter : BaseValueConverter<BooleanToVisibilityConverter>
    {
        /// <summary>
        /// Converts from boolean value to visibility.
        /// </summary>
        /// <param name="value">This is the boolean value.</param>
        /// <returns>Visibility value.</returns>
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value == false)
                return Visibility.Hidden;
            else if ((bool)value == true)
                return Visibility.Visible;
            else
                return null;
        }

        /// <summary>
        /// Backwards conversion which is not implemented.
        /// </summary>
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}