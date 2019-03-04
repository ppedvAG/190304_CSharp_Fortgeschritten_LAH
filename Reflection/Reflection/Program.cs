using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            int zahl = 42;

            Type intType = zahl.GetType();
            Console.WriteLine(intType);

            var instanz = Activator.CreateInstance(intType);

            Console.WriteLine(instanz);
            Console.WriteLine(instanz.GetType());

            Console.WriteLine("------------------------");
            Assembly taschenrechnerAssembly = Assembly.LoadFrom("MeineLib.dll");
            Type taschenrechnerType = taschenrechnerAssembly.GetType("MeineLib.Taschenrechner"); // Variante 1: Wir kennen den Name

            // taschenrechnerType.GetConstructor
            var taschenrechnerInstanz = Activator.CreateInstance(taschenrechnerType);

            MethodInfo methodenInfo = taschenrechnerType.GetRuntimeMethod("Add", new Type[] { typeof(int), typeof(int) });
            var erg = methodenInfo.Invoke(taschenrechnerInstanz, new object[] { 12, 5 });

            Console.WriteLine(erg);

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
