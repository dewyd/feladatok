using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snooker
{
    internal class Versenyzo
    {
        public string Helyezes { get; set; }
        public string Nev { get; set; }
        public string Orszag { get; set; }
        public int Nyeremeny { get; set; }

        public Versenyzo(string Helyezes, string Nev, string Orszag, int Nyeremeny)
        {
            this.Helyezes = Helyezes;
            this.Nev = Nev;
            this.Orszag = Orszag;
            this.Nyeremeny = Nyeremeny;
        }
    }
}
