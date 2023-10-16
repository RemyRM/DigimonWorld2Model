using DW2ModelParser.Utilities;
using System;
using System.IO;

namespace DW2ModelParser.Headers
{
    internal class ModelTimHeader
    {
        public const byte _HeaderLength = 0x40;

        /// <summary>
        /// The Width stored in the games data is wrong (32) as there are actually 64 bytes of data.
        /// Not actually part of the file information. 
        /// </summary>
        public short _TrueByteWidth { get => (short)(Width * 2); }
        /// <summary>
        /// But because there are also 2 pixels (width) per byte due to using a nibble, the true pixel width of the texture is 4 times as large
        /// as the value stored in the TIM header's "width" value
        /// </summary>
        public short _TruePixelWidth { get => (short)(Width * 4); }

        public byte TimTag { get; private set; } // Should always be 0x10
        public byte TimVersion { get; private set; } // Should always be 0x00
        public short AlignmentVersion { get; private set; } // Should always be 0x00 0x00
        public int Bpp { get; private set; } // Should always be 0x08
        public int GpuOpcode { get; private set; } // Should always be 0x2C. Not sure if GPU opcode, but seems like it
        public int Unknown1 { get; private set; } // Always 0x01 0xE0, but seems unsued (might be palette?)
        public short ColourCount { get; private set; } // Should always be 0x0100
        public short ColourPage { get; private set; } // Should always be 0x01
        public short[] TimCLUT { get; private set; } = new short[16]; // Original, unused, TIM Clut
        public int Unknown2 { get; private set; } // Seems to always be 0x0C 0x40
        public int Unknown3 { get; private set; } // Seems to always be 0x40 0x01
        public short Width { get; private set; } // Should always be 0x20
        public short Height { get; private set; } // Should always be 0x0100

        public ModelTimHeader(ref BinaryReader binReader)
        {
            ExtractHeaderData(ref binReader);
            if (TimTag != 0x10)
                CConsole.WriteLineColoured("First byte of Tim header was not 0x10, returning null", ConsoleColor.Red);

            if(TimVersion != 0x00)
                CConsole.WriteLineColoured("TIM version was not 0x00", ConsoleColor.Yellow);

        }

        private void ExtractHeaderData(ref BinaryReader binReader)
        {
            TimTag = binReader.ReadByte();
            if(TimTag != 0x10)
                return;

            TimVersion = binReader.ReadByte();
            AlignmentVersion = binReader.ReadInt16();
            Bpp = binReader.ReadInt32();
            GpuOpcode = binReader.ReadInt32();
            Unknown1 = binReader.ReadInt32();
            ColourCount = binReader.ReadInt16();
            ColourPage = binReader.ReadInt16();

            for (int i = 0; i < TimCLUT.Length; i++)
                TimCLUT[i] = binReader.ReadInt16();

            Unknown2 = binReader.ReadInt32();
            Unknown3 = binReader.ReadInt32();
            Width = binReader.ReadInt16();
            Height = binReader.ReadInt16();
        }

        public override string ToString() =>
            $"Tag: {TimTag:D2} Ver: {TimVersion:D2} Bpp: {Bpp:D2} Width:{Width:D3} Height: {Height:D3}";

        public string ToHexString() =>
            $"HEX: Tag: {TimTag:X2} Ver: {TimVersion:X2} Bpp: {Bpp:X2} Width:{Width:X2} Height: {Height:X2}";
    }
}
