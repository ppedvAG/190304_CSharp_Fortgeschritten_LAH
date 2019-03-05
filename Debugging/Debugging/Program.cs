using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Debugging
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hallo Debugger");

            //Trace.Listeners.Add(new TextWriterTraceListener("log.txt"));
            //Trace.Listeners.Add(new EventLogTraceListener("Application"));

            // Für die AppConfig:
            // https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.defaulttracelistener?view=netframework-4.7.2

            // TracePoint: Breakpoint -> Rechtsklick -> Action

            //Trace.AutoFlush = true;
            //for (int i = 0; i < 100; i++)
            //{
            //    Trace.WriteLine($"Wir sind am Ende - {i}");
            //    Console.WriteLine(i);
            //}

            //List<Person> personen = new List<Person>();
            //FüllePersonen(personen);

            var ding = new GroßesDingImGC();

            Console.WriteLine(GC.GetGeneration(ding));
            Console.WriteLine(GC.GetGeneration(ding.KleinerString));
            Console.WriteLine(GC.GetGeneration(ding.GroßesDingFürDenLOH));

            ding = null;
            
            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }

        private static void FüllePersonen(List<Person> personen)
        {
            // MacheBlödsinn();
            Random r = new Random();
            for (int i = 0; i < 10_000; i++)
            {
                if (i == 250)
                    GC.Collect();
                if (i == 750)
                    GC.Collect();
                personen.Add(new Person { Vorname = "Tom", Nachname = "Ate", Alter = 10, Kontostand = r.Next(1, 1000) });
            }
        }

        private static void MacheBlödsinn()
        {
            for (int i = 0; i < 1000; i++)
            {
                Thread.Sleep(10);
                Console.WriteLine("Bullshitoperation :)");
            }
        }
    }

    class GroßesDingImGC
    {
        public string KleinerString = "sehr kleiner wert => SmallObjectHeap";
        public byte[] GroßesDingFürDenLOH = new byte[100_000]; // 85k Limit, ab da laut Doku im LOH 

        ~GroßesDingImGC()
        {
            Console.WriteLine("Ich bin mal weg ...");
        }
    }
}
