using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.src
{
    internal static class ArchiverFactory
    {
        public static IArchiver CreateArchiver(string typeName)
        {
            IArchiver archiverType = typeName.ToLower() switch
            {
                "zip" => new Zip(),
                "7zip" => new SevenZip(),
                "rar" => new Rar(),
                "lz" => new Lz(),
                "lzma" => new Lzma(),
                "tar" => new Tar(),
                "gzip" => new GZip(),
                "bzip2" => new BZip2(),
                _ => new Zip()
            };

            return archiverType;
        }
    }
}
