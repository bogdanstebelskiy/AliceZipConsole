﻿
using System;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.BZip2;
using ICSharpCode.SharpZipLib.Tar;
using System.Runtime.CompilerServices;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IArchiver tar = ArchiverFactory.CreateArchiver("tar");
            //IPacker tar = PackerFactory.CreatePacker("gzip");

            //tar.Archive("test", "output.tar");

            IArchiver seven = ArchiverFactory.CreateArchiver("7zip");
            seven.Archive("test", "anotherone.7z");
            //IArchiver zip = ArchiverFactory.CreateArchiver("zip");
            //zip.Unarchive("output.zip", "./new/");
            //gzip.Compress("output.tar", "output.tar.gz", 9);
            //algorithm.Decompress("./output.tar", "./new/");

            //algorithm.Compress("test", "output.zip");

            //algorithm.Decompress("./tmp/output.zip", "./another/");
            

        }
    }
}