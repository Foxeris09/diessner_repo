using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perfektni_manzelstvi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            Matice main = new Matice(n);
            for (int i = 0; i < (n); i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                main.InputZeny(input, i);
            }
            for (int i = 0; i < (n); i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                main.InputMuzi(input, i);
            }
        }
        
    }
    class Matice
    {
        public Matice(int n)
        {
            zeny = new int[n,n];
            muzi = new int[n,n];
            poradi = new int[n];
            stav = new int[n];

        }
        
        private int[,] zeny;
        private int[,] muzi;
        private int[] poradi; //držím si inty u každé ženy, abych věděl, který muž je na řadě
        private int[] stav; //udává stav ženy, 0 - je nezadaná a hledá muže, 1 - je zadaná a nehledá muže

        /// <summary>
        /// Načítá vstup do matice žen po řádcích
        /// </summary>
        /// <param name="radek">čísla v řádku, které vkládám</param>
        /// <param name="cisloRadku">na který řádek je vkládám</param>
        public void InputZeny(string[] radek, int cisloRadku)
        {
            for (int i = 0; i < radek.Length; i++)
            {
                zeny[cisloRadku, i] = Convert.ToInt32(radek[i]);
            }
        }
        /// <summary>
        /// Načítá vstup do matice mužů po řádcích
        /// </summary>
        /// <param name="radek">čísla v řádku, které vkládám</param>
        /// <param name="cisloRadku">na který řádek je vkládám</param>
        public void InputMuzi(string[] radek, int cisloRadku)
        {
            for (int i = 0; i < radek.Length; i++)
            {
                muzi[cisloRadku, i] = Convert.ToInt32(radek[i]);
            }
        }


    }
}
