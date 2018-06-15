using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Converter
{
    public class StringToDateTimeConverter : IValueConverter
    {

        public DateTime EmptyStringValue { get; set; } = DateTime.Now;

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is string)
            {
                string s = (string)value;
                DateTime tempDate;
                if (DateTime.TryParse(s, out tempDate))
                {
                    DateTime converted = DateTime.Parse(s);

                    return converted;
                }
                else
                    return EmptyStringValue;
            }
            return value;
        }
    }
}
