using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AutoVerseny
{
    internal class Program
    {
        static List<Versenyzo> Korok = new List<Versenyzo>();

        static void Main(string[] args)
        {
            #region Feladatok
            Feladat2();
            Console.WriteLine("3. feladat: {0}", Korok.Count);
            Console.WriteLine("4. feladat: {0} másodperc", Feladat4());
            Console.WriteLine("5. feladat");
            Console.WriteLine("Kérem egy versenyző nevét: ");
            string Nev = Console.ReadLine();
            Console.WriteLine("6. feladat: {0}", Feladat6(Nev));
            #endregion

            Console.ReadKey();
        }

        #region 2. Feladat
        static void Feladat2()
        {
            FileStream fs = new FileStream("autoverseny.csv", FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            string s = sr.ReadLine();
            while (!sr.EndOfStream)
            {
                s = sr.ReadLine();
                string[] p1 = s.Split(';');
                string[] p2 = p1[4].Split(':');
                Versenyzo v = new Versenyzo(p1[0], p1[1], Convert.ToInt32(p1[2]), p1[3], Convert.ToInt32(p2[0]), Convert.ToInt32(p2[1]), Convert.ToInt32(p2[2]), Convert.ToInt32(p1[5]));
                Korok.Add(v);
            }
            fs.Close();
            sr.Close();
        }
        #endregion

        #region 4. Feladat
        static int Feladat4()
        {
            int mp = 0;
            foreach (Versenyzo v in Korok)
            {
                if (v.Nev == "Fürge Ferenc" && v.Palya == "Gran Prix Circuit" && v.Kor == 3) { mp += (v.Korido[0] * 60) * 60; mp += v.Korido[1] * 60; mp += v.Korido[2]; }
            }
            return mp;
        }
        #endregion

        #region 6. Feladat
        static string Feladat6(string Nev)
        {
            bool van = false;
            string Kor = ""; int min = 99999;
            foreach (Versenyzo v in Korok)
            {
                if (v.Nev == Nev)
                {
                    van = true;
                    int mp = (v.Korido[0] * 60) * 60;
                    mp += v.Korido[1] * 60;
                    mp += v.Korido[2];
                    if (mp < min) { min = mp; Kor = String.Format("{0}, {1}:{2}:{3}", v.Palya, v.Korido[0], v.Korido[1], v.Korido[2]); }
                }
            }
            if (van) { return Kor; }
            else { return "Nincs ilyen versenyző az állományban!"; }
        }
        #endregion
    }
}
