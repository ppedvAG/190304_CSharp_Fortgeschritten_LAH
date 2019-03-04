using Domain;
using Logik;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Taschenrechner
{
    class Program
    {
        // Bootstrapping
        static void Main(string[] args)
        {
            // 1) Alles laden
            foreach (var file in Directory.GetFiles(Path.Combine(Environment.CurrentDirectory, "AddIns")))
            {
                if ((Path.GetExtension(file) == ".dll" || Path.GetExtension(file) == ".dll") &&
                    Path.GetFileName(file).StartsWith("Logik."))
                    Assembly.LoadFrom(file);
            }

            // 2) 
            var alles = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                                                                .Where(x => typeof(IRechenoperation).IsAssignableFrom(x) &&
                                                                            x.IsInterface == false && x.IsAbstract == false)
                                                                .Select(x => (IRechenoperation)Activator.CreateInstance(x))
                                                                .ToArray();
            var rechner = new ModularerRechner(alles);
            var parser = new RegexParser();
            new KonsolenUI(parser, rechner).Start();
        }
    }
}
