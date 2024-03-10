using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.BZip2;
using ICSharpCode.SharpZipLib.Tar;
using ICSharpCode.SharpZipLib.Zip;
using System.Diagnostics.Contracts;

namespace ConsoleApp
{
    internal class Tar : IArchiver
    {
        public string SearchPattern { get; set; } = "*";
        public SearchOption SearchOption{ get; set; } = SearchOption.AllDirectories;
        public Encoding Encoding { get; set; } = Encoding.UTF8;


        public void Archive(string inPath, string outPath)
        {
            Validator.ValidatePath(inPath);
            Validator.ValidatePath(outPath);

            using FileStream fileStream = File.Create(outPath);
            using TarOutputStream tarOutputStream = new(fileStream, Encoding);

            using TarArchive tarArchive = TarArchive.CreateOutputTarArchive(tarOutputStream, Encoding);

            string[] fileNames = Directory.GetFiles(inPath, SearchPattern, SearchOption);

            TarEntry tarEntry;

            foreach (string file in fileNames)
            {
                string relativePath = Path.GetRelativePath(inPath, file);

                tarEntry = TarEntry.CreateEntryFromFile(Path.GetFullPath(file));
                tarEntry.Name = relativePath;   // remove to create additional inputDirName folder with files in archive
                tarArchive.WriteEntry(tarEntry, true);
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

            using FileStream fileStream = File.OpenRead(inPath);
            using TarInputStream tarInputStream = new(fileStream, Encoding);

            using TarArchive tarArchive = TarArchive.CreateInputTarArchive(tarInputStream, Encoding);
            tarArchive.ExtractContents(outPath);
        }
    }
}
