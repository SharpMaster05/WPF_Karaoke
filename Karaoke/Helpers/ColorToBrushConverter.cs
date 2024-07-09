﻿using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Karaoke.Helpers;

internal class ColorToBrushConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is System.Windows.Media.Color color) 
        {
            return new SolidColorBrush(color);       
        }
        return Brushes.Transparent;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is SolidColorBrush brush)
        {
            return brush.Color;
        }
        return Colors.Black;
    }
}