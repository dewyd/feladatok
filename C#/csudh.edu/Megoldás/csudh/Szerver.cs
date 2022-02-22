using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csudh
{
    internal class Szerver
    {
        public string Domain { get; set; }
        public string IP { get; set; }

        public Szerver(string Domain, string IP)
        {
            this.Domain = Domain;
            this.IP = IP;
        }
    }
}
