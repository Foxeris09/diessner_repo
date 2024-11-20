using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace retizek_pratelstvi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            nacitaniVstupu();
            Console.ReadLine();

        }
        static void nacitaniVstupu ()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] dvojice = Console.ReadLine().Split();
            
            List<int>[] spojeni = new List<int>[n+1];
            for (int i = 0; i < n+1; i++)
            {
                spojeni[i] = new List<int>();
            }
            for (int x = 0; x < dvojice.Length; x++)
            {
                string[] oba = dvojice[x].Split('-');
                int cislo1 = Int32.Parse(oba[0]);
                int cislo2 = Int32.Parse(oba[1]);
                   //PRIDEJ DO SEZNAMU CISLA!!!
            }
            
            
            
            for (int i = 0; i < dvojice.Length; i++)
            {
                Console.WriteLine(dvojice[i]);

            }




        }




    }
}
