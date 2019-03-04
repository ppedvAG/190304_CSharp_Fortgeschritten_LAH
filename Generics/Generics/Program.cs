using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            #region ObjectStack
            //ObjectStack os = new ObjectStack();

            //os.Push(12);
            //os.Push("Hallo Welt");
            //os.Push(12.77777);
            //os.Push(true);
            //os.Push(new StringBuilder().Append("Neuer string"));


            //Console.WriteLine(os.Pop());
            //Console.WriteLine(os.Pop());
            //Console.WriteLine(os.Pop());
            //Console.WriteLine(os.Pop());

            //var element = (Int32)os.Pop();

            //Console.WriteLine(element * 2); 
            #endregion

            #region GenericStack
            //GenericStack<int> intStack = new GenericStack<int>();

            //intStack.Push(12);
            //intStack.Push(7);
            //intStack.Push(3);

            //Console.WriteLine(intStack.Pop() * 3);
            //Console.WriteLine(intStack.Pop() * 3);
            //Console.WriteLine(intStack.Pop() * 3);

            //MachEtwas(12);
            //MachEtwas("Demo"); 
            #endregion

            GenericStack<string> gs = new GenericStack<string>();
            gs.Push("Hallo");
            gs.Push("Welt");
            gs.Push("!");

            Console.WriteLine(gs[0]);

            string text = "123";
            if(text.IsNumeric())
            {
                Console.WriteLine("Es ist ein Int");
            }

            Person p = new Person { Vorname = "Tom", Nachname = "Ate", Alter = 10, Kontostand = 100m };

            var alles = p.GibAllesAus();

            string vorname, nachname;
            (vorname, nachname, _ , _) = p.GibAllesAus(); // _ verwirft nicht benötigte Werte

            #region Suffix für Wertetypen
            //// Suffix:
            //// L ->  Long
            //// M ->  Decimal
            //// F ->  Float
            //// U ->  UInt32
            //// UL -> UInt64

            //var suffix = 12m;
            //decimal kontostand = 12.5m;
            //float wert = 12.5F;

            //var uns = 12UL; 
            #endregion

            for (int i = 0; i < 10_000_000; i++)
            {


            }

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }

        //static void MachEtwas<T>(T input) where T : class
        //{
        //    Console.WriteLine($"Ich mache etwas mit {input}");
        //}
    }


    class Person
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public byte Alter { get; set; }
        public decimal Kontostand { get; set; }

        public (string vn, string nn, byte a, decimal k) GibAllesAus()
        {
            return (Vorname, Nachname, Alter, Kontostand);
        }
    }
}
