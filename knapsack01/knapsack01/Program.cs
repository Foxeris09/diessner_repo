using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace knapsack01
{
    internal class Program
    {
        static int maxProfit = 0;
        static List<int> bestItems = new List<int>();
        static void Main(string[] args)
        {
            string path = "testy.txt";
            if (!File.Exists(path)) 
            {
                Console.WriteLine("SOubor nebyl nalezen");
                return;
            }
            string[] radky = File.ReadAllLines(path);
            int i = 0;

            while (i < radky.Length)
            {
                if (string.IsNullOrWhiteSpace(radky[i]))
                {
                    i++;
                    continue;
                }

                try
                {
                    //profit
                    string[] castiCen = radky[i++].Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                }
                catch { }
            }
        }
    }
}
