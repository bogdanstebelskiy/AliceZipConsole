using ConsoleApp.src.Archiver.Lz;
using ConsoleApp.src.Archiver.Lzma;
using ConsoleApp.src.Archiver.Rar;
using ConsoleApp.src.Archiver.SevenZip;
using ConsoleApp.src.Archiver.Tar;
using ConsoleApp.src.Archiver.Zip;
using ConsoleApp.src.Archiver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.src.Checksum.SHA256;

namespace ConsoleApp.src.Checksum
{
    internal class ChecksumFactory
    {
        public static IChecksum CreateChecksum(string typeName)
        {
            IChecksum checksumType = typeName.ToLower() switch
            {
                "sha256" => new Sha256(),
                _ => new Sha256(),
            };

            return checksumType;
        }
    }
}
