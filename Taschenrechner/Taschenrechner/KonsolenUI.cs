using Domain;
using System;
using System.Text;

namespace Taschenrechner
{
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
