using System;
using System.IO;
using System.Diagnostics;

namespace DW2ModelParser.Utilities
{
    public static class BinaryReaderExtensions
    {
        /// <summary>
        /// Read one byte ahead and restore the BaseStream.Position to its original position
        /// </summary>
        /// <param name="binReader"></param>
        /// <returns>The byte read, or 0xFF if trying to read past the stream</returns>
        /// <exception cref="EndOfStreamException">Tried to peek past the end of the stream</exception>
        public static byte PeekByte(this BinaryReader binReader)
        {
            try
            {
                byte result = binReader.ReadByte();
                binReader.BaseStream.Position -= 1;
                return result;
            }
            catch(EndOfStreamException ex)
            {
                Debug.WriteLine($"Error: Reading past end of stream:\n{ex}\nReturning 0xFF");
                return 0xFF;
            }
            catch(Exception ex)
            {
                Debug.WriteLine($"Error: peeking byte:\n{ex}\nReturning 0xFF");
                return 0xFF;
            }
        }
    }
}
