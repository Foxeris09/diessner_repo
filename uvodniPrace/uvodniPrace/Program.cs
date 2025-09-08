using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace uvodniPrace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Film prvni = new Film("Forrest Gump", "Robert", "Zemeckis", 1994);
            Film druhy = new Film("Temný rytíř", "Christopher", "Nolan", 2008);
            Film treti = new Film("Jurský park", "Steven", "Spielberg", 1993);
            List<Film> list = new List<Film>();
            list.Add(prvni);
            list.Add(druhy);
            list.Add(treti);
        }
    }
    class Film
    {
        public Film(string nazev, string jmenoRezisera, string prijmeniRezisera, int rokVzniku)
        {
            Nazev = nazev;
            JmenoRezisera = jmenoRezisera;
            PrijmeniRezisera = prijmeniRezisera;
            RokVzniku = rokVzniku;
        }
        string Nazev { get; }
        string JmenoRezisera { get; }
        string PrijmeniRezisera { get; }
        int RokVzniku { get; }

        public double Hodnoceni { get; private set; }

        List<int> hvezdicky = new List<int>();
        public void pridejHodnoceni(int pocetHvezdicek)
        {
            hvezdicky.Add(pocetHvezdicek);
            double soucet = 0;
            for (int i = 0; i < hvezdicky.Count; i++) 
            {
                soucet += hvezdicky[i];
            }
            Hodnoceni = soucet/hvezdicky.Count;
        }
        public string vypisHodnoceni()
        {
            string Vypis = "Dosavadní hodnocení jsou: ";
            for (int i = 0; i < hvezdicky.Count; i++)
            {
                Vypis += (hvezdicky[i] + ", ");
            }
            return Vypis;
        }
        public string vypisFilmu()
        {
            string vysledek = Nazev + " (" + RokVzniku + "; " + PrijmeniRezisera + ", " + JmenoRezisera[0] + "):" + Hodnoceni;
            return vysledek;
        }
    }
}
