using MasterMind.WPF.Models;
using MasterMind.WPF.Pages;
using System;
using System.Diagnostics;
using System.Globalization;

namespace MasterMind.WPF
{
    /// <summary>
    /// Converts the ENUM values to XAML pages.
    /// </summary>
    public class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
    {
        /// <summary>
        /// Converts from <see cref="ApplicationPage"/> to WPF Page.
        /// </summary>
        /// <param name="value">This is the <see cref="ApplicationPage"/> enum.</param>
        /// <returns>WPF page.</returns>
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((ApplicationPage)value)
            {
                case ApplicationPage.Start:
                    return new StartPage();

                case ApplicationPage.Game:
                    return new GamePage();

                default:
                    Debugger.Break();
                    return null;
            };
        }

        /// <summary>
        /// Backwards convertion which is not implemented.
        /// </summary>
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}