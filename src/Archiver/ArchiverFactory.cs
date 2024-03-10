using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.src.Archiver
{
    internal static class ArchiverFactory
    {
        public static IArchiver CreateArchiver(string typeName)
        {
            IArchiver archiverType = typeName.ToLower() switch
            {
                "zip" => new Zip.Zip(),
                "7zip" => new SevenZip.SevenZip(),
                "rar" => new Rar.Rar(),
                "lz" => new Lz.Lz(),
                "lzma" => new Lzma.Lzma(),
                "tar" => new Tar.Tar(),
                "gzip" => new GZip.GZip(),
                "bzip2" => new BZip2.BZip2(),
                _ => new Zip.Zip()
            };

            return archiverType;
        }
    }
}
