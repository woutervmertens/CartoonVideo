using System;
using System.Globalization;
using System.Windows.Data;

namespace CartoonVideo.Utils
{
    public class ColorToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            System.Drawing.Color col = (System.Drawing.Color)value;
            System.Windows.Media.Color c = System.Windows.Media.Color.FromArgb(col.A, col.R, col.G, col.B);
            return new System.Windows.Media.SolidColorBrush(c);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            System.Windows.Media.SolidColorBrush c = (System.Windows.Media.SolidColorBrush)value;
            System.Drawing.Color col = System.Drawing.Color.FromArgb(c.Color.A, c.Color.R, c.Color.G, c.Color.B);
            return col;
        }
    }
}
