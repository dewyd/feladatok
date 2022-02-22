using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVerseny
{
    internal class Versenyzo
    {
        public string Csapat { get; set; }
        public string Nev { get; set; }
        public int Eletkor { get; set; }
        public string Palya { get; set; }
        public int[] Korido { get; set; }
        public int Kor { get; set; }

        public Versenyzo(string Csapat, string Nev, int Eletkor, string Palya, int Korido1, int Korido2, int Korido3, int Kor)
        {
            this.Csapat = Csapat;
            this.Nev = Nev;
            this.Eletkor = Eletkor;
            this.Palya = Palya;
            this.Korido = new int[3];
            this.Korido[0] = Korido1;
            this.Korido[1] = Korido2;
            this.Korido[2] = Korido3;
            this.Kor = Kor;
        }
    }
}
