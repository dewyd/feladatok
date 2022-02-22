using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HegyekMo
{
    internal class Program
    {
        static List<Hegy> Hegyek = new List<Hegy>();

        static void Main(string[] args)
        {
            #region Feladatok
            Feladat2();
            Console.WriteLine("3. feladat: Hegycsúcsok száma: {0} db", Hegyek.Count);
            Console.WriteLine("4. feladat: Hegycsúcsok átlagos magassága: {0:0.00} m", Feladat4());
            Console.WriteLine("5. feladat: A legmagasabb hegycsúcs adatai: ");
            Feladat5();
            Console.Write("6. feladat: Kérek egy magasságot: ");
            int Magassag = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\t{0}", Feladat6(Magassag));
            Console.WriteLine("7. feladat: 3000 lábnál magasabb hegycsúcsok száma: {0}", Feladat7());
            Console.WriteLine("8. feladat: Hegység statisztika");
            Feladat8();
            Console.WriteLine("9. feladat: bukk-videk.txt");
            Feladat9();
            #endregion

            Console.ReadKey();
        }

        #region 2. Feladat
        static void Feladat2()
        {
            FileStream fs = new FileStream("hegyekMo.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            string s = sr.ReadLine();
            while (!sr.EndOfStream)
            {
                s = sr.ReadLine();
                string[] p = s.Split(';');
                Hegy h = new Hegy(p[0], p[1], Convert.ToInt32(p[2]));
                Hegyek.Add(h);
            }
            fs.Close();
            sr.Close();
        }
        #endregion

        #region 4. Feladat
        static float Feladat4()
        {
            float sum = 0;
            foreach (Hegy h in Hegyek) { sum += h.Magassag; }
            return sum / Hegyek.Count;
        }
        #endregion

        #region 5. Feladat
        static void Feladat5()
        {
            Hegy max = new Hegy("", "", 0);
            foreach (Hegy h in Hegyek) { if (h.Magassag > max.Magassag) { max = h; } }
            Console.WriteLine("\tNév: {0}", max.Hegycsucs);
            Console.WriteLine("\tHegység: {0}", max.Hegyseg);
            Console.WriteLine("\tMagasság: {0} m", max.Magassag);
        }
        #endregion

        #region 6. Feladat
        static string Feladat6(int Magassag)
        {
            bool van = false;
            foreach (Hegy h in Hegyek)
            {
                if (h.Hegyseg == "Börzsöny" && h.Magassag > Magassag) { van = true; break; }
            }
            if (van) { return String.Format("Van {0}m-nél magasabb hegycsúcs a Börzsönyben!", Magassag); }
            else { return String.Format("Nincs {0}m-nél magasabb hegycsúcs a Börzsönyben!", Magassag); }
        }
        #endregion

        #region 7. Feladat
        static float Feladat7()
        {
            float i = 0;
            foreach (Hegy h in Hegyek) { if ((h.Magassag * 3.280839895) > 3000) { i++; } }
            return i;
        }
        #endregion

        #region 8. Feladat
        static void Feladat8()
        {
            List<string> Hegysegek = new List<string>();
            foreach (Hegy h in Hegyek) { if (!Hegysegek.Contains(h.Hegyseg)) { Hegysegek.Add(h.Hegyseg); } }
            int[] HegysegekDb = new int[Hegysegek.Count];

            foreach (Hegy h in Hegyek)
            {
                for (int i = 0; i < HegysegekDb.Length; i++) { if (h.Hegyseg == Hegysegek[i]) { HegysegekDb[i]++; break; } }
            }

            for (int i = 0; i < HegysegekDb.Length; i++) { Console.WriteLine("\t{0} - {1} db", Hegysegek[i], HegysegekDb[i]); }
        }
        #endregion

        #region 9. Feladat
        static void Feladat9()
        {
            StreamWriter sw = new StreamWriter("bukk-videk.txt");
            sw.WriteLine("Hegycsúcs neve;Magasság láb");
            foreach (Hegy h in Hegyek)
            {
                if (h.Hegyseg == "Bükk-vidék") { sw.WriteLine("{0};{1:0.0}", h.Hegycsucs, h.Magassag * 3.280839895); }
            }
            sw.Close();
        }
        #endregion
    }
}
