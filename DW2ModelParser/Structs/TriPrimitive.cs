using DW2ModelParser.Base;

namespace DW2ModelParser.Structs
{
    internal class TriPrimitive : BasePrimitive
    {
        //UV map for the texture to be placed on this quad
        public TriUvMap UvMap { get; private set; }


        public TriPrimitive(byte v1, byte v2, byte v3, byte n1, byte n2, byte n3, TriUvMap uvMap, int clutOffset) : base(PrimitiveType.Tri)
        {
            Vertex1ID = v1;
            Vertex2ID = v2;
            Vertex3ID = v3;
            Normal1ID = n1;
            Normal2ID = n2;
            Normal3ID = n3;
            UvMap = uvMap;
            ClutOffset = clutOffset;
        }

        public TriPrimitive(byte[] vertices, byte[] normals, TriUvMap uvMap, int clutOffset) : base(PrimitiveType.Tri)
        {
            Vertex1ID = vertices[0];
            Vertex2ID = vertices[1];
            Vertex3ID = vertices[2];

            Normal1ID = normals[0];
            Normal2ID = normals[1];
            Normal3ID = normals[2];

            UvMap = uvMap;
            ClutOffset = clutOffset;
        }

        public override string ToString() => 
            $"V: {Vertex1ID:D3} {Vertex2ID:D3} {Vertex3ID:D3} N: {Normal1ID:D3} {Normal2ID:D3} {Normal3ID:D3} UV: {UvMap} ClutOffset: {ClutOffset}";
        
        public string ToHexString() => 
            $"V: {Vertex1ID:X2} {Vertex2ID:X2} {Vertex3ID:X2} N: {Normal1ID:X2} {Normal2ID:X2} {Normal3ID:X2} UV: {UvMap.ToHexString()} ClutOffset: {ClutOffset:X4}";

    }
}
