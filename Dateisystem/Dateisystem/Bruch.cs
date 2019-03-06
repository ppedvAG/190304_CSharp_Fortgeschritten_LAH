using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dateisystem
{
    class Bruch : IComparable<Bruch>
    {
        public Bruch(int zähler, int nenner)
        {
            Zähler = zähler;
            Nenner = nenner;
        }

        public int Zähler { get; set; }
        public int Nenner { get; set; }


        // Überladbare Operatoren:
        // Arithmetisch:
        // +,-,*,/, %, ++, --
        // => +=, -= ... sind automatisch dabei
        // Bitweise:
        // &, |, ^ , <<, >> , ~
        // Vergleichsoperatoren:
        // ==, !=, <, >, <=, >=
        // => Müssen immer Paarweise überladen werden

        public static Bruch operator *(Bruch links, Bruch rechts)
        {
            return new Bruch(links.Zähler * rechts.Zähler, links.Nenner * rechts.Nenner);
        }

        public static bool operator <(Bruch links, Bruch rechts)
        {
            throw new NotImplementedException();
        }
        public static bool operator >(Bruch links, Bruch rechts)
        {
            throw new NotImplementedException();
        }
        public static bool operator <=(Bruch links, Bruch rechts)
        {
            throw new NotImplementedException();
        }
        public static bool operator >=(Bruch links, Bruch rechts)
        {
            throw new NotImplementedException();
        }
        public static bool operator ==(Bruch links, Bruch rechts)
        {
            throw new NotImplementedException();
        }
        public static bool operator !=(Bruch links, Bruch rechts)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(Bruch other)
        {
            if (this.Nenner > other.Nenner)
                return 1;
            else if (this.Nenner == other.Nenner)
            {

                if (this.Zähler > other.Zähler)
                    return 1;
                else if (this.Zähler == other.Zähler)
                    return 0; // identisch
                else
                    return -1;
            }
            else
                return -1;
        }

        public override bool Equals(object obj)
        {
            return this.GetHashCode() == obj.GetHashCode();
        }

        public override int GetHashCode()
        {
            return Zähler / Nenner;
        }
    }

    class Bruchvergleicher : IComparer<Bruch>
    {
        public int Compare(Bruch x, Bruch y)
        {
            throw new NotImplementedException();
        }
    }
}
