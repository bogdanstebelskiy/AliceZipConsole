﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ConsoleApp.src.Checksum.Sha1
{
    internal class Sha1 : IChecksum
    {
        public string CalculateChecksum(string inPath, int bufferSize = 1024 * 50)
        {
            using var sha1 = System.Security.Cryptography.SHA1.Create();

            var attributes = File.GetAttributes(inPath);
            var buffer = new byte[bufferSize];

            using var fileStream = File.OpenRead(inPath);

            var bytesRead = 0;
            while ((bytesRead = fileStream.Read(buffer, 0, bufferSize)) != 0)
            {
                sha1.TransformBlock(buffer, 0, bytesRead, buffer, 0);
            }

            sha1.TransformFinalBlock(buffer, 0, 0);

            if (sha1.Hash != null)
            {
                return BitConverter.ToString(sha1.Hash).Replace("-", "").ToLower();
            }

            return "";
        }
    }
}