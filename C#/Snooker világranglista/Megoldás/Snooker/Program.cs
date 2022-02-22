using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Snooker
{
    internal class Program
    {
        static List<Versenyzo> Ranglista = new List<Versenyzo>();

        static void Main(string[] args)
        {
            #region Feladatok
            Feladat2();
            Console.WriteLine("3. feladat: A világranglistán {0} versenyző szerepel", Ranglista.Count);
            Console.WriteLine("4. feladat: A versenyzők átlagosan {0:0.00} fontot kerestek", Feladat4());
            Console.WriteLine("5. feladat: A legjobban kereső kínai versenyző:");
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
            FileStream fs = new FileStream("snooker.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            string s = sr.ReadLine();
            while (!sr.EndOfStream)
            {
                s = sr.ReadLine();
                string[] p = s.Split(';');
                Versenyzo v = new Versenyzo(p[0], p[1], p[2], Convert.ToInt32(p[3]));
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
            foreach (Versenyzo v in Ranglista) { sum += v.Nyeremeny; }
            return sum / Ranglista.Count;
        }
        #endregion

        #region 5. Feladat
        static void Feladat5()
        {
            Versenyzo max = new Versenyzo("", "", "", 0);
            foreach (Versenyzo v in Ranglista) { if (v.Nyeremeny > max.Nyeremeny && v.Orszag == "Kína") { max = v; } }
            Console.WriteLine("\tHelyezés: {0}", max.Helyezes);
            Console.WriteLine("\tNév: {0}", max.Nev);
            Console.WriteLine("\tOrszág: {0}", max.Orszag);
            Console.WriteLine("\tNyeremény összege: {0:000 000 000} Ft", max.Nyeremeny * 380);
        }
        #endregion

        #region 6. Feladat
        static string Feladat6()
        {
            bool van = false;
            foreach (Versenyzo v in Ranglista) { if (v.Orszag == "Norvégia") { van = true; break; } }
            if (van) { return "A versenyzők között van norvég versenyző."; }
            else { return "A versenyzők között nincs norvég versenyző."; }
        }
        #endregion

        #region 7. Feladat
        static void Feladat7()
        {
            List<string> Orszagok = new List<string>();
            foreach (Versenyzo v in Ranglista) { if (!Orszagok.Contains(v.Orszag)) { Orszagok.Add(v.Orszag); } }
            int[] VersenyzokDb = new int[Orszagok.Count];

            foreach (Versenyzo v in Ranglista)
            {
                for (int i = 0; i < Orszagok.Count; i++) { if (v.Orszag == Orszagok[i]) { VersenyzokDb[i]++; break; } }
            }

            for (int i = 0; i < VersenyzokDb.Length; i++)
            {
                if (VersenyzokDb[i] > 4) { Console.WriteLine("\t{0} - {1} fő", Orszagok[i], VersenyzokDb[i]); }
            }
        }
        #endregion
    }
}
