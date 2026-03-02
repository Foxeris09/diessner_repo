using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mince
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> hodnoty = new List<int>();
            int suma = 0;
            Vstup(hodnoty, suma);
        }
        static void Vstup(List<int>list, int c)
        {
            string[] input = Console.ReadLine().Split(' ');
            
            for (int i = 0; i < input.Length; i++)
            {
                list.Add(Convert.ToInt32(input[i]));
            }
            c = Convert.ToInt32(Console.ReadLine());
        }
    }
}
