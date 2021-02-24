using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LezerLoveszet
{
    class JatekosLovese
    {
        string jatekos_neve;
        double jatekos_x_koord;
        double jatekos_y_koord;
        int loves_sorszam;

        public JatekosLovese(string[] jatekos_adatok, int loves_sorszam)
        {
            this.jatekos_neve = jatekos_adatok[0];
            this.jatekos_x_koord = double.Parse(jatekos_adatok[1]);
            this.jatekos_y_koord = double.Parse(jatekos_adatok[2]);
            this.loves_sorszam = loves_sorszam;
        }

        public string Jatekos_neve { get => jatekos_neve; set => jatekos_neve = value; }
        public double Jatekos_x_koord { get => jatekos_x_koord; set => jatekos_x_koord = value; }
        public double Jatekos_y_koord { get => jatekos_y_koord; set => jatekos_y_koord = value; }
        public int Loves_sorszam { get => loves_sorszam; set => loves_sorszam = value; }

        public double Tavolsag(double celtabla_X, double celtabla_y)
        {
            double dx = celtabla_X - jatekos_x_koord;
            double dy = celtabla_y - jatekos_y_koord;

            return Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));
        }

        public double Pontszam(double celtabla_X, double celtabla_y)
        {
            double pont = Math.Round(10 - Tavolsag(celtabla_X, celtabla_y), 2);
            return pont < 0 ? 0 : pont;
        }
    }
}
