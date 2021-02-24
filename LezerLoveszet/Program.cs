using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LezerLoveszet 
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fajl = File.ReadAllLines("lovesek.txt", Encoding.UTF8);
            string[] valos_ertekek = fajl[0].Split(';');
            List<JatekosLovese> jatekos_lovesek = new List<JatekosLovese>();

            for (int i = 1; i < fajl.Length; i++)
            {
                string[] jelenlegi_sor = fajl[i].Split(';');
                jatekos_lovesek.Add(new JatekosLovese(jelenlegi_sor, i)); ;
            }

            /* 5. Feladat */
            Console.WriteLine($"5 Feladat: Lövések száma: {jatekos_lovesek.Count}");

            /* 7. Feladat */
            Console.WriteLine("7. Feladat: Legpontosabb lövés:");
            double legpontosabb_jatekos = double.MaxValue;
            int legpontosabb_jatekos_azon = 0;
            for (int i = 0; i < jatekos_lovesek.Count; i++)
            {
                if (legpontosabb_jatekos > jatekos_lovesek[i].Tavolsag(double.Parse(valos_ertekek[0]), double.Parse(valos_ertekek[1]))) {
                    legpontosabb_jatekos = jatekos_lovesek[i].Tavolsag(double.Parse(valos_ertekek[0]), double.Parse(valos_ertekek[1]));
                    legpontosabb_jatekos_azon = i;
                }
            }
            Console.WriteLine($"\t{jatekos_lovesek[legpontosabb_jatekos_azon].Loves_sorszam}.;" +
                $" {jatekos_lovesek[legpontosabb_jatekos_azon].Jatekos_neve}; " +
                $" x={jatekos_lovesek[legpontosabb_jatekos_azon].Jatekos_x_koord}" +
                $" y={jatekos_lovesek[legpontosabb_jatekos_azon].Jatekos_y_koord}" +
                $" távolság: {jatekos_lovesek[legpontosabb_jatekos_azon].Tavolsag(double.Parse(valos_ertekek[0]), double.Parse(valos_ertekek[1]))}");

            /* 9. Feladat */
            int nulla_dobasok = jatekos_lovesek.Count(j => j.Pontszam(double.Parse(valos_ertekek[0]), double.Parse(valos_ertekek[1])) == 0);
            Console.WriteLine($"9. Feladat: Nulla pontos lövések száma: {nulla_dobasok}");

            /* 10. Feladat */
            List<string> jatekosok_nevei = new List<string>();
            foreach (var item in jatekos_lovesek.Select(j => j.Jatekos_neve))
            {
                if (!jatekosok_nevei.Contains(item))
                {
                    jatekosok_nevei.Add(item);
                }
            }
            Console.WriteLine($"10. Feladat: Játékosok száma: {jatekosok_nevei.Count}");

            /* 11. Feladat */
            Console.WriteLine("11. Feladat: Lövések száma:");
            int dobasok_szamai_index = 0;
            double[] osszes_dobasok_szama = new double[jatekosok_nevei.Count];
            double[] dobasok_szamai = new double[jatekosok_nevei.Count];
            foreach (var item in jatekosok_nevei)
            {
                int lovesek_szama = 0;
                double osszes_dobas = 0;
                for (int i = 0; i < jatekos_lovesek.Count; i++)
                {
                    if (item.Equals(jatekos_lovesek[i].Jatekos_neve))
                    {
                        lovesek_szama++;
                        osszes_dobas += jatekos_lovesek[i].Pontszam(double.Parse(valos_ertekek[0]), double.Parse(valos_ertekek[1]));
                    }
                }
                osszes_dobasok_szama[dobasok_szamai_index] = osszes_dobas;
                dobasok_szamai[dobasok_szamai_index++] = lovesek_szama;
                Console.WriteLine($"\t{item} - {lovesek_szama}");  
            }

            /* 12. Feladat */
            Console.WriteLine("12. Feladat: Átlagpontszámok:");
            double nyertes = 0;
            int index = 0;
            for (int i = 0; i < jatekosok_nevei.Count; i++)
            {
                Console.WriteLine($"\t{jatekosok_nevei[i]} - {(double) osszes_dobasok_szama[i] / dobasok_szamai[i]}");
                if (nyertes < (double)osszes_dobasok_szama[i] / dobasok_szamai[i])
                {
                    nyertes = (double)osszes_dobasok_szama[i] / dobasok_szamai[i];
                    index = i;
                }
            }
            Console.WriteLine($"13. Feladat: A játék nyetese {jatekosok_nevei[index]}");
            

            Console.ReadKey();
        }
    }
}
