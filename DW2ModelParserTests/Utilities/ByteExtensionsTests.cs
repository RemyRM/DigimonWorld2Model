using DW2ModelParser.Structs;
using NuGet.Frameworks;
using System.Drawing;

namespace DW2ModelParserTests.Structs
{
    public class ColourLookupTableTests
    {
        private readonly short[] ClutData = new short[] { unchecked((short)0x0000), 
                                                          unchecked((short)0x7FFF),
                                                          unchecked((short)0x7C00),
                                                          unchecked((short)0x03E0),
                                                          unchecked((short)0x7FE0),
                                                          unchecked((short)0x001F)};

        private readonly Color[] CheckColours = new Color[]{Color.FromArgb(255,0,0,0),
                                                   Color.FromArgb(255,248,248,248),
                                                   Color.FromArgb(255,0,0,248),
                                                   Color.FromArgb(255,0,248,0),
                                                   Color.FromArgb(255,0,248,248),
                                                   Color.FromArgb(255,248,0,0)};

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetColourTest()
        {
            ColourLookupTable Clut = new ColourLookupTable(ColourLookupTable.BitsPerPixel.Eight, ClutData);

            for (int i = 0; i < Clut.Colours.Length; i++)
                Assert.That(CheckColours[i], Is.EqualTo(Clut.Colours[i]));
        }
    }
}