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
using ConsoleApp.src.Checksum.Sha256;

namespace ConsoleApp.src.Checksum
{
    internal class ChecksumFactory
    {
        public static IChecksum CreateChecksum(string typeName)
        {
            IChecksum checksumType = typeName.ToLower() switch
            {
                "sha256" => new Sha256.Sha256(),
                "crc32" => new Crc32.Crc32(),
                "bzip2crc" => new BZip2Crc.BZip2Crc(),
                "adler32" => new Adler32.Adler32(),
                _ => new Sha256.Sha256(),
            };

            return checksumType;
        }
    }
}
