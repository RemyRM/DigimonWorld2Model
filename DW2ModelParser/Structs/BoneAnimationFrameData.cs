using System.IO;

namespace DW2ModelParser.Structs
{
    internal class BoneAnimationFrameData
    {
        public const byte BoneAnimationFrameLength = 24;

        public short ShearTopX { get; private set; }
        public short ShearBackX { get; private set; }
        public short XScale { get; private set; }
        public short YScale { get; private set; }   
        public short ShearBackY { get; private set; }
        public short ShearLeftY { get; private set; }
        public short ShearTopZ { get; private set; }
        public short ZScale { get; private set; }
        public short ShearLeftZ { get; private set; }   
        public short XPos { get; private set; }
        public short YPos { get; private set; }
        public short ZPos { get; private set; }

        public BoneAnimationFrameData(ref BinaryReader binReader)
        {
            GetAnimationData(ref binReader);
        }

        private void GetAnimationData(ref BinaryReader binReader)
        {
            ShearTopX = binReader.ReadInt16();
            ShearBackX = binReader.ReadInt16();
            XScale = binReader.ReadInt16();
            YScale = binReader.ReadInt16();
            ShearBackY = binReader.ReadInt16();
            ShearLeftY = binReader.ReadInt16();
            ShearTopZ = binReader.ReadInt16();
            ZScale = binReader.ReadInt16();
            ShearLeftZ = binReader.ReadInt16();
            XPos = binReader.ReadInt16();
            YPos = binReader.ReadInt16();
            ZPos = binReader.ReadInt16();
        }

        public override string ToString() =>
            $"{ShearTopX:D3} {ShearBackX:D3} {XScale:D3} {YScale:D3} {ShearBackY:D3} {ShearLeftY:D3} {ShearTopZ:D3} {ZScale:D3} {ShearLeftZ:D3} {XPos:D3} {YPos:D3} {ZPos:D3}";

        public string ToHexString() =>
            $"HEX: {ShearTopX:X4} {ShearBackX:X4} {XScale:X4} {YScale:X4} {ShearBackY:X4} {ShearLeftY:X4} {ShearTopZ:X4} {ZScale:X4} {ShearLeftZ:X4} {XPos:X4} {YPos:X4} {ZPos:X4}";
    }
}
