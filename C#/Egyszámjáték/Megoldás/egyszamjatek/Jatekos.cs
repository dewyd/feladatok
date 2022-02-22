using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace egyszamjatek
{
    internal class Jatekos
    {
        public int[] Fordulo { get; set; }
        public string Nev { get; set; }

        public Jatekos(int[] Fordulo, string Nev)
        {
            this.Fordulo = Fordulo;
            this.Nev = Nev;
        }
    }
}

