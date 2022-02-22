using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace cbradio
{
    internal class Program
    {
        static List<Bejegyzes> Naplo = new List<Bejegyzes>();
        static List<string> Nevek = new List<string>();

        static void Main(string[] args)
        {
            #region Feladatok
            Feladat2();
            Console.WriteLine("3. feladat: Bejegyzések száma: {0} db", Naplo.Count);
            Console.WriteLine("4. feladat: {0}", Feladat4());
            Console.Write("5. feladat: Kérek egy nevet: ");
            string Nev = Console.ReadLine();
            Console.WriteLine("\t{0}", Feladat5(Nev));
            Feladat7();
            Feladat8();
            Console.WriteLine("8. feladat: Sofőrök száma: {0} fő", Nevek.Count);
            Console.WriteLine("9. feladat: Legtöbb adást indító sofőr");
            Feladat9();
            #endregion

            Console.ReadKey();
        }

        #region 2. Feladat
        static void Feladat2()
        {
            FileStream fs = new FileStream("cb.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            string s = sr.ReadLine();
            while (!sr.EndOfStream)
            {
                s = sr.ReadLine();
                string[] p = s.Split(';');
                Bejegyzes b = new Bejegyzes(Convert.ToInt32(p[0]), Convert.ToInt32(p[1]), Convert.ToInt32(p[2]), p[3]);
                Naplo.Add(b);
            }
            fs.Close();
            sr.Close();
        }
        #endregion

        #region 4. Feladat
        static string Feladat4()
        {
            bool volt = false;
            foreach (Bejegyzes b in Naplo)
            {
                if (b.AdasDb == 4) { volt = true; break; }
            }

            if (volt) { return "Volt négy adást indító sofőr."; }
            else { return "Nem volt négy adást indító sofőr."; }
        }
        #endregion

        #region 5. Feladat
        static string Feladat5(string Nev)
        {
            bool van = false; int sum = 0;
            foreach (Bejegyzes b in Naplo) { if (b.Nev == Nev) { van = true; sum += b.AdasDb; } }

            if (van) { return String.Format("{0} {1}x használta a CB-rádiót.", Nev, sum); }
            else { return "Nincs ilyen nevű sofőr!"; }
        }
        #endregion

        #region 6. Feladat
        static int AtszamolPercre(int Ora, int Perc) { return (Ora * 60) + Perc; }
        #endregion

        #region 7. Feladat
        static void Feladat7()
        {
            StreamWriter sw = new StreamWriter("cb2.txt");
            sw.WriteLine("Kezdes;Nev;AdasDb");
            foreach (Bejegyzes b in Naplo) { sw.WriteLine("{0};{1};{2}", AtszamolPercre(b.Ora, b.Perc), b.Nev, b.AdasDb); }
            sw.Close();
        }
        #endregion

        #region 8. Feladat
        static void Feladat8()
        {
            foreach (Bejegyzes b in Naplo) { if (!Nevek.Contains(b.Nev)) { Nevek.Add(b.Nev); } }
        }
        #endregion

        #region 9. Feladat
        static void Feladat9()
        {
            Bejegyzes max = new Bejegyzes(0, 0, 0, "");
            int[] AdasDb = new int[Nevek.Count];

            foreach (Bejegyzes b in Naplo)
            {
                for (int i = 0; i < AdasDb.Length; i++) { if (b.Nev == Nevek[i]) { AdasDb[i] += b.AdasDb; break; } }
            }

            for (int i = 0; i < AdasDb.Length; i++)
            {
                if (AdasDb[i] > max.AdasDb) { max.Nev = Nevek[i]; max.AdasDb = AdasDb[i]; }
            }

            Console.WriteLine("\tNév: {0}", max.Nev);
            Console.WriteLine("\tAdások száma: {0} alkalom", max.AdasDb);
        }
        #endregion
    }
}
