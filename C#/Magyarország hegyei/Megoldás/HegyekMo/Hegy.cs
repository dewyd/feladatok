using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HegyekMo
{
    internal class Hegy
    {
        public string Hegycsucs { get; set; }
        public string Hegyseg { get; set; }
        public int Magassag { get; set; }

        public Hegy(string Hegycsucs, string Hegyseg, int Magassag)
        {
            this.Hegycsucs = Hegycsucs;
            this.Hegyseg = Hegyseg;
            this.Magassag = Magassag;
        }
    }
}