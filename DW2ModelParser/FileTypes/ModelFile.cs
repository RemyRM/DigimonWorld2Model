using DW2ModelParser.Base;
using DW2ModelParser.Headers;
using DW2ModelParser.Structs;
using DW2ModelParser.Utilities;
using System;
using System.Collections.Generic;

namespace DW2ModelParser.FileTypes
{
    internal class ModelFile : BaseFile
    {
        public ModelHeader ModelHeader { get; private set; }

        public BlinkingData EyeBlinkingData { get; private set; }
        //For each bone we get a list of Primitives, Vertice, and Normals data
        public List<List<BasePrimitive>> PrimitivesData { get; private set; } // Use the base class for Primitives as this can be both Tri's and Quads
        public List<List<Vertex>> VerticeData { get; private set; }
        public List<List<Normal>> NormalsData { get; private set; }

        //Each [M]odel file also contains a TIM file containing the texture and CLUT
        public ModelTimHeader ModelTimHeader { get; private set; }
        public byte[] TextureData { get; private set; } = new byte[0x4000]; //the actual Texture contains only 0x3E00 bytes of data, because the last 0x200 bytes are CLUT
        public ColourLookupTable CLUT { get; private set; }

        public ModelFile(string filePath) : base(filePath)
        {
            ExtractFileInformation();
            base.CloseBinaryReader();
        }

        protected override void ExtractFileInformation()
        {
            ModelHeader = new ModelHeader(ref base._binReader);
            EyeBlinkingData = GetBlinkingData();
            CConsole.WriteLineColoured($"\nBlinking data: {EyeBlinkingData.ToHexString()}", ConsoleColor.Gray);

            PrimitivesData = GetPrimitivesForBones();
            VerticeData = GetVerticeDataForBones();
            NormalsData = GetNormalDataForBones();
            ModelTimHeader = GetTimHeader();
            TextureData = GetTextureData();
            CLUT = GetRealClut();
        }

        /// <summary>
        /// Get the blinking frame data from the binary file
        /// </summary>
        /// <param name="_binReader">The file to read from</param>
        /// <returns>Blinking animation frames data</returns>
        private BlinkingData GetBlinkingData()
        {
            byte uvX = base._binReader.ReadByte();
            byte uvY = base._binReader.ReadByte();
            var uv = new UvCoord(uvX, uvY);

            byte width = base._binReader.ReadByte();
            byte height = base._binReader.ReadByte();

            UvCoord[] blinkFrames = new UvCoord[BlinkingData.BlinkFrameCount];
            for (int i = 0; i < blinkFrames.Length; i++)
            {
                byte offsetX = base._binReader.ReadByte();
                byte offsetY = base._binReader.ReadByte();
                blinkFrames[i] = new UvCoord(offsetX, offsetY);
            }

            int delimiter = base._binReader.ReadInt32();

            return new BlinkingData(uv, width, height, blinkFrames, delimiter);
        }

        /// <summary>
        /// Get the primitives data that exists per bone.
        /// The game makes a separation between Quads and Tris, separated by 0x00000000 and an int to indicate the amount of faces
        /// </summary>
        /// <returns>A list containing both Quads and Tris (in that order)</returns>
        private List<List<BasePrimitive>> GetPrimitivesForBones()
        {
            List<List<BasePrimitive>> allBonesPrimitives = new List<List<BasePrimitive>>();
            foreach (int pointer in ModelHeader.PrimitivesPointerArray)
            {
                List<BasePrimitive> bonePrimitives = new List<BasePrimitive>();
                base._binReader.BaseStream.Position = pointer;
                CConsole.WriteLineColoured($"\nPrimitive::Set BaseStream position to: 0x{pointer:X2} ({pointer})", ConsoleColor.Magenta);
                bonePrimitives.AddRange(GetQuadPrimitives());
                bonePrimitives.AddRange(GetTriPrimitives());

                allBonesPrimitives.Add(bonePrimitives);
            }

            return allBonesPrimitives;
        }

