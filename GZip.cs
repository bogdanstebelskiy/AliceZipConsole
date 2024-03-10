using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib.GZip;


namespace ConsoleApp
{
    internal class GZip : IArchiver
    {
        public int BufferSize { get; set; } = 512;
        public int CompressionLevel { get; set; } = 5;
        public bool IsStreamOwner { get; set; } = true;
        public void Archive(string inPath, string outPath)
        {
            Validator.ValidatePath(inPath);
            Validator.ValidatePath(outPath);

            Stream inFileStream = File.OpenRead(inPath);
            Stream outFileStream = File.Create(outPath);

            ICSharpCode.SharpZipLib.GZip.GZip.Compress(
                inStream: inFileStream, 
                outStream: outFileStream, 
                isStreamOwner: IsStreamOwner, 
                bufferSize: BufferSize,
                level: CompressionLevel
            );
        }
        public void Unarchive(string inPath, string outPath)
        {
            Validator.ValidatePath(inPath);
            Validator.ValidatePath(outPath);

            Stream inFileStream = File.OpenRead(inPath);
            Stream outFileStream = File.Create(outPath);

            ICSharpCode.SharpZipLib.GZip.GZip.Decompress(
                inStream: inFileStream, 
                outStream: outFileStream, 
                isStreamOwner: IsStreamOwner  
            );
        }
    }
}
