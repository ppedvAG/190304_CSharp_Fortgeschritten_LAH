using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner
{
    class Program
    {
        static void Main(string[] args)
        {
            // Variante "schlecht"

            Console.WriteLine("Bitte geben Sie Ihre Formel ein:");
            string eingabe = Console.ReadLine(); // "2 + 2"

            string[] teile = eingabe.Split();

            int zahl1 = Convert.ToInt32(teile[0]);
            string op = teile[1];
            int zahl2 = Convert.ToInt32(teile[2]);

            int erg = 0;
            if (op == "+")
                erg = zahl1 + zahl2;
            else if (op == "-")
                erg = zahl1 - zahl2;

            Console.WriteLine($"Das Ergebnis ist {erg}");

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
