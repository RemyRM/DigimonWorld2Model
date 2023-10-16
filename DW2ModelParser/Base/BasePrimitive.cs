using DW2ModelParser.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DW2ModelParser.Base
{
    internal abstract class BasePrimitive
    {
        public enum PrimitiveType
        {
            Unknown = 0,
            Tri = 3,
            Quad = 4,
        }
        public PrimitiveType Type { get; set; }

        // ID's for the vertices to use to form the quad
        public byte Vertex1ID { get; protected set; }
        public byte Vertex2ID { get; protected set; }
        public byte Vertex3ID { get; protected set; }

        // ID's for the vertices normals
        public byte Normal1ID { get; protected set; }
        public byte Normal2ID { get; protected set; }
        public byte Normal3ID { get; protected set; }

        //As of yet unknown data
        public int ClutOffset { get; protected set; }


        public BasePrimitive(PrimitiveType type) 
        {
            Type = type;
        }

    }
}
