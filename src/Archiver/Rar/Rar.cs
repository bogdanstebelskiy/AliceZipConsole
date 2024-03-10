using Aspose.Zip.Rar;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.src.Archiver.Rar
{
    internal class Rar : IArchiver
    {
        public void Archive(string inPath, string outPath) => throw new NotSupportedException("Archiving is not supported for RAR format.");

        public void Unarchive(string inPath, string outPath)
        {
            Validator.ValidatePath(inPath);
            Validator.ValidatePath(outPath);

            using FileStream fileStream = File.OpenRead(inPath);

            using RarArchive archive = new(fileStream);
            archive.ExtractToDirectory(outPath);
        }
    }
}
