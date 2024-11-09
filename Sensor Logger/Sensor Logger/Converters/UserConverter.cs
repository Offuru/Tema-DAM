using Sensor_Logger.Models;
using System.Globalization;

namespace Sensor_Logger.Converters
{
    public class UserConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length == 2)
            {
                return new User
                {
                    Username = values[0]?.ToString(),
                    Password = values[1]?.ToString()
                };
            }
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
