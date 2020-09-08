using System;
using System.Globalization;
using System.Windows.Data;

namespace Base64Convertor
{
    class FromBaseConvert:IValueConverter
    {
        /// <summary>
        /// Return Decoded text From encoded base64 string
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var encoding = EncodingsStatic.CurrentEncoding;
            try
            {
                return encoding.GetString(System.Convert.FromBase64String(value as string ?? string.Empty));
            }
            catch (Exception e)
            {
                return e.Message;
            }
            //return "The Input Is Not a Base64 String";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
