using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vb2018
{
    internal class Helyszin
    {
        public string Varos { get; set; }
        public string Nev1 { get; set; }
        public string Nev2 { get; set; }
        public int Ferohely { get; set; }

        public Helyszin(string Varos, string Nev1, string Nev2, int Ferohely)
        {
            this.Varos = Varos;
            this.Nev1 = Nev1;
            this.Nev2 = Nev2;
            this.Ferohely = Ferohely;
        }
    }
}
