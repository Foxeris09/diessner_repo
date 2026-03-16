using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace vikendPrace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> p = new List<int>()
            {
                0, 700, 850, 4500, 1200, 250, 3200, 2400, 2800, 900, 2100, 650, 400, 600, 3000, 1500, 2500, 3800, 1600, 350, 1100, 1400, 800, 500, 1900, 950, 4800, 4950, 3500, 750, 680, 900, 4200, 1800, 2200, 1350, 3600, 1500, 1200, 550, 2400, 2000, 600, 1500, 300, 2100, 850, 1200, 1800, 1100, 1400, 2600, 1900, 750, 1200, 500, 2200, 1500, 1000, 900, 1600
            };
            
           
            List<int> c = new List<int>()
            {
                0,2,4,10,6,1,8,12,5,3,7,3,2,5,12,4,2,6,8,1,3,7,4,1,10,5,12,11,3,2,4,6,9,2,3,8,10,6,5,2,7,2,4,3,1,9,5,6,8,4,3,12,2,5,3,2,12,10,8,2,6
            };
            int[,] tabulka = new int[p.Count,49];
            algoritmus(tabulka, p, c);
            
            
            Console.ReadLine();

        }
        static void algoritmus(int[,] tab, List<int>penize, List<int>cas )
        {
            for (int i = 1; i < penize.Count; i++)
            {
                for (int j = 0; j <= 48; j++)
                {
                    if (j < cas[i])
                    {
                        tab[i, j] = tab[i - 1, j];
                        continue;
                    }
                    if (tab[i - 1, j - cas[i]] + penize[i] > tab[i - 1, j])
                    {
                        tab[i, j] = tab[i - 1, j - cas[i]] + penize[i];
                    }
                    else
                    {
                        tab[i, j] = tab[i - 1, j];
                    }
                }
            }
            Console.WriteLine(tab[penize.Count-1, 48]);

            StringBuilder sb = new StringBuilder();
            int a = 48;
            for (int i = penize.Count - 1; i > 0 ; i--)
            {
                if (tab[i,a] > tab[i-1,a])
                {
                    sb.Append(i);
                    sb.Append(" ");
                    a = a - cas[i];
                }
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
