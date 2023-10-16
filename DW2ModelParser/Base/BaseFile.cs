using DW2ModelParser.Utilities;
using System;
using System.Diagnostics;
using System.IO;

namespace DW2ModelParser.Base
{
    abstract class BaseFile
    {
        public FileInfo FileInfo { get; private set; }

        private Stream _stream;
        protected BinaryReader _binReader;

        public BaseFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Debug.WriteLine($"File: {filePath} could not be found. Returning.");
                return;
            }

            FileInfo = new FileInfo(filePath);
            GetFileBinaryReader(out _binReader);

            CConsole.WriteLineColoured($"Loading: \n{GetBasicFileInfo()}", ConsoleColor.Cyan);
        }

        protected abstract void ExtractFileInformation();

        protected void CloseBinaryReader()
        {
            _binReader.Close();
            _binReader.Dispose();
            _stream.Close();
            _binReader.Dispose();
        }


        private void GetFileBinaryReader(out BinaryReader _binReader)
        {
            _stream = File.Open(FileInfo.FullName, FileMode.Open, FileAccess.Read);
            _binReader = new BinaryReader(_stream);
        }

        protected string GetBasicFileInfo() =>
            $"Filename: {FileInfo.Name},\nDirectory:{FileInfo.DirectoryName}\nFile size:{FileInfo.Length} bytes";
    }
}
