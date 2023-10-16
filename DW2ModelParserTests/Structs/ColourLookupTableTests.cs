using DW2ModelParser.Utilities;
using NuGet.Frameworks;

namespace DW2ModelParserTests.Utilities
{
    public class ColourLookupTableTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void LowNibbleTest()
        {
            byte testByte = 0xFF;

            byte lowNibble = testByte.LowNibble();

            Assert.IsTrue(lowNibble == 0x0F);
        }

        [Test]
        public void HighNibbleTest()
        {
            byte testByte = 0xFF;

            byte highNibble = testByte.HighNibble();

            Assert.IsTrue(highNibble == 0xF0);
        }
    }
}