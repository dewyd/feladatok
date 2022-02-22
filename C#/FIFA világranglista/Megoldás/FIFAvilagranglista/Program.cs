using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FIFAvilagranglista
{
    internal class Program
    {
        static List<Valogatott> Ranglista = new List<Valogatott>();

        static void Main(string[] args)
        {
            #region Feladatok
            Feladat2();
            Console.WriteLine("3. feladat: A világranglistán {0} csapat szerepel", Ranglista.Count);
            Console.WriteLine("4. feladat: A csapatok átlagos pontszáma: {0:0.00} pont", Feladat4());
            Console.WriteLine("5. feladat: A legtöbbet javító csapat: ");
            Feladat5();
            Console.WriteLine("6. feladat: {0}", Feladat6());
            Console.WriteLine("7. feladat: Statisztika");
            Feladat7();
            #endregion

            Console.ReadKey();
        }

        #region 2. Feladat
        static void Feladat2()
        {
            FileStream fs = new FileStream("fifa.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            string s = sr.ReadLine();
            while (!sr.EndOfStream)
            {
                s = sr.ReadLine();
                string[] p = s.Split(';');
                Valogatott v = new Valogatott(p[0], Convert.ToInt32(p[1]), Convert.ToInt32(p[2]), Convert.ToInt32(p[3]));
                Ranglista.Add(v);
            }
            fs.Close();
            sr.Close();
        }
        #endregion

        #region 4. Feladat
        static float Feladat4()
        {
            float sum = 0;
            foreach (Valogatott v in Ranglista) { sum += v.Pontszam; }
            return sum / Ranglista.Count;
        }
        #endregion

        #region 5. Feladat
        static void Feladat5()
        {
            Valogatott legtobbet_javitott = new Valogatott("", 0, 0, 0);
            foreach (Valogatott v in Ranglista) { if (v.Valtozas > legtobbet_javitott.Valtozas) { legtobbet_javitott = v; } }

            Console.WriteLine("\tHelyezés: {0}", legtobbet_javitott.Helyezes);
            Console.WriteLine("\tCsapat: {0}", legtobbet_javitott.Csapat);
            Console.WriteLine("\tPontszám: {0}", legtobbet_javitott.Pontszam);
        }
        #endregion

        #region 6. Feladat
        static string Feladat6()
        {
            bool van = false;
            foreach (Valogatott v in Ranglista) { if (v.Csapat == "Magyarország") { van = true; break; } }
            if (van) { return "A csapatok között van Magyarország"; }
            else { return "A csapatok között nincs Magyarország"; }
        }
        #endregion

        #region 7. Feladat
        static void Feladat7()
        {
            List<int> Valtozasok = new List<int>();
            foreach (Valogatott v in Ranglista) { if (!Valtozasok.Contains(v.Valtozas)) { Valtozasok.Add(v.Valtozas); } }
            int[] ValtozasDb = new int[Valtozasok.Count];

            foreach (Valogatott v in Ranglista)
            {
                for (int i = 0; i < Valtozasok.Count; i++) { if (v.Valtozas == Valtozasok[i]) { ValtozasDb[i]++; break; } }
            }

            for (int i = 0; i < Valtozasok.Count; i++) { if (ValtozasDb[i] > 1) { Console.WriteLine("\t{0} helyet változott: {1} csapat", Valtozasok[i], ValtozasDb[i]); } }
        }
        #endregion
    }
}
