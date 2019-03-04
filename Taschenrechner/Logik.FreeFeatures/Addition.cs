using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logik.FreeFeatures
{
    public class Addition : IRechenoperation
    {
        public string Operator => "+";
        public int Berechne(int zahl1, int zahl2) => zahl1 + zahl2;
    }
}
