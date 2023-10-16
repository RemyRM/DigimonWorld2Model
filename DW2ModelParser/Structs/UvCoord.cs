using System.Drawing;

namespace DW2ModelParser.Structs
{
    internal class UvCoord
    {
        public short U { get; private set; } 
        public short V { get; private set; }

        public UvCoord(short x, short y)
        {
            U = x;
            V = y;
        }

        public static implicit operator Point(UvCoord uv) => new Point(uv.U, uv.V);
        public static UvCoord operator *(UvCoord uv1, int multiplier) => new UvCoord((short)(uv1.U * multiplier), (short)(uv1.V * multiplier));

        public override string ToString() => 
            $"U:{U:D3}, V:{V:D3}";

        public string ToHexString(string format = "X2") => 
            $"U:{U.ToString(format)}, V:{V.ToString(format)}";
    }
}
