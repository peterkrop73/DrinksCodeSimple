using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using MobileAppA.ViewModel;
using Xamarin.Forms;

namespace MobileAppA.Converter
{
    public class EnumItemToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is EnumItemViewModel;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
