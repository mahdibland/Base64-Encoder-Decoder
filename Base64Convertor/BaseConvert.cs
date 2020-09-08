using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Base64Convertor
{
    class BaseConvert:IValueConverter
    {
        /// <summary>
        /// return Encoded base 64 string from a text
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var encoding = parameter as Encoding;
                return System.Convert.ToBase64String(encoding.GetBytes(value as string));
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
