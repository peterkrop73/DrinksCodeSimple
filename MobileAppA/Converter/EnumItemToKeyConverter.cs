using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using MobileAppA.ViewModel;
using Xamarin.Forms;

namespace MobileAppA.Converter
{
    public class EnumItemToKeyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is EnumItemViewModel enumItem)
                return enumItem.Key;

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
