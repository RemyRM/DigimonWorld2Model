using System.Drawing;

namespace DW2ModelParser.Utilities
{
    public static class ColourExtensions
    {

        /// <summary>
        /// Get the HEX code for the given colour
        /// </summary>
        /// <param name="col">The color to parse</param>
        /// <returns>A hex code for the colour</returns>
        public static string HexCode(this Color col) =>
            $"#{col.R:X2}{col.G:X2}{col.B:X2}"; 
    }
}
