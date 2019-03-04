using Logik;
using Logik.FreeFeatures;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Taschenrechner
{
    class Program
    {
        // Bootstrapping
        static void Main(string[] args)
        {
            var parser = new RegexParser();
            var rechner = new ModularerRechner(new Addition(), new Subtraktion());
            new KonsolenUI(parser,rechner).Start();
        }
    }
}
