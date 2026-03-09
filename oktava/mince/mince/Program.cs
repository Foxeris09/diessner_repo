using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace mince
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> hodnoty = new List<int>();
            List<int> cesta = new List<int>();
            int indHodnot = 0;
            int indCesty = 0;
            int soucet = 0;

            int suma = Vstup(hodnoty);
            Console.WriteLine();
            Backtrack(hodnoty, cesta, suma, indHodnot, indCesty, soucet);
            Console.ReadLine();
        }
        static int Vstup(List<int>list)
        {
            string[] input = Console.ReadLine().Split(' ');
            
            for (int i = 0; i < input.Length; i++)
            {
                list.Add(Convert.ToInt32(input[i]));
            }
            int c = Convert.ToInt32(Console.ReadLine());
            return c;
        }

        static void Backtrack(List<int>mince, List<int>reseni, int sum, int indMince, int indReseni, int aktualniSum)
        {
            for (int i = indMince; i < mince.Count; i++)
            {
                if (aktualniSum + mince[i] > sum)
                {
                    continue;
                }
                if (aktualniSum + mince[i] == sum)
                {
                    reseni.Add(mince[i]);
                    Vystup(reseni);
                    reseni.RemoveAt(reseni.Count - 1);
                    continue;
                }
                reseni.Add(mince[i]);
                aktualniSum += mince[i];
                Backtrack(mince, reseni, sum, i, indReseni, aktualniSum);
                aktualniSum -= mince[i];
                reseni.RemoveAt(reseni.Count - 1);
            }
        }

        static void Vystup(List<int>list)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                sb.Append(list[i] + " ");
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