        /// <summary>
        /// Get all the Quad primitives
        /// </summary>
        /// <returns>A list containing all the Quads</returns>
        private List<QuadPrimitive> GetQuadPrimitives()
        {
            List<QuadPrimitive> quads = new List<QuadPrimitive>();

            //Update the BaseStream position to that of the pointer 
            int quadsSeparator = base._binReader.ReadInt32();
            if (quadsSeparator != 0)
            {
                CConsole.WriteLineColoured($"Error getting quad primitives, separator was not equal to zero at BaseStream position 0x{base._binReader.BaseStream.Position}", ConsoleColor.Red);
                return null;
            }

            //The first primitives encountered are always the quads
            int quadPrimitivesCount = base._binReader.ReadInt32();
            for (int i = 0; i < quadPrimitivesCount; i++)
            {
                GetFaceData(BasePrimitive.PrimitiveType.Quad, out byte[] verticeIds, out byte[] normalIds, out UvCoord[] uvMapCoords, out int unknown);
                var uvMap = new QuadUvMap(uvMapCoords);

                var quad = new QuadPrimitive(verticeIds, normalIds, uvMap, unknown);
                CConsole.WriteLineColoured($"HEX: {quad.ToHexString()}", ConsoleColor.Gray);
                quads.Add(quad);
            }

            return quads;
        }

        /// <summary>
        /// Get all the Tri primitives
        /// </summary>
        /// <returns>A list conntaining all the Tris</returns>
        private List<TriPrimitive> GetTriPrimitives()
        {
            List<TriPrimitive> tris = new List<TriPrimitive>();

            int trisSeparator = base._binReader.ReadInt32();
            if (trisSeparator != 0)
            {
                CConsole.WriteLineColoured($"Error getting tris primitives, separator was not equal to zero at BaseStream position 0x{base._binReader.BaseStream.Position}", ConsoleColor.Red);
                return null;
            }

            int triPrimitivesCount = base._binReader.ReadInt32();
            for (int i = 0; i < triPrimitivesCount; i++)
            {
                GetFaceData(BasePrimitive.PrimitiveType.Tri, out byte[] verticeIds, out byte[] normalIds, out UvCoord[] uvMapCoords, out int unknown);
                var uvMap = new TriUvMap(uvMapCoords);

                var tri = new TriPrimitive(verticeIds, normalIds, uvMap, unknown);
                CConsole.WriteLineColoured($"HEX: {tri.ToHexString()}", ConsoleColor.Gray);
                tris.Add(tri);
            }

            return tris;
        }

        /// <summary>
        /// Get the face data that is consistent for every primitive type. This includes:
        /// - Verteci ids
        /// - Normal ids
        /// - Uv Coordinates for the texture
        /// - An unknown value
        /// </summary>
        /// <param name="type">The type of face we want to process to define the amount of vertice to loop through</param>
        /// <param name="verticeIds">The ids of the verteci used</param>
        /// <param name="normalIds">The ids of the normals used</param>
        /// <param name="uvMapCoords">The UV coordinates for the texture used</param>
        /// <param name="unknown">Unknown value</param>
        private void GetFaceData(BasePrimitive.PrimitiveType type, out byte[] verticeIds, out byte[] normalIds, out UvCoord[] uvMapCoords, out int unknown)
        {
            int verteciPerFaceCount = (int)type;

            verticeIds = new byte[verteciPerFaceCount];
            normalIds = new byte[verteciPerFaceCount];
            uvMapCoords = new UvCoord[verteciPerFaceCount];

            for (int j = 0; j < verticeIds.Length; j++)
                verticeIds[j] = base._binReader.ReadByte();

            for (int j = 0; j < normalIds.Length; j++)
                normalIds[j] = base._binReader.ReadByte();

            for (int j = 0; j < uvMapCoords.Length; j++)
            {
                byte u = base._binReader.ReadByte();
                byte v = base._binReader.ReadByte();
                uvMapCoords[j] = new UvCoord(u, v);
            }

            unknown = base._binReader.ReadInt32();
        }

        /// <summary>
        /// Get the vertex data for all the bones
        /// </summary>
        /// <returns>A list containing all the vertice per bone</returns>
        private List<List<Vertex>> GetVerticeDataForBones()
        {
            //TODO: This and GetNormalDataForBones are basically the same version and can be abstracted?
            List<List<Vertex>> verticesForBones = new List<List<Vertex>>();

            foreach (int pointer in ModelHeader.VertexPointerArray)
            {
                base._binReader.BaseStream.Position = pointer;
                CConsole.WriteLineColoured($"\nVertex::Set BaseStream position to: 0x{pointer:X2} ({pointer})", ConsoleColor.Magenta);

                List<Vertex> vertices = new List<Vertex>();
                int verticeCount = base._binReader.ReadInt32();
                short alignment = base._binReader.ReadInt16();
                for (int i = 0; i < verticeCount; i++)
                {
                    short x = base._binReader.ReadInt16();
                    short y = base._binReader.ReadInt16();
                    short z = base._binReader.ReadInt16();
                    var vertex = new Vertex(x,y,z);
                    vertices.Add(vertex);
                    Console.WriteLine($"HEX: Vertex[{i:D2}]: {vertex.ToHexString()}");
                }
            }

            return verticesForBones;
        }

