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
            int pocetLidi = int.Parse(Console.ReadLine());
            int[,] vstupni = new int[pocetLidi, pocetLidi];
            for (int i = 0; i < pocetLidi; i++)
            {
                string[] radek = Console.ReadLine().Split(' ');
                for (int j = 0; j < pocetLidi; j++)
                {
                    vstupni[i, j] = int.Parse(radek[j]);
                }
            }
            string[] lide = Console.ReadLine().Split(';');
            string zacatek = Console.ReadLine();


            int a = -1;

            for (int i = 0; i < lide.Length; i++)
            {
                if (lide[i] == zacatek)
                {
                    a = i;
                    break;
                }
            }

            int[,] konec = Dijkstra(a, pocetLidi, vstupni);
            for (int i = 0; i < konec.GetLength(0); i++) 
            {
                for (int j = 0; j < konec.GetLength(1); j++) 
                {
                    Console.Write(konec[i, j] + " "); 
                }
                Console.WriteLine(); 
            }
            Console.ReadLine();
        }
        static int[,] Dijkstra (int a, int n, int[,] start)
        {
            int[] hodnota = new int[n];
            int[] stav = new int[n];
            int[] parent = new int[n];
            int v = -1;
            for (int i = 0; i < n; i++)
            {
                hodnota[i] = int.MaxValue;
                parent[i] = -1;

            }
            stav[a] = 1;
            hodnota[a] = 0;
            while (true)
            {
                int min = int.MaxValue;

                for (int i = 0; i < n; i++) 
                {
                    if (stav [i] == 1 && hodnota[i] < min)
                    {
                        min = hodnota[i];
                        v = i;
                    }
                }
                if (min == int.MaxValue)
                    break;
                for (int i = 0; i < n; i++)
                {
                    if (start[v,i] != -1 && i != v)
                    {
                        if (hodnota[i] > hodnota[v] + start[v,i])
                        {
                            hodnota[i] = hodnota[v] + start[v, i];
                            stav[i] = 1;
                            parent[i] = v;
                        }
                    }
                }
                stav[v] = 2;
            }
            int[,] final = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                if (parent[i] != -1)
                {
                    final[parent[i], i] = 1;
                }
            }
            return final;

        }
    }
}
