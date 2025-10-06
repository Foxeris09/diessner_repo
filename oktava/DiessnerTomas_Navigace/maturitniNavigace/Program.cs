using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maturitniNavigace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int pocetMest;
            int pocetCest;
            try
            {
                pocetMest = int.Parse(input[0]);
                pocetCest = int.Parse(input[1]);
            }
            catch 
            {
                chybnyVstup();
                return;
            }
            if (pocetMest < 0 || pocetCest <= 0)
            {
                chybnyVstup();
                return;
            }
                
            GrafMest graf = new GrafMest(pocetMest);
            for (int i = 0; i < pocetCest; i++)
            {
                string[] vstup = Console.ReadLine().Split();
                bool chyba = vstupDoMatice(vstup, graf, pocetMest);
                if (chyba == false)
                {
                    return;
                }
            }
            string[] startacil = Console.ReadLine().Split();
            try
            {
                graf.start = int.Parse(startacil[0]);
                graf.end = int.Parse(startacil[1]);
            }
            catch 
            {
                chybnyVstup();
            }

            Console.ReadLine();
        }

        static bool vstupDoMatice(string[] radek, GrafMest g, int m)
        {
            if (radek.Length != 4)
            {
                chybnyVstup();
                return false;
            }
            int a;
            int b;
            int c;
            int d;
            try 
            {
                a = int.Parse(radek[0]);
                b = int.Parse(radek[1]);
                c = int.Parse(radek[2]);
                d = int.Parse(radek[3]);
            }
            catch
            {
                chybnyVstup();
                return false;
            }
            g.Delky[a,b] = c;
            g.Delky[b,a] = c;
            g.Placenost[a, b] = d;
            g.Placenost[a, b] = d;
            return true;
        }
        static void chybnyVstup()
        {
            Console.WriteLine("Neplatný vstup.");
            Console.ReadLine();
        }

    }
    class GrafMest
    {
        public GrafMest(int m) 
        {
            Delky = new int[m, m];
            Placenost = new int[m, m];
        }

        public int[,] Delky;
        public int[,] Placenost;
        public int start { get; set; }
        public int end { get; set; }

    }
}