        /// <summary>
        /// Get the Normals data for all the bones
        /// </summary>
        /// <returns>A list containing all the Normals per bone</returns>
        private List<List<Normal>> GetNormalDataForBones()
        {
            //TODO: This and GetVerticeDataForBones are basically the same version and can be abstracted?
            List<List<Normal>> normalsForBones = new List<List<Normal>>();

            foreach (int pointer in ModelHeader.NormalsPointerArray)
            {
                base._binReader.BaseStream.Position = pointer;
                CConsole.WriteLineColoured($"\nNormal::Set BaseStream position to: 0x{pointer:X2} ({pointer})", ConsoleColor.Magenta);

                List<Normal> normals = new List<Normal>();
                int verticeCount = base._binReader.ReadInt32();
                short alignment = base._binReader.ReadInt16();
                for (int i = 0; i < verticeCount; i++)
                {
                    short x = base._binReader.ReadInt16();
                    short y = base._binReader.ReadInt16();
                    short z = base._binReader.ReadInt16();
                    var normal = new Normal(x, y, z);
                    normals.Add(normal);
                    Console.WriteLine($"HEX: Normal[{i:D2}]: {normal.ToHexString()}");
                }
            }

            return normalsForBones;
        }

        /// <summary>
        /// Get the TIM header that contains information about the texture used for the model
        /// </summary>
        /// <returns>The TIM Header</returns>
        private ModelTimHeader GetTimHeader()
        {
            base._binReader.BaseStream.Position = ModelHeader.TimPointer;
            CConsole.WriteLineColoured($"\nTimHeader::Set BaseStream position to: 0x{ModelHeader.TimPointer:X2} ({ModelHeader.TimPointer})", ConsoleColor.Magenta);
            ModelTimHeader timHeader = new ModelTimHeader(ref base._binReader);
            CConsole.WriteLineColoured(timHeader.ToHexString(), ConsoleColor.Magenta);
            return timHeader;
        }

        /// <summary>
        /// Get the 0x3E00 bytes of texture data. Each nibble represents a pixel
        /// </summary>
        /// <returns>The Texture data of the model</returns>
        private byte[] GetTextureData()
        {
            CConsole.WriteLineColoured($"\nTextureData::BaseStream is at position: 0x{base._binReader.BaseStream.Position:X2} ({base._binReader.BaseStream.Position})", ConsoleColor.Magenta);

            //We 
            byte[] buffer = new byte[TextureData.Length];
            int read = base._binReader.Read(buffer, 0, buffer.Length);
            return buffer;
        }

        /// <summary>
        /// Get the last 0x200 bytes of the texture data that contains the texture's real CLUT
        /// </summary>
        /// <returns>The Colour lookup table for the texture</returns>
        private ColourLookupTable GetRealClut()
        {
            CConsole.WriteLineColoured($"\nCLUT::BaseStream is at position: 0x{base._binReader.BaseStream.Position:X2} ({base._binReader.BaseStream.Position})", ConsoleColor.Magenta);

            short[] colourData = new short[ColourLookupTable.ClutShortCount];

            //Because the real CLUT is stored at the last 0x200 bytes of the texture data we start geting the clut data from offset 0x3E00 (where the texture ends)
            for (int i = 0; i < colourData.Length; i++)
                colourData[i] = BitConverter.ToInt16(TextureData, 0x3E00 + i * 2);

            ColourLookupTable clut = new ColourLookupTable(ColourLookupTable.BitsPerPixel.Eight, colourData);
            CConsole.WriteLineColoured(clut.ToHexString(), ConsoleColor.Blue);
            CConsole.WriteLineColoured($"\nCLUT::last pos: 0x{base._binReader.BaseStream.Position:X2} ({base._binReader.BaseStream.Position})", ConsoleColor.Magenta);

            return clut;
        }
    }
}
