using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatenUndEvents
{
    class Program
    {
        public delegate void MeinDelegat(); // wichtig: rückgabetyp und parameter
        public delegate void MeinDelegat2(int x); // wichtig: rückgabetyp und parameter
        static void Main(string[] args)
        {
            #region Delegat
            //MeinDelegat del = new MeinDelegat(A);
            //del += B; // Invocation-List 
            //// del += C
            //del.Invoke();

            //MeinDelegat2 del2 = C;
            //del2.Invoke(12); 
            #endregion

            #region Action<T>, Func<T>, EventHandler<T>
            //// Action<T> -> für alles ohne Rückgabe (void)
            //// Func<T> -> für alles mit Rückgabe
            //// => bis zu 16 Parameter unterstützen

            //// Action a1 = () => Console.WriteLine("Meine anonyme Logik");
            //// a1.Invoke();

            //// EventHandler => (object sender, EventArgs e)

            ////Func<int, int, int> rechner = (z1, z2) => z1 + z2;
            ////var erg = rechner(55, 99);
            ////Console.WriteLine(erg);

            ////if (rechner != null)
            ////    rechner(12, 3);

            ////rechner?.Invoke(12, 3); 
            #endregion

            Button b = new Button();
            b.ButtonClickEvent += MeinButton_Click;
            b.ButtonClickEvent += Logger;

            b.Klick();

            // b.ButtonClickEvent = null;              // absolut verboten

            b.Klick();
            b.Klick();

            b.ButtonClickEvent -= Logger;

            b.Klick();
            b.Klick();

            // b.ButtonClickEvent?.Invoke(null, null); // verboten

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }

        private static void Logger(object sender, EventArgs e)
        {
            Console.WriteLine($"[{DateTime.Now.ToLongTimeString()}]: Button wurde geklickt");
            throw new Exception();
        }

        private static void MeinButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("*Klick*");
            Console.Beep();
        }

        public static void A() => Console.WriteLine("A");
        public static void B() => Console.WriteLine("B");
        public static void C(int zahl) => Console.WriteLine($"C {zahl}");

    }
}
