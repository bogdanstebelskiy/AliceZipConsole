using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;

namespace ConsoleApp
{
    internal class Zip : IArchiver
    {
        public int BufferSize { get; set; } = 4096;
        public string SearchPattern { get; set; } = "*";
        public SearchOption SearchOption { get; set; } = SearchOption.AllDirectories;
        public Encoding Encoding { get; set; } = Encoding.UTF8;
        public int CompressionLevel { get; set; } = 5;

        public void Archive(string inPath, string outPath)
        {

        }

        public void ArchiveStream(string inPath, string outPath)
        {
            Validator.ValidatePath(inPath);
            Validator.ValidatePath(outPath);

            string[] fileNames = Directory.GetFiles(inPath, SearchPattern, SearchOption);  // !!!

            using ZipOutputStream zipOutputStream = new(File.Create(outPath));

            zipOutputStream.SetLevel(CompressionLevel);

            ZipEntry zipEntry;

            foreach (string file in fileNames)
            {
                string relativePath = Path.GetRelativePath(inPath, file);

                zipEntry = new(relativePath)
                {
                    DateTime = DateTime.Now
                };
                zipOutputStream.PutNextEntry(zipEntry);

                using FileStream fileStream = File.OpenRead(file);
                fileStream.CopyTo(zipOutputStream);
            }
        }

        public void Unarchive(string inPath, string outPath)
        {

        }

        public void UnarchiveStream(string inPath, string outPath)
        {
            Validator.ValidatePath(inPath);
            Validator.ValidatePath(outPath);

            if (!Directory.Exists(outPath))
            {
                Directory.CreateDirectory(outPath);
            }

            using ZipInputStream zipInputStream = new (File.OpenRead(inPath));

            ZipEntry zipEntry;

            while((zipEntry = zipInputStream.GetNextEntry()) != null)
            {
                string? dirName = Path.GetDirectoryName(zipEntry.Name);
                string? fileName = Path.GetFileName(zipEntry.Name);

                if (!string.IsNullOrEmpty(dirName))
                {
                    Directory.CreateDirectory(outPath + dirName);
                }

                if (!string.IsNullOrEmpty(fileName))
                {
                    using FileStream fileStream = File.Create(outPath + zipEntry.Name);
                    zipInputStream.CopyTo(fileStream);
                }
            }
        }
    }
}
