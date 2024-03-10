using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib.BZip2;

namespace ConsoleApp.src.BZip2
{
    internal class BZip2 : IArchiver
    {
        public int CompressionLevel { get; set; } = 5;
        public bool IsStreamOwner { get; set; } = true;

        public void Archive(string inPath, string outPath)
        {
            Validator.ValidatePath(inPath);
            Validator.ValidatePath(outPath);

            Stream inFileStream = File.OpenRead(inPath);
            Stream outFileStream = File.Create(outPath);

            ICSharpCode.SharpZipLib.BZip2.BZip2.Compress(
                inStream: inFileStream,
                outStream: outFileStream,
                isStreamOwner: IsStreamOwner,
                level: CompressionLevel
            );
        }
        public void Unarchive(string inPath, string outPath)
        {
            Validator.ValidatePath(inPath);
            Validator.ValidatePath(outPath);

            Stream inFileStream = File.OpenRead(inPath);
            Stream outFileStream = File.Create(outPath);

            ICSharpCode.SharpZipLib.BZip2.BZip2.Decompress(
                inStream: inFileStream,
                outStream: outFileStream,
                isStreamOwner: IsStreamOwner
            );
        }
    }
}
