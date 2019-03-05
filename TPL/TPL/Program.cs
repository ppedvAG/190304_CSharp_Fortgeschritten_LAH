using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPL
{
    class Program
    {
        static void Main(string[] args)
        {
            // Unterschied Task.Factory.Startnew(Action) und Tast.Run(Action):
            // https://devblogs.microsoft.com/pfxteam/task-run-vs-task-factory-startnew/

            //CancellationTokenSource cts = new CancellationTokenSource();
            //var t1 = Task.Factory.StartNew(() => { MachWas(cts.Token); },cts.Token);
            //t1.ContinueWith(UndMachNochMehrDanach);

            //Thread.Sleep(2000);
            //cts.Cancel();


            // Parallel.For


            int[] durchgänge = { 1_000, 10_000, 50_000, 100_000, 250_000, 500_000, 1_000_000, 5_000_000, 10_000_000,20_000_000,50_000_000 };
            Stopwatch watch = new Stopwatch();

            for (int i = 0; i < durchgänge.Length; i++)
            {
                Console.WriteLine($"--- Durchgang {durchgänge[i]} ---");
                watch.Restart();
                ParallelTest(durchgänge[i]);
                watch.Stop();
                Console.WriteLine($"Parallel: {watch.ElapsedMilliseconds}ms");

                watch.Restart();
                ForTest(durchgänge[i]);
                watch.Stop();
                Console.WriteLine($"For: {watch.ElapsedMilliseconds}ms");
            }

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }

        private static void ParallelTest(int durchgänge)
        {
            double[] werte = new double[durchgänge];
            // new ParallelOptions { MaxDegreeOfParallelism = 2 }
            Parallel.For(0, durchgänge, i =>
             {
                werte[i] = (Math.Pow(i, 0.33333) * Math.Sqrt(Math.Sin(123 * i))) / Math.PI;
             });
        }
        private static void ForTest(int durchgänge)
        {
            double[] werte = new double[durchgänge];
            for (int i = 0; i < durchgänge; i++)
            {
                werte[i] = (Math.Pow(i, 0.33333) * Math.Sqrt(Math.Sin(123 * i))) / Math.PI;
            }
        }




        private static void MachWas(CancellationToken token)
        {
            for (int i = 0; i < 1000; i++)
            {
                //if (token.IsCancellationRequested)
                //    break;
                token.ThrowIfCancellationRequested();
                //if (i == 5)
                //    throw new DivideByZeroException();
                Console.Write('#');
                Thread.Sleep(100);
            }
        }
        private static void UndMachNochMehrDanach(Task obj)
        {
            Console.WriteLine($"Wurde der Task abgebrochen? {obj.IsCanceled}");
            Console.WriteLine($"Gab es einen Fehler ? {obj.IsFaulted}");
            if(obj.IsFaulted)
                Console.WriteLine($"Exception:{obj.Exception.Message}");

            Console.WriteLine("---Aufräumen---");
        }
    }
}
