using DW2ModelParser.Interfaces;

namespace DW2ModelParser.Structs
{
    internal class Normal : ICoordinate
    {
        public short X { get; private set; }
        public short Y { get; private set; }
        public short Z { get; private set; }

        public Normal(short x, short y, short z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override string ToString() => 
            $"X:{X:D3}, Y:{Y:D3}, Z:{Z:D3}";
        
        public string ToHexString() => 
            $"X:{X:X4}, Y:{Y:X4}, Z:{Z:X4}";
    }
}
