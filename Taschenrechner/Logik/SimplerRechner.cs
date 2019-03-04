using Domain;
using System;

namespace Logik
{
    public class SimplerRechner : IRechner
    {
        public int Berechne(Formel formel)
        {
            if (formel.Operator == "+")
                return formel.Operand1 + formel.Operand2;
            else if (formel.Operator == "-")
                return formel.Operand1 - formel.Operand2;

            throw new ArgumentException("Operator unbekannt");
        }
    }
}
