using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbradio
{
    internal class Bejegyzes
    {
        public int Ora { get; set; }
        public int Perc { get; set; }
        public int AdasDb { get; set; }
        public string Nev { get; set; }

        public Bejegyzes(int Ora, int Perc, int AdasDb, string Nev)
        {
            this.Ora = Ora;
            this.Perc = Perc;
            this.AdasDb = AdasDb;
            this.Nev = Nev;
        }
    }
}
