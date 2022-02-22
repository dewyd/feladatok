using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace egyszamjatek
{
    internal class Program
    {
        static List<Jatekos> Jatekosok = new List<Jatekos>();

        static void Main(string[] args)
        {
            #region Feladatok
            Feladat2();
            Console.WriteLine("3. feladat: Játékosok száma: {0}", Jatekosok.Count);
            Console.WriteLine("4. feladat: Fordulók száma: {0}", Jatekosok[0].Fordulo.Length);
            Console.WriteLine("5. feladat: {0}", Feladat5());
            Console.WriteLine("6. feladat: A legnagyobb tipp a fordulók során: {0}", Feladat6());
            Console.Write("7. feladat: Kérem a forduló sorszámát [1-10]: ");
            try { int fordulo = Convert.ToInt32(Console.ReadLine()); Feladat8_9(fordulo); }
            catch (Exception) { Console.WriteLine("8. feladat: Nem volt ilyen forduló!"); }
            #endregion

            Console.ReadKey();
        }

        #region 2. Feladat
        static void Feladat2()
        {
            FileStream fs = new FileStream("egyszamjatek.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            while (!sr.EndOfStream)
            {
                string s = sr.ReadLine();
                string[] p = s.Split(' ');
                int[] Fordulo = new int[10];
                for (int i = 0; i < 10; i++) { Fordulo[i] = Convert.ToInt32(p[i]); }
                Jatekos j = new Jatekos(Fordulo, p[10]);
                Jatekosok.Add(j);
            }
            fs.Close();
            sr.Close();
        }
        #endregion

        #region 5. Feladat
        static string Feladat5()
        {
            bool volt = false;
            foreach (Jatekos j in Jatekosok)
            {
                if (j.Fordulo[0] == 1) { volt = true; break; }
            }
            if (volt) { return "Az első fordulóban volt egyes tipp!"; }
            else { return "Az első fordulóban nem volt egyes tipp!"; }
        }
        #endregion

        #region 6. Feladat
        static int Feladat6()
        {
            int max = 0;
            foreach (Jatekos j in Jatekosok)
            {
                for (int i = 0; i < 10; i++) { if (j.Fordulo[i] > max) { max = j.Fordulo[i]; } }
            }
            return max;
        }
        #endregion

        #region 8 - 9. Feladat
        static void Feladat8_9(int fordulo)
        {
            string nev = ""; int max = 0;
            foreach (Jatekos j in Jatekosok) { if (j.Fordulo[fordulo - 1] > max) { max = j.Fordulo[fordulo - 1]; nev = j.Nev; } }

            Console.WriteLine("8. feladat: A nyertes tipp a megadott fordulóban: {0}", max);
            Console.WriteLine("9. feladat: A megadott forduló nyertese: {0}", nev);
        }
        #endregion
    }
}

