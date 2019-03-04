using Domain;

namespace Logik.FreeFeatures
{
    public class Subtraktion : IRechenoperation
    {
        public string Operator => "-";
        public int Berechne(int zahl1, int zahl2) => zahl1 - zahl2;
    }
}
