using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;

namespace ConsoleApp.src.Archiver.Zip
{
    internal class Zip : IArchiver
    {
        public string SearchPattern { get; set; } = "*";
        public SearchOption SearchOption { get; set; } = SearchOption.AllDirectories;
        public Encoding Encoding { get; set; } = Encoding.UTF8;
        public int CompressionLevel { get; set; } = 5;

        public void Archive(string inPath, string outPath)
        {
            Validator.ValidatePath(inPath);
            Validator.ValidatePath(outPath);

            var fileNames = Directory.GetFiles(inPath, SearchPattern, SearchOption);

            using ZipOutputStream zipOutputStream = new(File.Create(outPath));

            zipOutputStream.SetLevel(CompressionLevel);

            foreach (var file in fileNames)
            {
                var relativePath = Path.GetRelativePath(inPath, file);

                ZipEntry zipEntry = new(relativePath)
                {
                    DateTime = DateTime.Now
                };
                zipOutputStream.PutNextEntry(zipEntry);

                using var fileStream = File.OpenRead(file);
                fileStream.CopyTo(zipOutputStream);
            }
        }

        public void Unarchive(string inPath, string outPath)
        {
            Validator.ValidatePath(inPath);
            Validator.ValidatePath(outPath);

            if (!Directory.Exists(outPath))
            {
                Directory.CreateDirectory(outPath);
            }

            using ZipInputStream zipInputStream = new(File.OpenRead(inPath));

            while (zipInputStream.GetNextEntry() is { } zipEntry)
            {
                var dirName = Path.GetDirectoryName(zipEntry.Name);
                var fileName = Path.GetFileName(zipEntry.Name);

                if (!string.IsNullOrEmpty(dirName))
                {
                    Directory.CreateDirectory(outPath + dirName);
                }

                if (string.IsNullOrEmpty(fileName)) continue;

                using var fileStream = File.Create(outPath + zipEntry.Name);
                zipInputStream.CopyTo(fileStream);
            }
        }
    }
}
