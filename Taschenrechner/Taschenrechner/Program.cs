using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Taschenrechner
{
    class Program
    {
        // Bootstrapping
        static void Main(string[] args)
        {
            var parser = new RegexParser();
            var rechner = new ModularerRechner(new Addition(), new Subtraktion());
            new KonsolenUI(parser,rechner).Start();
        }
    }

    struct Formel
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

    interface IParser
    {
        Formel Parse(string input);
    }
    class StringSplitParser : IParser
    {
        public Formel Parse(string input)
        {
            string[] teile = input.Split();
            int zahl1 = Convert.ToInt32(teile[0]);
            string op = teile[1];
            int zahl2 = Convert.ToInt32(teile[2]);

            return new Formel(zahl1, zahl2, op);
        }
    }
    class RegexParser : IParser
    {
        public Formel Parse(string input)
        {
            Regex regex = new Regex(@"(\d+)\s*(\D)\s*(\d+)");
            var result = regex.Match(input);
            if(result.Success)
            {
                int op1 = Convert.ToInt32(result.Groups[1].Value);
                string op = result.Groups[2].Value;
                int op2 = Convert.ToInt32(result.Groups[3].Value);

                return new Formel(op1,op2,op);
            }
            throw new FormatException("Ungültiges Formelformat");
        }
    }

    interface IRechner
    {
        int Berechne(Formel formel);
    }
    class SimplerRechner : IRechner
    {
        public int Berechne(Formel formel)
        {
            if (formel.Operator == "+")
                return formel.Operand1 + formel.Operand2;
            else if (formel.Operator ==  "-")
                return formel.Operand1 - formel.Operand2;

            throw new ArgumentException("Operator unbekannt");
        }
    }

    interface IRechenoperation
    {
        string Operator { get; }
        int Berechne(int zahl1, int zahl2);
    }
    class Addition : IRechenoperation
    {
        public string Operator => "+";
        public int Berechne(int zahl1, int zahl2) => zahl1 + zahl2;
    }
    class Subtraktion : IRechenoperation
    {
        public string Operator => "-";
        public int Berechne(int zahl1, int zahl2) => zahl1 - zahl2;
    }

    class ModularerRechner : IRechner
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
    class KonsolenUI
    {
        public KonsolenUI(IParser parser, IRechner rechner)
        {
            this.parser = parser;
            this.rechner = rechner;
        }
        private readonly IParser parser;
        private readonly IRechner rechner;

        public void Start()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine("Bitte geben Sie Ihre Formel ein:"); // UI
            string eingabe = Console.ReadLine(); // UI

            Formel formel = parser.Parse(eingabe);
            int erg = rechner.Berechne(formel);

            Console.WriteLine($"Das Ergebnis ist {erg}"); // UI

            Console.WriteLine("---😘😘😘ENDE😘😘😘---");
            Console.ReadKey();
        }
    }
}
