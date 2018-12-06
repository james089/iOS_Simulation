using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace iOS_Simulation.Main
{
    struct mBrushes
    {
        public static Brush White = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
        public static Brush Green = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF00CD00"));
        public static Brush Black = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF000000"));
        public static Brush Blue = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF00A3FF"));
        public static Brush SuperTransGray = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4C303030"));
        public static Brush Transparent = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00000000"));
    }

    class Colors
    {
    }
}
