using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace posloupnost
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string vstupniSoubor = "vstupy.txt"; 
            string vystupniSoubor = "vystupy.txt";
            using (StreamWriter sw = new StreamWriter(vystupniSoubor))
            {
                foreach (string radek in File.ReadLines(vstupniSoubor))
                {
                    if (string.IsNullOrWhiteSpace(radek))
                    {
                        sw.WriteLine("Prázdná posloupnost");
                        continue;
                    }
                    string[] split = radek.Split(' ');
                    List<int> cisla = new List<int>();
                    foreach (string jeden in split)
                    {
                        cisla.Add(int.Parse(jeden));
                    }
                    int[] max = new int[cisla.Count + 1];
                    int[] predchozi = new int[cisla.Count + 1];
                    NRP(cisla, max, predchozi);
                    sw.WriteLine(backtrack(cisla, predchozi));
                }
            }
          
        }
        static void NRP(List<int> ints, int[] T, int[] P)
        {
            ints.Insert(0, int.MinValue);
            for (int i = ints.Count-1; i >= 0; i--) 
            {
                T[i] = 1;
                P[i] = 0;
                if (i == ints.Count - 1)
                    continue;
                for (int j = i+1; j <= ints.Count-1; j++)
                {
                    if (ints[i] < ints[j] && T[i] < 1 + T[j])
                    {
                        T[i] = 1 + T[j];
                        P[i] = j;
                    }
                }
            }
        }
        static string backtrack(List<int> ints, int[] P)
        {
            StringBuilder sb = new StringBuilder();
            int x = P[0];
            
            while (x > 0) 
            {
                sb.Append(ints[x] + " ");
                x = P[x];
            }
            return sb.ToString();
        }
    }
}
