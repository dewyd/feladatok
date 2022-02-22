using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EU
{
    internal class Tagallam
    {
        public string Nev { get; set; }
        public int CsatEv { get; set; }
        public int CsatHonap { get; set; }
        public int CsatNap { get; set; }

        public Tagallam(string Nev, int CsatEv, int CsatHonap, int CsatNap)
        {
            this.Nev = Nev;
            this.CsatEv = CsatEv;
            this.CsatHonap = CsatHonap;
            this.CsatNap = CsatNap;
        }
    }
}
