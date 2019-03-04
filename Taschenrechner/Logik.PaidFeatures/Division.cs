using Domain;

namespace Logik.PaidFeatures
{
    public class Division : IRechenoperation
    {
        public string Operator => "/";

        public int Berechne(int zahl1, int zahl2) => zahl1 / zahl2;
    }
}
