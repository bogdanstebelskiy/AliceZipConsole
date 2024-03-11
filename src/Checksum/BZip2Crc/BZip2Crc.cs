﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.src.Checksum.BZip2Crc
{
    internal class BZip2Crc : IChecksum
    {
        public int BufferSize { get; set; } = 4096;
        public string? CalculateChecksum(string inPath)
        {
            using var checksumStream = File.OpenRead(inPath);

            var currentCrc = new ICSharpCode.SharpZipLib.Checksum.BZip2Crc();

            var buffer = new byte[BufferSize];
            var bytesRead = 0;

            while ((bytesRead = checksumStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                currentCrc.Update(new ArraySegment<byte>(buffer, 0, bytesRead));
            }

            return currentCrc.Value.ToString("X");
        }
    }
}