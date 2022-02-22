using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hianyzasok
{
    internal class Program
    {
        static List<Tanulo> Hianyzasok = new List<Tanulo>();

        static void Main(string[] args)
        {
            #region Feladatok
            Feladat1();
            Console.WriteLine("2. feladat");
            Console.WriteLine("\tÖsszes mulasztott órák száma: {0} óra.", Feladat2());
            Console.WriteLine("3. feladat"); int Nap = 0;
            try
            {
                do
                {
                    Console.Write("\tKérem adjon meg egy napot: ");
                    Nap = Convert.ToInt32(Console.ReadLine());
                } while (Nap < 1 || Nap > 30);
            }
            catch (Exception) { }
            Console.Write("\tTanuló neve: ");
            string Nev = Console.ReadLine();
            Console.WriteLine("4. feladat");
            Console.WriteLine("\t{0}", Feladat4(Nev));
            Console.WriteLine("5. feladat: Hiányzók 2017.09.{0}-n:", Nap);
            Feladat5(Nap);
            Feladat6();
            #endregion

            Console.ReadKey();
        }

        #region 1. Feladat
        static void Feladat1()
        {
            FileStream fs = new FileStream("szeptember.csv", FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            string s = sr.ReadLine();
            while (!sr.EndOfStream)
            {
                s = sr.ReadLine();
                string[] p = s.Split(';');
                Tanulo t = new Tanulo(p[0], p[1], Convert.ToInt32(p[2]), Convert.ToInt32(p[3]), Convert.ToInt32(p[4]));
                Hianyzasok.Add(t);
            }
            fs.Close();
            sr.Close();
        }
        #endregion

        #region 2. Feladat
        static int Feladat2()
        {
            int sum = 0;
            foreach (Tanulo t in Hianyzasok) { sum += t.MulasztottOrak; }
            return sum;
        }
        #endregion

        #region 4. Feladat
        static string Feladat4(string Nev)
        {
            bool volt = false;
            foreach (Tanulo t in Hianyzasok)
            {
                if (t.Nev == Nev) { volt = true; break; }
            }
            if (volt) { return "A tanuló hiányzott szeptemberben"; }
            else { return "A tanuló nem hiányzott szeptemberben"; }
        }
        #endregion

        #region 5. Feladat
        static void Feladat5(int Nap)
        {
            bool volt = false;
            List<string> Nevek = new List<string>();
            foreach (Tanulo t in Hianyzasok) { if (t.ElsoNap >= Nap && t.UtolsoNap <= Nap) { volt = true; Nevek.Add(String.Format("{0} ({1})", t.Nev, t.Osztaly)); } }
            for (int i = 0; i < Nevek.Count; i++) { Console.WriteLine("\t{0}", Nevek[i]); }
            if (!volt) { Console.WriteLine("\tNem volt hiányzó"); }
        }
        #endregion

        #region 6. Feladat
        static void Feladat6()
        {
            List<string> Osztalyok = new List<string>();
            foreach (Tanulo t in Hianyzasok) { if (!Osztalyok.Contains(t.Osztaly)) { Osztalyok.Add(t.Osztaly); } }
            int[] MulasztottOrak = new int[Osztalyok.Count];

            foreach (Tanulo t in Hianyzasok)
            {
                for (int i = 0; i < MulasztottOrak.Length; i++) { if (t.Osztaly == Osztalyok[i]) { MulasztottOrak[i] += t.MulasztottOrak; break; } }
            }

            StreamWriter sw = new StreamWriter("osszesites.csv");
            for (int i = 0; i < Osztalyok.Count; i++)
            {
                sw.WriteLine("{0};{1}", Osztalyok[i], MulasztottOrak[i]);
            }
            sw.Close();
        }
        #endregion

    }
}
