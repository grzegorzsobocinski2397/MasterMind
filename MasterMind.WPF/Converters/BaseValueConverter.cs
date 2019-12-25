using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace MasterMind.WPF
{
    public abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter
        where T : class, new()
    {
        #region Private Members

        /// <summary>
        /// A single static instance of this value converter
        /// </summary>

        private static T converter = null;

        #endregion Private Members

        #region Public Properties

        /// <summary>
        /// Provides a static instance of the value converter
        /// </summary>
        /// <param name="serviceProvider">The service provider</param>
        /// <returns></returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return converter ?? (converter = new T());
        }

        #endregion Public Properties

        #region Value converter methods

        /// <summary>
        /// The method to convert one type to another
        /// </summary>
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        /// <summary>
        /// The method to convert a value back
        /// </summary>
        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);

        #endregion Value converter methods
    }
}