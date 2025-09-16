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

            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine();
                main.pohyb();
                Console.WriteLine(i+1 +". krok");
                MaticePrint(vyska, main);
            }
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
            labyrinth = new char[vyska, sirka];
        }

        public int Sirka { get; }
        public int Vyska { get; }

        private char[,] labyrinth;
        char[] znaky = { '^', '>', 'v', '<' }; //CHCI POSOUVAT PŘÍŠERU TADY V TOM SENZAMU, KDYŽ SI BUDU DRŽET HODNOTU + MODULO 4
        private int orientace = 0;
        private bool prava = false; //když se otočím doprava, musím další krok jít rovně
        private int[] pozice = { 0, 0 }; //pozice příšery

        public void InputMatice(string radek, int cisloRadek) //načte matici do mé 2D mapy/matice
        {
            for (int i = 0; i < radek.Length; i++)
            {
                labyrinth[cisloRadek, i] = radek[i];
                if (radek[i] != 'X' && radek[i] != '.')
                {
                    pozice[0] = cisloRadek;
                    pozice[1] = i;
                    puvodniSmer(radek[i]); //musim zjistit směr příšery
                }
            }
        }

        public string MaticeRadek(int i) //vrací ve stringu jeden řádek matice pro vypsání
        {
            StringBuilder sb = new StringBuilder();
            for (int j = 0; j < Sirka; j++)
            {
                sb.Append(labyrinth[i, j]);
            }
            return sb.ToString();
        }

        private void puvodniSmer(char r) // určí směr příšery na začátku
        {
            if (r == '>')
                orientace = 1;
            if (r == 'v')
                orientace = 2;
            if (r == '<')
                orientace = 3;
        }

        public void pohyb()
        {
            if (prava == true)
            {
                prava = false;
                dopredu();
            }
            else if (jeVpravoZed() == false)
            {
                orientace += 1;
                orientace = orientace % 4;
                labyrinth[pozice[0], pozice[1]] = znaky[orientace];
                prava = true;
            }
            else if (jeVepreduZed() == true)
            {
                orientace -= 1;
                if (orientace == -1)
                    orientace += 4;
                labyrinth[pozice[0], pozice[1]] = znaky[orientace];
            }
            else
                dopredu();


        }

        private void dopredu()
        {
            if(orientace == 0)
            {
                labyrinth[pozice[0], pozice[1]] = '.';
                labyrinth[pozice[0] -1, pozice[1]] = znaky[orientace];
                pozice[0] -= 1;
            }
            else if (orientace == 1)
            {
                labyrinth[pozice[0], pozice[1]] = '.';
                labyrinth[pozice[0], pozice[1] +1] = znaky[orientace];
                pozice[1] += 1;
            }
            else if (orientace == 2)
            {
                labyrinth[pozice[0], pozice[1]] = '.';
                labyrinth[pozice[0] +1, pozice[1]] = znaky[orientace];
                pozice[0] += 1;
            }
            else if (orientace == 3)
            {
                labyrinth[pozice[0], pozice[1]] = '.';
                labyrinth[pozice[0], pozice[1] -1] = znaky[orientace];
                pozice[1] -= 1;
            }
        }
           
        private bool jeVpravoZed() //zjistí jestli je vpravo od příšery zeď
        {
            if(orientace == 0)
            {
                if (labyrinth[pozice[0], pozice[1]+1] == 'X')
                    return true;
            }
            else if (orientace == 1)
            {
                if (labyrinth[pozice[0] +1, pozice[1]] == 'X')
                    return true;
            }
            else if (orientace == 2)
            {
                if (labyrinth[pozice[0], pozice[1] -1] == 'X')
                    return true;
            }
            else if (orientace == 3)
            {
                if (labyrinth[pozice[0] -1, pozice[1]] == 'X')
                    return true;
            }
            return false;
        }

        private bool jeVepreduZed() //zjisti jestli je zed pred priserou
        {
            if (orientace == 0)
            {
                if (labyrinth[pozice[0] -1, pozice[1]] == 'X')
                    return true;
            }
            else if (orientace == 1)
            {
                if (labyrinth[pozice[0], pozice[1] +1] == 'X')
                    return true;
            }
            else if (orientace == 2)
            {
                if (labyrinth[pozice[0] +1, pozice[1]] == 'X')
                    return true;
            }
            else if (orientace == 3)
            {
                if (labyrinth[pozice[0], pozice[1] -1] == 'X')
                    return true;
            }
            return false;
        }

    }
}
