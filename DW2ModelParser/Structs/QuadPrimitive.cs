using DW2ModelParser.Base;
using System;
using System.Windows;

namespace DW2ModelParser.Structs
{
    internal class QuadPrimitive : BasePrimitive
    {
        // ID's for the vertices to use to form the quad
        public byte Vertex4ID { get; private set; }

        // ID's for the vertices normals
        public byte Normal4ID { get; private set; }

        //UV map for the texture to be placed on this quad
        public QuadUvMap UvMap { get; private set; } 

        public QuadPrimitive(byte v1, byte v2, byte v3, byte v4, byte n1, byte n2, byte n3, byte n4, QuadUvMap uvMap, int clutOffset) : base(PrimitiveType.Quad)
        {
            Vertex1ID = v1;
            Vertex2ID = v2;
            Vertex3ID = v3;
            Vertex4ID = v4;
            Normal1ID = n1;
            Normal2ID = n2;
            Normal3ID = n3;
            Normal4ID = n4;
            UvMap = uvMap;
            ClutOffset = clutOffset;
        }

        public QuadPrimitive(byte[] vertices, byte[] normals, QuadUvMap uvMap, int clutOffset): base(PrimitiveType.Quad)
        {
            Vertex1ID = vertices[0];
            Vertex2ID = vertices[1];
            Vertex3ID = vertices[2];
            Vertex4ID = vertices[3];

            Normal1ID = normals[0];
            Normal2ID = normals[1];
            Normal3ID = normals[2];
            Normal4ID = normals[3];

            UvMap = uvMap;
            ClutOffset = clutOffset;
        }

        public override string ToString() => 
            $"V: {Vertex1ID:D3} {Vertex2ID:D3} {Vertex3ID:D3} {Vertex4ID:D3} N: {Normal1ID:D3} {Normal2ID:D3} {Normal3ID:D3} {Normal4ID:D3} UV: {UvMap} ClutOffset: {ClutOffset}";
        
        public string ToHexString() => 
            $"V: {Vertex1ID:X2} {Vertex2ID:X2} {Vertex3ID:X2} {Vertex4ID:X2} N: {Normal1ID:X2} {Normal2ID:X2} {Normal3ID:X2} {Normal4ID:X2} UV: {UvMap.ToHexString()} ClutOffset: {ClutOffset:X4}";
    }
}
