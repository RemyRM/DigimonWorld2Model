using System.Drawing;

namespace DW2ModelParser.Utilities
{
    internal class Maths
    {
        /// <summary>
        /// Calculate if the given point P is within the triangle P1, P2, P3 using "barycentric coordinates"
        /// https://www.youtube.com/watch?v=HYAgJN3x4GA&ab_channel=SebastianLague
        /// </summary>
        /// <param name="p1">UV 1</param>
        /// <param name="p2">UV 2</param>
        /// <param name="p3">UV 3</param>
        /// <param name="p">The pixel to check</param>
        /// <returns></returns>
        public static bool PointIsInTriangle(Point p1, Point p2, Point p3, Point p)
        {
            double s1 = p3.Y - p1.Y;
            double s2 = p3.X - p1.X;
            double s3 = p2.Y - p1.Y;
            double s4 = p.Y - p1.Y;

            double w1 = (p1.X * s1 + s4 * s2 - p.X * s1) / (s3 * s2 - (p2.X - p1.X) * s1);
            double w2 = (s4 - w1 * s3) / s1;
            return w1 >= 0 && w2 >= 0 && (w1 + w2) <= 1;
        }
    }
}
