using System;
using System.Globalization;
using System.Windows.Data;
using PB.RevitWPFFW.core;

namespace PB.RevitWPFFW.ui
{
    /// <summary>
    /// Value Converter for Main WPF Page Navigation
    /// Adjust Page Enumerations to Match Page XMAL documents
    /// </summary>
    public class MainPageValueConverter : IValueConverter
    {
        /// <summary>
        /// Converter
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((PageType)value)
            {
                case PageType.Page1:
                    return new Page1();
                case PageType.Page2:
                    return new Page2();
                case PageType.Page3:
                    return new PropertiesPage();
                case PageType.Page4:
                    return new Page4();
                default:
                    return new Page1();
            }
        }

        /// <summary>
        /// Convert Back - Unused
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
