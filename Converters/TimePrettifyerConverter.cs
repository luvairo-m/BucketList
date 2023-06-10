using System.Globalization;

namespace BucketList.Converters
{
    class TimePrettifyerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => $"{(DateTime)value:t}";

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) 
            => throw new NotImplementedException();
    }
}