using DW2ModelParser.Base;

namespace DW2ModelParser.Structs
{
    /// <summary>
    /// Defines 4 UV coordinates to get a rectangular part of the texture to project onto the model.
    /// The order of the points is dependant on the order of the vertices.
    /// </summary>
    internal class QuadUvMap : BaseUvMap
    {
        public UvCoord Point4 { get; set; }

        public QuadUvMap(UvCoord uv1, UvCoord uv2, UvCoord uv3, UvCoord uv4) : base(UvMapType.Quad)
        {
            Point1 = uv1;
            Point2 = uv2;
            Point3 = uv3;
            Point4 = uv4;
        }

        public QuadUvMap(short x1, short y1, short x2, short y2, short x3, short y3, short x4, short y4) : base(UvMapType.Quad)
        {
            Point1 = new UvCoord(x1, y1);
            Point2 = new UvCoord(x2, y2);
            Point3 = new UvCoord(x3, y3);
            Point4 = new UvCoord(x4, y4);
        }

        public QuadUvMap(UvCoord[] uvMapCoords) : base(UvMapType.Quad)
        {
            Point1 = uvMapCoords[0];
            Point2 = uvMapCoords[1];
            Point3 = uvMapCoords[2];
            Point4 = uvMapCoords[3];
        }

        public override string ToString() =>
            $"({Point1}), ({Point2}), ({Point3}), ({Point4}),";
        public string ToHexString() =>
            $"({Point1.ToHexString()}), ({Point2.ToHexString()}), ({Point3.ToHexString()}), ({Point4.ToHexString()}),";

        public override UvCoord[] GetUvsAsArray() =>
            new UvCoord[] { Point1, Point2, Point3, Point4 };
    }

    /// <summary>
    /// Defines 3 UV coordinates to get a triangular part of the texture to project onto the model.
    /// The order of the points is dependant on the order of the vertices.
    /// </summary>
    internal class TriUvMap : BaseUvMap
    {
        public TriUvMap(UvCoord uv1, UvCoord uv2, UvCoord uv3) : base(UvMapType.Tri)
        {
            Point1 = uv1;
            Point2 = uv2;
            Point3 = uv3;
        }

        public TriUvMap(short x1, short y1, short x2, short y2, short x3, short y3) : base(UvMapType.Tri)
        {
            Point1 = new UvCoord(x1, y1);
            Point2 = new UvCoord(x2, y2);
            Point3 = new UvCoord(x3, y3);
        }

        public TriUvMap(UvCoord[] uvMapCoords) : base(UvMapType.Tri)
        {
            Point1 = uvMapCoords[0];
            Point2 = uvMapCoords[1];
            Point3 = uvMapCoords[2];
        }

        public override string ToString() =>
            $"({Point1}), ({Point2}), ({Point3})";

        public string ToHexString() =>
            $"({Point1.ToHexString()}), ({Point2.ToHexString()}), ({Point3.ToHexString()})";

        public override UvCoord[] GetUvsAsArray() =>
            new UvCoord[] { Point1, Point2, Point3 };
    }
}
