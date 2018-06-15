using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Core;

namespace Converter
{
    public class StringToSpecialityConverter : IValueConverter
    {
        private bool Check(string value)
        {
            return Enum.IsDefined(typeof(Speciality), value);
        }

        public Speciality EmptyStringValue { get; set; } = Speciality.Barrel_Aged;

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
                    Speciality converted = (Speciality)Enum.Parse(typeof(Speciality), s, true);

                    return converted;
                }
                else
                    return EmptyStringValue;
            }
            return value;
        }
    }
}
