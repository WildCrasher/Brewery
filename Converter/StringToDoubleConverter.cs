using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Microsoft.VisualBasic;

namespace Converter
{
    public class StringToDoubleConverter : IValueConverter
    {
        public double EmptyStringValue { get; set; } = 0;

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is string)
            {
                string s = (string)value;
                if (Information.IsNumeric(s))
                    return System.Convert.ToDouble(s);
                else
                    return EmptyStringValue;
            }
            return value;
        }
    }
}
