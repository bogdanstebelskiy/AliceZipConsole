using Aspose.Zip.LZMA;
using Aspose.Zip.Rar;
using Aspose.Zip.Saving;
using Aspose.Zip.SevenZip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.src.SevenZip
{
    internal class SevenZip : IArchiver
    {
        public void Archive(string inPath, string outPath)
        {
            Validator.ValidatePath(inPath);
            Validator.ValidatePath(outPath);

            using SevenZipArchive archive = new();

            archive.CreateEntries(inPath);
            archive.Save(outPath);
        }
        public void Unarchive(string inPath, string outPath)
        {
            Validator.ValidatePath(inPath);
            Validator.ValidatePath(outPath);

            using FileStream fileStream = File.OpenRead(inPath);

            using SevenZipArchive archive = new(fileStream);
            archive.ExtractToDirectory(outPath);
        }
    }
}
