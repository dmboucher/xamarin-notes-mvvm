using System;
using System.Globalization;
using Xamarin.Forms;

namespace notes
{
    // TODO:  Seems odd to have to do this.  Is there a better way to have dynamic binding values?
    public class ValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            if (!int.TryParse(value.ToString(), out int intValue))
                return value;

            return intValue == 1 ? "Not Null" : "Null";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException("Not implemented.");
        }
    }
}
