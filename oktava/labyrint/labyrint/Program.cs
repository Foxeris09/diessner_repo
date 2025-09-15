using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace labyrint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sirka = Convert.ToInt16(Console.ReadLine());
            int vyska = Convert.ToInt16(Console.ReadLine());
            Labyrint main = new Labyrint(sirka, vyska);
            for (int i = 0; i < vyska; i++)
            {
                string input = Console.ReadLine();
                main.InputMatice(input, i);
            }
            
            
            Console.WriteLine();
            MaticePrint(vyska, main);
            Console.ReadLine();
            

        }
        static void MaticePrint(int vyska, Labyrint l) 
        {
            for (int i = 0; i < vyska; i++)
            {
                Console.WriteLine(l.MaticeRadek(i));
            }
        }
    }
    class Labyrint
    {
        public Labyrint(int sirka, int vyska)
        {
            Sirka = sirka;
            Vyska = vyska;
            labyrinth = new char[vyska,sirka];
        }

        public int Sirka { get; }
        public int Vyska { get; }
        private char[,] labyrinth;
        string[] znaky = {"^", ">", "v", "<" }; //CHCI POSOUVAT PŘÍŠERU TADY V TOM SENZAMU, KDYŽ SI BUDU DRŽET HODNOTU + MODULO 4

        public void InputMatice(string radek, int cisloRadek)
        {
            for (int i = 0; i < radek.Length; i++)
            {
                labyrinth[cisloRadek, i] = radek[i];
            }
        }

        public string MaticeRadek(int i)
        {
            StringBuilder sb = new StringBuilder();
            for (int j = 0; j < Sirka; j++)
            {
                sb.Append(labyrinth[i,j]);
            }
            return sb.ToString();
        }


    }
}
