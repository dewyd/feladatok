using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hianyzasok
{
    internal class Tanulo
    {
        public string Nev { get; set; }
        public string Osztaly { get; set; }
        public int ElsoNap { get; set; }
        public int UtolsoNap { get; set; }
        public int MulasztottOrak { get; set; }

        public Tanulo(string Nev, string Osztaly, int ElsoNap, int UtolsoNap, int MulasztottOrak)
        {
            this.Nev = Nev;
            this.Osztaly = Osztaly;
            this.ElsoNap = ElsoNap;
            this.UtolsoNap = UtolsoNap;
            this.MulasztottOrak = MulasztottOrak;
        }
    }
}
