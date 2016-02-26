using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoL_Helper
{
    public static class Extensions
    {
        public static Point Add(this Point p1, Point p2)
        {
            return new Point(p1.X + p2.X, p1.Y + p2.Y);
        }
        public static Point Add(this Point p1, int x, int y)
        {
            return new Point(p1.X + x, p1.Y + y);
        }

        public static Point Substract(this Point p1, Point p2)
        {
            return new Point(p1.X - p2.X, p1.Y - p2.Y);
        }
        public static Point Substract(this Point p1, int x, int y)
        {
            return new Point(p1.X - x, p1.Y - y);
        }

        public static Color Brighten(this Color clr, byte c)
        {
            byte r = (byte)(clr.R + c > 255 ? 255 : clr.R + c);
            byte g = (byte)(clr.G + c > 255 ? 255 : clr.G + c);
            byte b = (byte)(clr.B + c > 255 ? 255 : clr.B + c);
            return Color.FromArgb(r, g, b);
        }

        public static Color Darken(this Color clr, byte c)
        {
            byte r = (byte)(clr.R - c < 0 ? 0 : clr.R - c);
            byte g = (byte)(clr.G - c < 0 ? 0 : clr.G - c);
            byte b = (byte)(clr.B - c < 0 ? 0 : clr.B - c);
            return Color.FromArgb(r, g, b);
        }
    }
}
