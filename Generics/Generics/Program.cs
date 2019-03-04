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


            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }

        //static void MachEtwas<T>(T input) where T : class
        //{
        //    Console.WriteLine($"Ich mache etwas mit {input}");
        //}
    }
}
