namespace DW2ModelParser.Structs
{
    internal class BlinkingData
    {
        public const byte BlinkFrameCount = 8;

        public UvCoord Uv { get; private set; }
        public byte Width { get; private set; }
        public byte Height { get; private set; }
        public UvCoord[] FrameUvCoord { get; private set; } = new UvCoord[BlinkFrameCount];
        public int Delimiter;

        public BlinkingData(UvCoord uv, byte width, byte height, UvCoord[] frameCoords, int delimiter)
        {
            Uv = uv;
            Width = width;
            Height = height;
            FrameUvCoord = frameCoords;
            Delimiter = delimiter;
        }

        public override string ToString()
        {
            string uvCoords = "";
            foreach (var item in FrameUvCoord)
                uvCoords += $"{item} ";
            return $"Uv: {Uv} Width: {Width} Height: {Height} UvCoords: {uvCoords} Delimiter: {Delimiter}";
        }

        public string ToHexString()
        {
            string uvCoords = "";
            foreach (var item in FrameUvCoord)
                uvCoords += $"{item.ToHexString()} ";
            return $"Uv: {Uv.ToHexString()} Width: {Width:X2} Height: {Height:X2} UvCoords: {uvCoords} Delimiter: {Delimiter:X8}";
        }
    }
}
