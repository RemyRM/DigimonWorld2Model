namespace DW2ModelParser.Utilities
{
    public static class ByteExtensions
    {
        /// <summary>
        /// Get the value from the low nibble in the byte (lowest 4 bits)
        /// </summary>
        /// <param name="by">Byte to split</param>
        /// <returns>Low nibble value</returns>
        public static byte LowNibble(this byte by) => 
            (byte)(by & 0x0F);

        /// <summary>
        /// Get the value from the high nibble in the byte (highest 4 bits)
        /// </summary>
        /// <param name="by">Byte to split</param>
        /// <returns>High nibble value</returns>
        public static byte HighNibble(this byte by) => 
            (byte)((by & 0xF0) >> 4);
    }
}
