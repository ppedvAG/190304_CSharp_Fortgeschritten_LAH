using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public struct Formel
    {
        public Formel(int Operand1, int Operand2, string Operator) : this()
        {
            this.Operand1 = Operand1;
            this.Operand2 = Operand2;
            this.Operator = Operator;
        }

        public int Operand1 { get; set; }
        public int Operand2 { get; set; }
        public string Operator { get; set; }
    }
}
