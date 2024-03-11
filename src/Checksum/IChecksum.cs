using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.src.Checksum
{
    internal interface IChecksum
    {
        string? CalculateChecksum(string inPath);
    }
}
