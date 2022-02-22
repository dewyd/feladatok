using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace helsinki1952
{
    internal class Program
    {
        static List<Helyezes> Helyezesek = new List<Helyezes>();

        static void Main(string[] args)
        {
            #region Feladatok
            Feladat2();
            Console.WriteLine("3. feladat:");
            Console.WriteLine("Pontszerző helyezések száma: {0}", Helyezesek.Count);
            Console.WriteLine("4. feladat:");
            Feladat4();
            Console.WriteLine("5. feladat:");
            Console.WriteLine("Olimpiai pontok száma: {0}", Feladat5());
            Console.WriteLine("6. feladat:");
            Console.WriteLine("{0}", Feladat6());
            Feladat7();
            Console.WriteLine("8. feladat:");
            Feladat8();
            #endregion

            Console.ReadKey();
        }

        #region 2. Feladat
        static void Feladat2()
        {
            FileStream fs = new FileStream("helsinki.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            while (!sr.EndOfStream)
            {
                string s = sr.ReadLine();
                string[] p = s.Split(' ');
                Helyezes h = new Helyezes(Convert.ToInt32(p[0]), Convert.ToInt32(p[1]), p[2], p[3]);
                Helyezesek.Add(h);
            }
            fs.Close();
            sr.Close();
        }
        #endregion

        #region 4. Feladat
        static void Feladat4()
        {
            int[] Ermek = new int[3];
            foreach (Helyezes h in Helyezesek)
            {
                switch (h.Elert)
                {
                    case 1: Ermek[0]++; break;
                    case 2: Ermek[1]++; break;
                    case 3: Ermek[2]++; break;
                }
            }

            Console.WriteLine("Arany: {0}\r\nEzüst: {1}\r\nBronz: {2}", Ermek[0], Ermek[1], Ermek[2]);
            Console.WriteLine("Összesen: {0}", Ermek[0] + Ermek[1] + Ermek[2]);
        }
        #endregion

        #region 5. Feladat
        static int Feladat5()
        {
            int pontszam = 0;
            foreach (Helyezes h in Helyezesek)
            {
                switch (h.Elert)
                {
                    case 1: pontszam += 7; break;
                    case 2: pontszam += 5; break;
                    case 3: pontszam += 4; break;
                    case 4: pontszam += 3; break;
                    case 5: pontszam += 2; break;
                    case 6: pontszam += 1; break;
                }
            }
            return pontszam;
        }
        #endregion

        #region 6. Feladat
        static string Feladat6()
        {
            int[] Ermek = new int[2];
            foreach (Helyezes h in Helyezesek)
            {
                switch (h.SportAg)
                {
                    case "uszas": Ermek[0]++; break;
                    case "torna": Ermek[1]++; break;
                }
            }

            if (Ermek[0] > Ermek[1]) { return "Úszás sportágban szereztek több érmet"; }
            else { return "Torna sportágban szereztek több érmet"; }
        }
        #endregion

        #region 7. Feladat
        static void Feladat7()
        {
            StreamWriter sw = new StreamWriter("helsinki2.txt");
            foreach (Helyezes h in Helyezesek)
            {
                sw.Write("{0} {1} ", h.Elert, h.SportolokSzama);
                if (h.SportAg == "kajakkenu") { sw.Write("kajak-kenu"); }
                else { sw.Write("{0}", h.SportAg); }
                sw.Write(" {0}\r\n", h.VersenySzam);
            }
            sw.Close();
        }
        #endregion

        #region 8. Feladat
        static void Feladat8()
        {
            Helyezes max = new Helyezes(0, 0, "", "");
            foreach (Helyezes h in Helyezesek) { if (h.SportolokSzama > max.SportolokSzama) { max = h; } }
            Console.WriteLine("Helyezés: {0}", max.Elert);
            Console.WriteLine("Sportág: {0}", max.SportAg);
            Console.WriteLine("Versenyszám: {0}", max.VersenySzam);
            Console.WriteLine("Sportolók száma: {0}", max.SportolokSzama);
        }
        #endregion
    }
}
