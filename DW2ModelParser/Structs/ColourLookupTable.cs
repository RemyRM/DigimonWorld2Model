using DW2ModelParser.Utilities;
using System.Drawing;

namespace DW2ModelParser.Structs
{
    /// <summary>
    /// Colour Lookup table
    /// </summary>
    public class ColourLookupTable
    {
        public const short ClutShortCount = 0x100;
        public const short ClutWidth = 16;
        public const short ClutHeight = 16;

        public enum BitsPerPixel
        {
            Unknown = 0,
            Four = 4,
            Eight = 8,
            Sixteen = 16,
        }

        public BitsPerPixel BPP { get; private set; }
        public Color[] Colours { get; private set; }

        public ColourLookupTable(BitsPerPixel bpp, short[] colourData)
        {
            BPP = bpp;

            Colours = new Color[colourData.Length];
            for (int i = 0; i < Colours.Length; i++)
                Colours[i] = GetColour(colourData[i]);
        }

        /// <summary>
        /// Extract the RGB channel values from the short data representing a colour
        /// </summary>
        /// <param name="colourData">The 2 bytes value representing the colour in the CLUT</param>
        /// <returns>The 8 BPP colour depth colour</returns>
        private Color GetColour(short colourData)
        {
            //TODO: Create a different branch for 8bpp and 4bpp
            byte alpha = (byte)(((colourData & 0x8000) >> 15) ^ 1);//Since the alpha bit is implemented as a transparancy bit we need to flip it
            byte blue = (byte)((colourData & 0x7C00) >> 10);
            byte green = (byte)((colourData & 0x03E0) >> 5);
            byte red = (byte)(colourData & 0x1F);

            //Multiply the resulting colour data from the CLUT by 8 to get the 8bpp value
            //Since we can't really show transpancy in a single layer 2 texture we'll just show it at half alpha instead
            //return alpha == 1 ? Color.FromArgb(alpha * 255, red * 8, green * 8, blue * 8) : Color.FromArgb(128, red * 8, green * 8, blue * 8);
            return Color.FromArgb(/*alpha * */255, red * 8, green * 8, blue * 8);
        }

        public override string ToString() =>
            $"BPP: {BPP} Colour[0] {Colours[0].HexCode()} Colour[16]: {Colours[16].HexCode()} Colour[32]: {Colours[32].HexCode()} Colour[128]: {Colours[128].HexCode()} Colour[240]: {Colours[240].HexCode()}";

        public string ToHexString() =>
            $"HEX: BPP: {(int)BPP:X2} Colour[0]: {Colours[0].HexCode()} Colour[16]: {Colours[16].HexCode()} Colour[32]: {Colours[32].HexCode()} Colour[128]: {Colours[128].HexCode()} Colour[240]: {Colours[240].HexCode()}";
    }
}
