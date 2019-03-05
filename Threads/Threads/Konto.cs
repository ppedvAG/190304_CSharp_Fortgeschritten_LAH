using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threads
{
    class Konto
    {
        private readonly object lock_object = new object();
        private static int buchungsnummer = 0;
        public Konto(decimal kontostand)
        {
            Kontostand = kontostand;
        }
        public decimal Kontostand { get; private set; }

        public void Abheben(decimal betrag)
        {
            if (Kontostand >= betrag)
            {
                lock (lock_object)
                {
                    buchungsnummer++;
                    Console.WriteLine($"[{buchungsnummer}]Kontostand vor dem Abheben:\t\t{Kontostand}");
                    Console.WriteLine($"[{buchungsnummer}]Betrag zum Abheben:\t\t\t{betrag}");
                    Kontostand -= betrag;
                    Console.WriteLine($"[{buchungsnummer}]Kontostand nach dem Abheben:\t\t{Kontostand}");
                }
            }
        }

        public void Einzahlen(decimal betrag)
        {
            lock (lock_object)
            {
                buchungsnummer++;
                Console.WriteLine($"[{buchungsnummer}]Kontostand vor dem Einzahlen:\t\t{Kontostand}");
                Console.WriteLine($"[{buchungsnummer}]Betrag zum Einzahlen:\t\t\t{betrag}");
                Kontostand += betrag;
                Console.WriteLine($"[{buchungsnummer}]Kontostand nach dem Einzahlen:\t\t{Kontostand}");
            }
        }

    }
}
