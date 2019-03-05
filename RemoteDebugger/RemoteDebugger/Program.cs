using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RemoteDebugger
{
    class Program
    {
        static void Main(string[] args)
        {
            // Remote Tools installieren
            // https://visualstudio.microsoft.com/downloads/?q=remote+tools#remote-tools-for-visual-studio-2017

            for (int i = 0; i < 1000; i++)
            {
                Thread.Sleep(250);
                Console.WriteLine($"Wert ist {i}");
                Trace.WriteLine($"Aktueller Wert ist {i}");
            }

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
