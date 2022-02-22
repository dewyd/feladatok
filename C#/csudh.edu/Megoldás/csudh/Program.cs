using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace csudh
{
    internal class Program
    {
        static List<Szerver> Domainek = new List<Szerver>();

        static void Main(string[] args)
        {
            #region Feladatok
            Feladat2();
            Console.WriteLine("3. feladat: Domainek száma: {0}", Domainek.Count);
            Console.WriteLine("5. feladat: Az első domain felépítése: ");
            for (int i = 1; i <= 5; i++) { Console.WriteLine("\t{0}. szint: {1}", i, Domain(Domainek[0].Domain, i)); }
            Feladat6();
            #endregion

            Console.ReadKey();
        }

        #region 2. Feladat
        static void Feladat2()
        {
            FileStream fs = new FileStream("csudh.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            string s = sr.ReadLine();
            while (!sr.EndOfStream)
            {
                s = sr.ReadLine();
                string[] p = s.Split(';');
                Szerver sz = new Szerver(p[0], p[1]);
                Domainek.Add(sz);
            }
            fs.Close();
            sr.Close();
        }
        #endregion

        #region 4. Feladat
        static string Domain(string domain, int szint)
        {
            string[] p = domain.Split('.');
            try { return p[p.Length - szint]; }
            catch (IndexOutOfRangeException) { return "nincs"; }
        }
        #endregion

        #region 6. Feladat
        static void Feladat6()
        {
            StreamWriter sw = new StreamWriter("table.html");
            string s = String.Format("<table>\r\n<tr>\r\n");
            s += String.Format("<th style='text-align: left'>Ssz</th>\r\n");
            s += String.Format("<th style='text-align: left'>Host domainneve</th>\r\n");
            s += String.Format("<th style='text-align: left'>Host IP címe</th>\r\n");
            s += String.Format("<th style='text-align: left'>1. szint</th>\r\n");
            s += String.Format("<th style='text-align: left'>2. szint</th>\r\n");
            s += String.Format("<th style='text-align: left'>3. szint</th>\r\n");
            s += String.Format("<th style='text-align: left'>4. szint</th>\r\n");
            s += String.Format("<th style='text-align: left'>5. szint</th>\r\n</tr>"); int i = 1;
            foreach (Szerver sz in Domainek)
            {
                s += String.Format("<tr>\r\n<th style='text-align: left'>{0}.</th>\r\n", i);
                s += String.Format("<td>{0}</td>\r\n", sz.Domain);
                s += String.Format("<td>{0}</td>\r\n", sz.IP);
                for (int j = 1; j <= 5; j++) { s += String.Format("<td>{0}</td>\r\n", Domain(sz.Domain, j)); }
                s += String.Format("</tr>"); i++;
            }
            sw.WriteLine(s);
            sw.Close();
        }
        #endregion
    }
}
