using System.IO;

namespace DW2ModelParser.Headers
{
    internal class ModelHeader
    {
        public int TimPointer { get; private set; }
        public int TimDelimiter { get; private set; }
        public int BoneCount { get; private set; }
        public int[] VertexPointerArray { get; private set; }
        public int[] NormalsPointerArray { get; private set; }
        public int[] PrimitivesPointerArray { get; private set; }
        public int[] BonesData { get; private set; }

        public ModelHeader(ref BinaryReader binReader)
        {
            TimPointer = binReader.ReadInt32();
            TimDelimiter = binReader.ReadInt32();
            BoneCount = binReader.ReadInt32();

            //Keep passing the binary reader as a reference so that binReader.BaseStream.Position keeps up to date
            VertexPointerArray = GetArrayDataForBoneCount(ref binReader);
            NormalsPointerArray = GetArrayDataForBoneCount(ref binReader);
            PrimitivesPointerArray = GetArrayDataForBoneCount(ref binReader);
            BonesData = GetArrayDataForBoneCount(ref binReader);
        }

        private int[] GetArrayDataForBoneCount(ref BinaryReader binReader)
        {
            int[] pointerArray = new int[BoneCount];
            for (int i = 0; i < BoneCount; i++)
                pointerArray[i] = binReader.ReadInt32();
            return pointerArray;
        }
    }
}
