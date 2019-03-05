using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    class Program
    {
        static void Main(string[] args)
        {
            var konto = new Konto(1000);
            for (int i = 0; i < 10; i++)
                ThreadPool.QueueUserWorkItem(ZufälligesKontoUpdate, konto);

            #region Mutex
            //Mutex mutex = new Mutex(false, "MeinMutex");
            //for (int i = 0; i < 100; i++)
            //{
            //    mutex.WaitOne();

            //    Thread.Sleep(100);
            //    Console.WriteLine(i);

            //    mutex.ReleaseMutex();
            //} 
            #endregion


            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }

        private static void ZufälligesKontoUpdate(object state)
        {
            var konto = (Konto)state;
            var r = new Random();
            for (int i = 0; i < 100; i++)
            {
                var betrag = r.Next(1, 100);
                if (r.NextDouble() < 0.5)
                    konto.Einzahlen(betrag);
                else
                    konto.Abheben(betrag);
            }

        }
    }
}
