using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ConsoleApp.src.Checksum.SHA256
{
    internal class Sha256 : IChecksum
    {
        public string CalculateChecksum(string inPath, int bufferSize = 1024 * 50)
        {
            using var sha256 = System.Security.Cryptography.SHA256.Create();

            var attributes = File.GetAttributes(inPath);
            var buffer = new byte[bufferSize];

            using var fileStream = File.OpenRead(inPath);

            var bytesRead = 0;
            while ((bytesRead = fileStream.Read(buffer, 0, bufferSize)) != 0)
            {
                sha256.TransformBlock(buffer, 0, bytesRead, buffer, 0);
            }

            sha256.TransformFinalBlock(buffer, 0, 0);
            
            if (sha256.Hash != null)
            {
                return BitConverter.ToString(sha256.Hash).Replace("-", "").ToLower();
            }

            return "";
        }
    }
}
