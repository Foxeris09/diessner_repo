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
            int[,] board = new int[6, 7]{
            { 0, 0, 0, 0, 1, 0, 0 },
            { 0, 1, 0, 1, 2, 0, 0 },
            { 0, 0, 2, 1, 1, 0, 0 },
            { 0, 0, 0, 2, 0, 0, 0 },
            { 0, 1, 2, 1, 2, 2, 0 },
            { 0, 0, 0, 0, 0, 2, 0 }
            };
            int[] position = { 2, 2 };
            Console.WriteLine(Check(board, 5, 2, position));
            Console.ReadLine();
        }
        static bool Check(int[,] pole, int pocetNaVyhru, int hrac, int[] posledniTah)
        {
            return CheckRow(pole, pocetNaVyhru, hrac, posledniTah) || CheckColumn(pole, pocetNaVyhru, hrac, posledniTah) || CheckDiagonal1(pole, pocetNaVyhru, hrac, posledniTah) || CheckDiagonal2(pole, pocetNaVyhru, hrac, posledniTah);
        }

        static bool CheckRow(int[,] pole, int pocetNaVyhru, int hrac, int[] posledniTah)
        {
            int radek = posledniTah[0];
            int sloupec = posledniTah[1];
            int pocet = 1;
            while (true)
            {
                sloupec++;
                if (sloupec >= pole.GetLength(1)) break;
                else if (pole[radek, sloupec] == hrac)
                {
                    pocet++;
                }
                else break;
            }
            sloupec = posledniTah[1];
            while (true)
            {
                sloupec--;
                if (sloupec < 0) break;
                else if (pole[radek, sloupec] == hrac)
                {
                    pocet++;
                }
                else break;
            }
            if (pocet >= pocetNaVyhru)
            {
                return true;
            }
            return false;
        }
        static bool CheckColumn(int[,] pole, int pocetNaVyhru, int hrac, int[] posledniTah) 
        {
            int radek = posledniTah[0];
            int sloupec = posledniTah[1];
            int pocet = 1;
            while (true)
            {
                radek++;
                if (radek >= pole.GetLength(0)) break;
                else if (pole[radek, sloupec] == hrac)
                {
                    pocet++;
                }
                else break;
            }
            radek = posledniTah[0];
            while (true)
            {
                radek--;
                if (radek < 0) break;
                else if (pole[radek, sloupec] == hrac)
                {
                    pocet++;
                }
                else break;
            }
            if (pocet >= pocetNaVyhru)
            {
                return true;
            }
            return false;
        }
        static bool CheckDiagonal1(int[,] pole, int pocetNaVyhru, int hrac, int[] posledniTah)
        {
            int radek = posledniTah[0];
            int sloupec = posledniTah[1];
            int pocet = 1;
            while (true)
            {
                sloupec++;
                radek--;
                if (sloupec >= pole.GetLength(1) || radek < 0) break;
                else if (pole[radek, sloupec] == hrac)
                {
                    pocet++;
                }
                else break;
            }
            radek = posledniTah[0];
            sloupec = posledniTah[1];
            while (true)
            {
                sloupec--;
                radek++;
                if (sloupec < 0 || radek >= pole.GetLength(0)) break;
                else if (pole[radek, sloupec] == hrac)
                {
                    pocet++;
                }
                else break;
            }
            if (pocet >= pocetNaVyhru)
            {
                return true;
            }
            return false;
        }
        static bool CheckDiagonal2(int[,] pole, int pocetNaVyhru, int hrac, int[] posledniTah)
        {
            int radek = posledniTah[0];
            int sloupec = posledniTah[1];
            int pocet = 1;
            while (true)
            {
                sloupec--;
                radek--;
                if (sloupec < 0 || radek < 0) break;
                else if (pole[radek, sloupec] == hrac)
                {
                    pocet++;
                }
                else break;
            }
            radek = posledniTah[0];
            sloupec = posledniTah[1];
            while (true)
            {
                sloupec++;
                radek++;
                if (sloupec >= pole.GetLength(1) || radek >= pole.GetLength(0)) break;
                else if (pole[radek, sloupec] == hrac)
                {
                    pocet++;
                }
                else break;
            }
            if (pocet >= pocetNaVyhru)
            {
                return true;
            }
            return false;
        }




    }
}
