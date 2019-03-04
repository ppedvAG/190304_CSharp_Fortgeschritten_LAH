using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    static class Erweiterungsmethoden
    {
        public static bool IsNumeric(this string intput) // entscheidend: 'this' string
        {
            return int.TryParse(intput, out _);
        }
    }
}
