using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logik.PaidFeatures
{
    public class Multiplikation : IRechenoperation
    {
        public string Operator => "*";

        public int Berechne(int zahl1, int zahl2) => zahl1 * zahl2;
    }
}
