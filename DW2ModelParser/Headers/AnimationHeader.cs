using System.Collections.Generic;
using System.IO;

namespace DW2ModelParser.Headers
{
    internal class AnimationHeader
    {
        public int[] BoneAnimationDataPointers { get; private set; } // Lenght is equal to the amount of bones in the matching [M] model file
        public List<int> KeyframeTablePointers { get; private set; } = new List<int>();
        public int KeyframeTablePointersDelimiter { get; private set; }

        public AnimationHeader(ref BinaryReader binReader, int boneCount)
        {
            BoneAnimationDataPointers = new int[boneCount];
            for (int i = 0; i < boneCount; i++) 
                BoneAnimationDataPointers[i] = binReader.ReadInt32();

            KeyframeTablePointers = GetKeyframePointers(ref binReader);
        }

        /// <summary>
        /// Get the pointers to the keyframe tables, this is usually 1, but has been observed to go up to 3
        /// </summary>
        /// <returns>An array of pointers to the keyframe tables</returns>
        private List<int> GetKeyframePointers(ref BinaryReader binReader)
        {
            List<int> keyframes = new List<int>();
            int buffer = 0;

            //Because we do not know ahead of time how many Keyframe tables there are we need to read until we reach the delimiter
            while (buffer != 0x01)
            {
                buffer = binReader.ReadInt32();
                if (buffer == 0x01)
                {
                    KeyframeTablePointersDelimiter = buffer;
                    continue;
                }

                keyframes.Add(buffer);
            }

            return keyframes;
        }

        public override string ToString()
        {
            string result = "Bone animation Pointers:\n";
            foreach (var boneAnimationPointer in BoneAnimationDataPointers)
                result += $"{boneAnimationPointer} ";

            result += "\nKey frame pointers:\n";
            foreach (var keyframePointer in KeyframeTablePointers)
            {
                result += $"{keyframePointer} ";
            }

            result += $"\nDelimiter: {KeyframeTablePointersDelimiter}";
            return result;
        }

        public string ToHexString()
        {
            string result = "Bone animation Pointers:\n";
            foreach (var boneAnimationPointer in BoneAnimationDataPointers)
                result += $"0x{boneAnimationPointer:X2} ";

            result += "\nKey frame pointers:\n";
            foreach (var keyframePointer in KeyframeTablePointers)
            {
                result += $"0x{keyframePointer:X2} ";
            }

            result += $"\nDelimiter: {KeyframeTablePointersDelimiter:X2}";
            return result;

        }
    }
}
