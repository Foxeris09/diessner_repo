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
            bool b = false;
            
            Console.WriteLine();

            if (suma == 0)
                Console.WriteLine("Nepoužije se žádná mince.");
            else
                Backtrack(hodnoty, cesta, suma, indHodnot, indCesty, soucet, ref b);
            if (!b && suma != 0)
                Console.WriteLine("Součtu nejde dosáhnout.");
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

        static void Backtrack(List<int>mince, List<int>reseni, int sum, int indMince, int indReseni, int aktualniSum, ref bool nejakeReseni)
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
                    nejakeReseni = true;
                    reseni.RemoveAt(reseni.Count - 1);
                    continue;
                }
                reseni.Add(mince[i]);
                aktualniSum += mince[i];
                Backtrack(mince, reseni, sum, i, indReseni, aktualniSum, ref nejakeReseni);
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
