using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIFAvilagranglista
{
    internal class Valogatott
    {
        public string Csapat { get; set; }
        public int Helyezes { get; set; }
        public int Valtozas { get; set; }
        public int Pontszam { get; set; }

        public Valogatott(string Csapat, int Helyezes, int Valtozas, int Pontszam)
        {
            this.Csapat = Csapat;
            this.Helyezes = Helyezes;
            this.Valtozas = Valtozas;
            this.Pontszam = Pontszam;
        }
    }
}
