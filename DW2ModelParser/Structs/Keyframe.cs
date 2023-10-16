namespace DW2ModelParser.Structs
{
    internal class Keyframe
    {
        public byte[] KeyframeIds { get; private set; }

        public Keyframe(int boneCount)
        {
            KeyframeIds = new byte[boneCount];
        }

        public override string ToString()
        {
            string result = "Keyframe Ids: ";
            foreach (var id in KeyframeIds)
                result += $"{id} ";

            return result;
        }

        public string ToHexString()
        {
            string result = "HEX:Keyframe Ids: ";
            foreach (var id in KeyframeIds)
                result += $"{id:X2} ";

            return result;
        }
    }
}
