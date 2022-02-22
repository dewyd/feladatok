using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace vb2018
{
    internal class Program
    {
        static List<Helyszin> Stadionok = new List<Helyszin>();

        static void Main(string[] args)
        {
            #region Feladatok
            Feladat2();
            Console.WriteLine("3. feladat: Stadionok száma: {0}", Stadionok.Count);
            Console.WriteLine("4. feladat: A legkevesebb férőhely:");
            Feladat4();
            Console.WriteLine("5. feladat: Átlagos férőhelyszám: {0:0.0}", Feladat5());
            Console.WriteLine("6. feladat: Két néven is ismert stadionok száma: {0}", Feladat6());
            string Varos = "";
            do
            {
                Console.Write("7. feladat: Kérem a város nevét: ");
                Varos = Console.ReadLine();
            } while (Varos.Length < 3);
            Console.WriteLine("8. feladat: {0}", Feladat8(Varos));
            Console.WriteLine("9. feladat: {0} különböző városban voltak mérkőzések.", Feladat9());
            #endregion

            Console.ReadKey();
        }

        #region 2. Feladat
        static void Feladat2()
        {
            FileStream fs = new FileStream("vb2018.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            string s = sr.ReadLine();
            while (!sr.EndOfStream)
            {
                s = sr.ReadLine();
                string[] p = s.Split(';');
                Helyszin h = new Helyszin(p[0], p[1], p[2], Convert.ToInt32(p[3]));
                Stadionok.Add(h);
            }
            fs.Close();
            sr.Close();
        }
        #endregion

        #region 4. Feladat
        static void Feladat4()
        {
            Helyszin min = new Helyszin("", "", "", 999999);
            foreach (Helyszin h in Stadionok) { if (h.Ferohely < min.Ferohely) { min = h; } }
            Console.WriteLine("\tVáros: {0}", min.Varos);
            Console.WriteLine("\tStadion neve: {0}", min.Nev1);
            Console.WriteLine("\tFérőhely: {0}", min.Ferohely);
        }
        #endregion

        #region 5. Feladat
        static float Feladat5()
        {
            float sum = 0;
            foreach (Helyszin h in Stadionok) { sum += h.Ferohely; }
            return sum / Stadionok.Count;
        }
        #endregion

        #region 6. Feladat
        static int Feladat6()
        {
            int i = 0;
            foreach (Helyszin h in Stadionok) { if (h.Nev2 != "n.a.") { i++; } }
            return i;
        }
        #endregion

        #region 8. Feladat
        static string Feladat8(string Varos)
        {
            bool helyszin = false;
            foreach (Helyszin h in Stadionok) { if (h.Varos == Varos) { helyszin = true; break; } }
            if (helyszin) { return "A megadott város VB helyszín."; }
            else { return "A megadott város nem VB helyszín."; }
        }
        #endregion

        #region 9. Feladat
        static int Feladat9()
        {
            int i = 0;
            List<string> Varosok = new List<string>();
            foreach (Helyszin h in Stadionok) { if (!Varosok.Contains(h.Varos)) { i++; Varosok.Add(h.Varos); } }
            return i;
        }
        #endregion
    }
}
