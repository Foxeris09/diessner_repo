using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace connect5
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
        static bool Check(int[,] pole, int pocetNaVyhru, int hrac, int[] posledniTah)
        {
            return CheckRow(pole, pocetNaVyhru,  hrac, posledniTah) || CheckColumn(pole, pocetNaVyhru, hrac, posledniTah) || CheckDiagonal1(pole, pocetNaVyhru, hrac, posledniTah) || CheckDiagonal2(pole, pocetNaVyhru, hrac, posledniTah);
        }

        static bool CheckRow(int[,] pole, int pocetNaVyhru, int hrac, int[] posledniTah)
        {
            int radek = posledniTah[0];
            int sloupec = posledniTah[1];
            int pocet = 1;
            while (true)
            {
                sloupec++
                if(sloupec >= pole.GetLength(1)) break;
                else if (pole[radek,sloupec] == hrac)
                {

                }

            }
        }




    }
}
