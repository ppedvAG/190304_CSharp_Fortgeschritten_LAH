using Domain;
using System;
using System.Linq;

namespace Logik
{
    public class ModularerRechner : IRechner
    {
        public ModularerRechner(params IRechenoperation[] rechenoperationen)
        {
            this.rechenoperationen = rechenoperationen;
        }
        private readonly IRechenoperation[] rechenoperationen;

        public int Berechne(Formel formel)
        {
            var op = rechenoperationen.FirstOrDefault(x => x.Operator == formel.Operator);
            if (op != null)
                return op.Berechne(formel.Operand1, formel.Operand2);

            throw new InvalidOperationException("Operator unbekannt");
        }
    }
}
