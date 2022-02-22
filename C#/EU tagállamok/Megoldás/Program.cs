using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EU
{

    internal class Program
    {
        static List<Tagallam> Tagallamok = new List<Tagallam>();

        static void Main(string[] args)
        {
            #region Feladatok
            Feladat2();
            Console.WriteLine("3. feladat: EU tagállamainak száma: {0} db", Tagallamok.Count);
            Console.WriteLine("4. feladat: 2007-ben {0} ország csatlakozott.", Feladat4());
            Console.WriteLine("5. feladat: Magyarország csatlakozásának dátuma: {0}", Feladat5());
            Console.WriteLine("6. feladat: {0}", Feladat6());
            Console.WriteLine("7. feladat: Legutoljára csatlakozott ország: {0}", Feladat7());
            Console.WriteLine("8. feladat: Statisztika");
            Feladat8();
            #endregion

            Console.ReadKey();
        }

        #region 2. Feladat
        static void Feladat2()
        {
            FileStream fs = new FileStream("EUcsatlakozas.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            while (!sr.EndOfStream)
            {
                string s = sr.ReadLine();
                string[] p1 = s.Split(';');
                string[] p2 = p1[1].Split('.');
                Tagallam t = new Tagallam(p1[0], Convert.ToInt32(p2[0]), Convert.ToInt32(p2[1]), Convert.ToInt32(p2[2]));
                Tagallamok.Add(t);
            }
            fs.Close();
            sr.Close();
        }
        #endregion

        #region 4. Feladat
        static int Feladat4()
        {
            int i = 0;
            foreach (Tagallam t in Tagallamok) { if (t.CsatEv == 2007) { i++; } }
            return i;
        }
        #endregion

        #region 5. Feladat
        static string Feladat5()
        {
            string datum = "";
            foreach (Tagallam t in Tagallamok)
            {
                if(t.Nev == "Magyarország") { datum = String.Format("{0}.{1}.{2}", t.CsatEv, t.CsatHonap, t.CsatNap); }
            }
            return datum;
        }
        #endregion

        #region 6. Feladat
        static string Feladat6()
        {
            bool volt = false;
            foreach (Tagallam t in Tagallamok) { if (t.CsatHonap == 5) { volt = true; break; } }
            if (volt) { return "Májusban volt csatlakozás!"; }
            else { return "Májusban nem volt csatlakozás!"; }
        }
        #endregion

        #region 7. Feladat
        static string Feladat7()
        {
            string nev = ""; int max = 0;
            foreach (Tagallam t in Tagallamok) { if (t.CsatEv > max) { max = t.CsatEv; nev = t.Nev; } }
            return nev;
        }
        #endregion

        #region 8. Feladat
        static void Feladat8()
        {
            List<int> Evszamok = new List<int>();
            foreach (Tagallam t in Tagallamok) { if (!Evszamok.Contains(t.CsatEv)) { Evszamok.Add(t.CsatEv); } }

            int[] CsatDb = new int[Evszamok.Count];
            foreach (Tagallam t in Tagallamok)
            {
                for (int i = 0; i < Evszamok.Count; i++) { if (t.CsatEv == Evszamok[i]) { CsatDb[i]++; } }
            }

            for (int i = 0; i < Evszamok.Count; i++) { Console.WriteLine("\t{0} - {1} ország", Evszamok[i], CsatDb[i]); }
        }
        #endregion
    }
}
