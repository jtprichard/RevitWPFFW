using System;
using System.Globalization;
using System.Windows.Data;
using RevitWPFFW.core;

namespace RevitWPFFW.ui
{
    public class MainPageValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((PageType)value)
            {
                case PageType.Page1:
                    return new Page1();
                case PageType.Page2:
                    return new Page2();
                case PageType.Page3:
                    return new Page3();
                default:
                    return new Page1();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
