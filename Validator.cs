using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal static class Validator
    {
        public static void ValidatePath(string path) {
            if (string.IsNullOrEmpty(path)) throw new ArgumentNullException(nameof(path), "Path can't be null.");
        }
    }
}
