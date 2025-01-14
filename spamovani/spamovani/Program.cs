using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace spamovani
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            int pocetLidi = Convert.ToInt32(Console.ReadLine());
            int[,] final = new int[pocetLidi, pocetLidi ];
            int[,] vstupni = new int[pocetLidi, pocetLidi ];
            for (int i = 0; i < pocetLidi; i++)
            {
                string[] radek = Console.ReadLine().Split(' ');
                for (int j = 0; j < pocetLidi; j++)
                {
                    vstupni[i, j] = Convert.ToInt32(radek[j]);
                }
            }
            string[] lide = Console.ReadLine().Split(';');
            string zacatek = Console.ReadLine();
            int a = -1;
            for (int i = 0; i < lide.Length; i++) 
            {
                if (lide[i] == zacatek)
                    a = i;
            }

        }
            
        
        

        
    }
}
