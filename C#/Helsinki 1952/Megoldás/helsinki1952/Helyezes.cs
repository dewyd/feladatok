using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helsinki1952
{
    internal class Helyezes
    {
        public int Elert { get; set; }
        public int SportolokSzama { get; set; }
        public string SportAg { get; set; }
        public string VersenySzam { get; set; }

        public Helyezes(int Elert, int SportolokSzama, string SportAg, string VersenySzam)
        {
            this.Elert = Elert;
            this.SportolokSzama = SportolokSzama;
            this.SportAg = SportAg;
            this.VersenySzam = VersenySzam;
        }
    }
}
