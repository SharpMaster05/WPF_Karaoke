using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Karaoke.Helpers
{
    class TimeSpanToDoubleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is TimeSpan time)
            {
                return time.TotalSeconds;
            }
            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is double time)
            {
                return TimeSpan.FromSeconds(time);
            }
            return TimeSpan.Zero;
        }
    }
}
