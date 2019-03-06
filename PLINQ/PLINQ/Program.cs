using AutoFixture;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
          
            Fixture fix = new Fixture();
            Console.WriteLine("Testdaten generieren ....");
            ConcurrentBag<Person> personen = new ConcurrentBag<Person>();

            Parallel.For(0, 300_000, i =>
             {
                 personen.Add(fix.Create<Person>());
             });

            Console.WriteLine("Testdaten generiert !");

            // Alle Personen mit Geburtsdatum < 1980 && negativem kontostand
            DateTime filter = new DateTime(2019, 1, 1, 0, 0,0);
            Stopwatch watch = new Stopwatch();

            personen.Add(null); // Wirft bei x.Geburtsdatum

            watch.Start();
            var query = personen.AsParallel()
                                   .WithDegreeOfParallelism(2)
                                   .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                                   .Where(x => x.Geburtsdatum < filter)
                                   .OrderByDescending(x => x.Kontostand);

            Person[] ergebnis = null;
            try
            {
                ergebnis = query.ToArray();
            }
            catch (AggregateException ex)
            {
                foreach (var x in ex.InnerExceptions)
                {
                    // Handle
                }
            }
            watch.Stop();
            Console.WriteLine($"Parallel: {ergebnis.Length} Personen in {watch.ElapsedMilliseconds}ms");

            watch.Restart();
            ergebnis = personen.Where(x => x.Geburtsdatum < filter)
                               .OrderByDescending(x => x.Kontostand)
                               .ToArray();
            watch.Stop();
            Console.WriteLine($"Ohne Parallel: {ergebnis.Count()} Personen in {watch.ElapsedMilliseconds}ms");

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
