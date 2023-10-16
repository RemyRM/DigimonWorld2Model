using DW2ModelParser.Utilities;
using System;
using System.Collections.Generic;
using System.IO;

namespace DW2ModelParser.Structs
{
    internal class KeyframeTable
    {
        public List<Keyframe> Keyframes { get; private set; }
        public int AnimationOpCode { get; private set; }

        public KeyframeTable(ref BinaryReader binReader, int boneCount)
        {
            Keyframes = GetKeyframes(ref binReader, boneCount);
            AnimationOpCode = binReader.ReadInt32();
        }

        /// <summary>
        /// Get the bone animation IDs in the keyframes table for each frame
        /// </summary>
        private List<Keyframe> GetKeyframes(ref BinaryReader binReader, int boneCount)
        {
            List<Keyframe> keyframes = new List<Keyframe>();

            int nextChar = binReader.PeekByte();
            //Because we do not know the amount of frames for the animation ahead of time we need to read until we reach the animation OpCode
            while (nextChar != 0xFE && nextChar != 0xFF)
            {
                Keyframe keyframe = new Keyframe(boneCount);
                for (int i = 0; i < boneCount; i++)
                    keyframe.KeyframeIds[i] = binReader.ReadByte();

                CConsole.WriteLineColoured(keyframe.ToHexString(), ConsoleColor.Gray);
                //Peek the next byte to see if we've reached the end of the array
                nextChar = binReader.PeekByte() & 0xFF;
            }

            return keyframes;
        }
    }
}
