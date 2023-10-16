using DW2ModelParser.Utilities;
using NuGet.Frameworks;
using System.Drawing;

namespace DW2ModelParserTests.Utilities
{
    public class ColourExtensionsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ToHexTest()
        {
            Color Color = Color.FromArgb(255, 255, 255);

            string hexColor = Color.HexCode();

            Assert.That(hexColor, Is.EqualTo("#FFFFFF"));
        }
    }
}