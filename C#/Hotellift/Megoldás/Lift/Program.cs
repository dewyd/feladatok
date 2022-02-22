using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lift
{
    internal class Program
    {
        static List<Hasznalat> LiftHasznalatok = new List<Hasznalat>();

        static void Main(string[] args)
        {
            #region Feladatok
            Feladat2();
            Console.WriteLine("3. feladat: Összes lifthasználat: {0}", LiftHasznalatok.Count);
            Feladat4();
            Feladat5();
            Console.WriteLine("6. feladat");
            Console.Write("\tKártya száma: ");
            string sSorszam = Console.ReadLine();
            Console.Write("\tCélszint száma: ");
            string sCelSzint = Console.ReadLine();
            int Sorszam = 0, CelSzint = 0;
            try { Sorszam = Convert.ToInt32(sSorszam); CelSzint = Convert.ToInt32(sCelSzint); }
            catch (Exception) { Sorszam = 5; CelSzint = 5; }
            Console.WriteLine("7. feladat: {0}", Feladat7(Sorszam, CelSzint));
            Console.WriteLine("8. feladat: Statisztika");
            Feladat8();
            #endregion

            Console.ReadKey();
        }

        #region 2. Feladat
        static void Feladat2()
        {
            FileStream fs = new FileStream("lift.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            while (!sr.EndOfStream)
            {
                string s = sr.ReadLine();
                string[] p1 = s.Split(' ');
                string[] p2 = p1[0].Split('.');
                Hasznalat h = new Hasznalat(Convert.ToInt32(p2[0]), Convert.ToInt32(p2[1]), Convert.ToInt32(p2[2]), Convert.ToInt32(p1[1]), Convert.ToInt32(p1[2]), Convert.ToInt32(p1[3]));
                LiftHasznalatok.Add(h);
            }
            fs.Close();
            sr.Close();
        }
        #endregion

        #region 4. Feladat
        static void Feladat4()
        {
            Hasznalat min = new Hasznalat(9999, 9999, 9999, 9999, 9999, 9999);
            Hasznalat max = new Hasznalat(0, 0, 0, 0, 0, 0);

            foreach (Hasznalat h in LiftHasznalatok)
            {
                if (h.Ev < min.Ev || h.Honap < min.Honap || h.Nap < min.Nap) { min = h; }
                if (h.Ev > max.Ev || h.Honap > max.Honap || h.Nap > max.Nap) { max = h; }
            }

            Console.WriteLine("4. feladat: Időszak: {0}.{1}.{2} - {3}.{4}.{5}", min.Ev, min.Honap, min.Nap, max.Ev, max.Honap, max.Nap);
        }
        #endregion

        #region 5. Feladat
        static void Feladat5()
        {
            Hasznalat max = new Hasznalat(0, 0, 0, 0, 0, 0);
            foreach (Hasznalat h in LiftHasznalatok) { if (h.CelSzint > max.CelSzint) { max = h; } }
            Console.WriteLine("5. feladat: Célszint max: {0}", max.CelSzint);
        }
        #endregion

        #region 7. Feladat
        static string Feladat7(int Sorszam, int CelSzint)
        {
            bool volt = false;
            foreach (Hasznalat h in LiftHasznalatok) { if (Sorszam == h.Sorszam && CelSzint == h.CelSzint) { volt = true; break; } }
            if (volt) { return String.Format("A(z) {0}. kártyával utaztak a(z) {1}. emeletre!", Sorszam, CelSzint); }
            else { return String.Format("A(z) {0}. kártyával nem utaztak a(z) {1}. emeletre!", Sorszam, CelSzint); }
        }
        #endregion

        #region 8. Feladat
        static void Feladat8()
        {
            List<string> Datumok = new List<string>();
            foreach (Hasznalat h in LiftHasznalatok)
            {
                if (!Datumok.Contains(String.Format("{0}.{1}.{2}", h.Ev, h.Honap, h.Nap))) { Datumok.Add(String.Format("{0}.{1}.{2}", h.Ev, h.Honap, h.Nap)); }
            }

            int[] HasznalatDb = new int[Datumok.Count];
            foreach (Hasznalat h in LiftHasznalatok)
            {
                for (int i = 0; i < HasznalatDb.Length; i++)
                {
                    if (String.Format("{0}.{1}.{2}", h.Ev, h.Honap, h.Nap) == Datumok[i]) { HasznalatDb[i]++; break; }
                }
            }

            for (int i = 0; i < HasznalatDb.Length; i++)
            {
                Console.WriteLine("\t{0} - {1}x", Datumok[i], HasznalatDb[i]);
            }
        }
        #endregion
    }
}
