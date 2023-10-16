using System;
using System.Collections.Generic;

using DW2ModelParser.Base;
using DW2ModelParser.Headers;
using DW2ModelParser.Structs;
using DW2ModelParser.Utilities;

namespace DW2ModelParser.FileTypes
{
    internal class AnimationFile : BaseFile
    {
        // Not actually part of the file's data, it is instead read in the ModelHeader, but necessary for the animation frames
        private int _boneCount { get; set; }

        public int FileStart { get; private set; } // Should always be 0x00
        public AnimationHeader AnimationHeader {get; private set;}
        public KeyframeTable[] KeyFrameTables { get; private set;}
        public List<List<BoneAnimationFrameData>> FrameAnimationsData { get; private set; }

        public AnimationFile(string filePath, int boneCount) : base(filePath)
        {
            _boneCount = boneCount;
            ExtractFileInformation();
            base.CloseBinaryReader();
        }

        protected override void ExtractFileInformation()
        {
            FileStart = base._binReader.ReadInt32();
            AnimationHeader = new AnimationHeader(ref base._binReader, _boneCount);
            CConsole.WriteLineColoured($"\nAnim header:\n{AnimationHeader.ToHexString()}", System.ConsoleColor.Blue);
            KeyFrameTables = GetKeyframeTables();
            FrameAnimationsData = GetFrameAnimationsData();
        }

        /// <summary>
        /// Follow the pointers to the keyframe tables and extract the frame IDs per bone
        /// </summary>
        private KeyframeTable[] GetKeyframeTables()
        {
            KeyframeTable[] keyframesData = new KeyframeTable[AnimationHeader.KeyframeTablePointers.Count];
            for (int i = 0; i < keyframesData.Length; i++)
            {
                int pointer = AnimationHeader.KeyframeTablePointers[i];
                base._binReader.BaseStream.Position = pointer;
                CConsole.WriteLineColoured($"\nKeyframeTables::Set BaseStream position to: 0x{pointer:X2} ({pointer})", ConsoleColor.Magenta);

                keyframesData[i] = new KeyframeTable(ref base._binReader, _boneCount);
                CConsole.WriteLineColoured($"Animation OpCode:{keyframesData[i].AnimationOpCode:X2}", ConsoleColor.Blue);
            }

            return keyframesData;
        }

        /// <summary>
        /// Get the all the frames of animation data for each bone
        /// </summary>
        private List<List<BoneAnimationFrameData>> GetFrameAnimationsData()
        {
            List<List<BoneAnimationFrameData>> frameDataCollection = new List<List<BoneAnimationFrameData>>();

            for(int i = 0; i < AnimationHeader.BoneAnimationDataPointers.Length; i++)
            {
                int pointer = AnimationHeader.BoneAnimationDataPointers[i];
                CConsole.WriteLineColoured($"\nFrameAnim::Set BaseStream position to: 0x{pointer:X2} ({pointer})", ConsoleColor.Magenta);
                base._binReader.BaseStream.Position = pointer;

                //Since there is no pointer beyond the last bone animation data we take the end of file instead to prevent over-reading
                int bytesToNextPointer = (i < AnimationHeader.BoneAnimationDataPointers.Length - 1) ?
                    AnimationHeader.BoneAnimationDataPointers[i + 1] - pointer : (int)FileInfo.Length - pointer;

                byte animationDataCount = (byte)(bytesToNextPointer / BoneAnimationFrameData.BoneAnimationFrameLength);
                CConsole.WriteLineColoured($"Bone frame data count: {animationDataCount} for bone 0x{i:X2}", ConsoleColor.Blue);

                List<BoneAnimationFrameData> frameList = new List<BoneAnimationFrameData>();
                for(int j = 0; j < animationDataCount; j++)
                {
                    var frame = new BoneAnimationFrameData(ref base._binReader);
                    frameList.Add(frame);
                    CConsole.WriteLineColoured($"Bone frame data:{frame.ToHexString()}", ConsoleColor.Gray);
                }
            }

            return frameDataCollection;
        }
    }
}
