using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Core;

namespace Converter
{
    public class StringToRaceConverter : IValueConverter
    {
        private bool Check(string value)
        {
            return Enum.IsDefined(typeof(Race), value);
        }
       
        public Race EmptyStringValue { get; set; } = Race.Ale;

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is string)
            {
                string s = (string)value;
                if (Check(s))
                {
                    Race converted = (Race)Enum.Parse(typeof(Race), s, true);

                    return converted;
                }
                else
                    return EmptyStringValue;
            }
            return value;
        }

    }
}
