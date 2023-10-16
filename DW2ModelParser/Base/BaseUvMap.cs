using DW2ModelParser.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DW2ModelParser.Base
{
    internal abstract class BaseUvMap
    {
        public enum UvMapType
        {
            Unknown = 0,
            Tri = 3,
            Quad = 4,
        }
        public UvMapType Type { get; set; }

        public UvCoord Point1 { get; set; }
        public UvCoord Point2 { get; set; }
        public UvCoord Point3 { get; set; }

        public BaseUvMap(UvMapType mapType)
        {
            Type = mapType;
        }

        public abstract UvCoord[] GetUvsAsArray();
    }
}
