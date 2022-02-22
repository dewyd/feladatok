using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lift
{
    internal class Hasznalat
    {
        public int Ev { get; set; }
        public int Honap { get; set; }
        public int Nap { get; set; }
        public int Sorszam { get; set; }
        public int InduloSzint { get; set; }
        public int CelSzint { get; set; }

        public Hasznalat(int Ev, int Honap, int Nap, int Sorszam, int InduloSzint, int CelSzint)
        {
            this.Ev = Ev;
            this.Honap = Honap;
            this.Nap = Nap;
            this.Sorszam = Sorszam;
            this.InduloSzint = InduloSzint;
            this.CelSzint = CelSzint;
        }
    }
}
