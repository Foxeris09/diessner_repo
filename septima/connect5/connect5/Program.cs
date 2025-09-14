using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace connect5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Na kolik žetonů v řadě chete hrát?");
            int naKolik = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Kolik řádků bude mít pole?");
            int pocetRadku = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("A kolik sloupců?");
            int pocetSloupcu = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Kolik hráčů hraje?");
            int pocetHracu = Convert.ToInt32(Console.ReadLine());

            Hra hra = new Hra(naKolik, pocetRadku, pocetSloupcu, pocetHracu); // voláme konstruktor při vytváření instance
            Hrac vitez = hra.Play(); // funkce Play vrací vítěze

            Console.WriteLine("Tuto hru vyhrál " +vitez.Jmeno);
            Console.ReadLine();
        }

        class Hrac
        {
            // Jméno i Symbol budeme využívat i v třídě Hra, proto jsou PUBLIC
            // Protože jsou public, tak je píšeme s velkým počátečním písmenem
            public string Jmeno { get; }
            public char Symbol { get; }

            public Hrac(string jmeno, char symbol)
            {
                Jmeno = jmeno;
                Symbol = symbol;
            }
        }

        // struktura je jako třída, ale paměťově omezená, hodí se pro jednoduché datové typy jako například udržování dvojice souřadnic pro pozici ve hře
        struct Position
        {
            public int Row;
            public int Column;
        }
        
        class Hra
        {
            //konstruktor - jeho parametry by měly obsahovat vše, co je potřeba nastavit při inicializaci herního objektu (jedné instanci hry)
            public Hra(int pocetVyhernichZetonu, int pocetRadku, int pocetSloupcu, int pocetHracu)
            {
                this.pocetVyhernichZetonu = pocetVyhernichZetonu; // použili jsme slovo this, protože se parametr konstruktoru nazývá stejně jako datová položka v této třídě
                hraciPole = new char[pocetRadku, pocetSloupcu];

                hraci = new Hrac[pocetHracu]; // vytvoří pole ale už nevytvoří samotné hráče! zatím jsou v poli jen samé null hodnoty
                VytvorHrace(); // hráči v poli se vytvoří až v této funkci

            }

            // následující datové položky jsou privátní - není potřeba, aby byly vidět mimo třídu
            private int pocetVyhernichZetonu; // datová položka
            private char[,] hraciPole;
            private Hrac[] hraci;

            private void VytvorHrace()
            {
                for (int i = 0; i < hraci.Length; i++)
                {
                    Console.WriteLine($"Napiš jméno hráče {i}:");
                    string jmeno = Console.ReadLine();
                    Console.WriteLine($"Jaký symbol pro něj budeš chtít použít:");
                    char symbol = Convert.ToChar(Console.ReadLine());

                    hraci[i] = new Hrac(jmeno, symbol); // až zde dojde k reálnému vytvoření hráče v paměti (konkrétně na *haldě*)
                }
            }

            private void VypisPole(char[,] pole)
            {
                int pocetRadku = pole.GetLength(0);
                int pocetSloupcu = pole.GetLength(1);
                for (int i = 0; i < pocetRadku; i++)
                {
                    for (int j = 0; j < pocetSloupcu; j++)
                    {
                        if (pole[i, j] == 0)
                            Console.Write("| ");
                        else
                            Console.Write("|" + pole[i, j]);   
                    }
                    Console.Write("|");
                    Console.WriteLine();
                }
            }

            private Position Tah(Hrac hrac, char[,] pole, Position pozice)
            {
                Console.WriteLine("Do jakého sloupce chceš vhodit žeton?");
                int sloupec = Convert.ToInt32(Console.ReadLine());
                sloupec--;
                int pocetRadku = pole.GetLength(0);
                if (pole[0,sloupec] != 0)
                {
                    Console.WriteLine("Řádek je zabraný. Ztrácíš tah :(");
                    return pozice;
                }

                for (int i = 0; i < pocetRadku; i++)
                {
                    if (i+1 == pocetRadku)
                    {
                        pole[i, sloupec] = hrac.Symbol;
                        pozice.Row = i;
                        pozice.Column = sloupec;
                        return pozice;
                    }
                    if (pole[i+1,sloupec] != 0)
                    {
                        pole[i, sloupec] = hrac.Symbol;
                        pozice.Row = i;
                        pozice.Column = sloupec;
                        return pozice;
                    }
                }
                return pozice;
            }

            // hru ovšem musíme nějak spustit, je tedy public, aby šla spustit i ze třídy Program, vrací vítězného hráče
            public Hrac Play()
            {
                // TODO - následující úkoly si zaslouží vlastní funkci/metodu

                int p = 0;
                int q = hraci.Length;
                Position pozice = new Position();


                // dokud hra neskončí
                while (true)
                {
                    // vypište hráče, který je na řadě

                    int h = p % q; // čislo hráče co je na řadě
                    Console.WriteLine("Na řadě je hráč "+hraci[h].Jmeno);
         
                    // vypište herní pole

                    VypisPole(hraciPole);

                    // zpracujte hráčův tah (např. zeptejte se do jakého sloupce chce vhodit žeton a podle toho na správné místo v hracím poli umístěte jeho žeton)

                    pozice = Tah(hraci[h], hraciPole, pozice);

                    // zkontrolujte, zda tímto tahem nevyhrál

                    bool vyhra = Check(hraciPole, pocetVyhernichZetonu, hraci[h], pozice);

                    // pokud ne, je na řadě další hráč
                    // pokud ano, vraťce vítěze

                    if (vyhra == true)
                    {
                        VypisPole(hraciPole);
                        return hraci[h];
                    }

                    p++; // další hráč na řadě
                }
            }












            static bool Check(char[,] pole, int pocetNaVyhru, Hrac hrac, Position posledniTah)
            {
                return CheckRow(pole, pocetNaVyhru, hrac, posledniTah) || CheckColumn(pole, pocetNaVyhru, hrac, posledniTah) || CheckDiagonal1(pole, pocetNaVyhru, hrac, posledniTah) || CheckDiagonal2(pole, pocetNaVyhru, hrac, posledniTah);
            }

            static bool CheckRow(char[,] pole, int pocetNaVyhru, Hrac hrac, Position posledniTah)
            {
                int radek = posledniTah.Row;
                int sloupec = posledniTah.Column;
                int pocet = 1;
                while (true)
                {
                    sloupec++;
                    if (sloupec >= pole.GetLength(1)) break;
                    else if (pole[radek, sloupec] == hrac.Symbol)
                    {
                        pocet++;
                    }
                    else break;
                }
                sloupec = posledniTah.Column;
                while (true)
                {
                    sloupec--;
                    if (sloupec < 0) break;
                    else if (pole[radek, sloupec] == hrac.Symbol)
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
            static bool CheckColumn(char[,] pole, int pocetNaVyhru, Hrac hrac, Position posledniTah)
            {
                int radek = posledniTah.Row;
                int sloupec = posledniTah.Column;
                int pocet = 1;
                while (true)
                {
                    radek++;
                    if (radek >= pole.GetLength(0)) break;
                    else if (pole[radek, sloupec] == hrac.Symbol)
                    {
                        pocet++;
                    }
                    else break;
                }
                radek = posledniTah.Row;
                while (true)
                {
                    radek--;
                    if (radek < 0) break;
                    else if (pole[radek, sloupec] == hrac.Symbol)
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
            static bool CheckDiagonal1(char[,] pole, int pocetNaVyhru, Hrac hrac, Position posledniTah)
            {
                int radek = posledniTah.Row;
                int sloupec = posledniTah.Column;
                int pocet = 1;
                while (true)
                {
                    sloupec++;
                    radek--;
                    if (sloupec >= pole.GetLength(1) || radek < 0) break;
                    else if (pole[radek, sloupec] == hrac.Symbol)
                    {
                        pocet++;
                    }
                    else break;
                }
                radek = posledniTah.Row;
                sloupec = posledniTah.Column;
                while (true)
                {
                    sloupec--;
                    radek++;
                    if (sloupec < 0 || radek >= pole.GetLength(0)) break;
                    else if (pole[radek, sloupec] == hrac.Symbol)
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
            static bool CheckDiagonal2(char[,] pole, int pocetNaVyhru, Hrac hrac, Position posledniTah)
            {
                int radek = posledniTah.Row;
                int sloupec = posledniTah.Column;
                int pocet = 1;
                while (true)
                {
                    sloupec--;
                    radek--;
                    if (sloupec < 0 || radek < 0) break;
                    else if (pole[radek, sloupec] == hrac.Symbol)
                    {
                        pocet++;
                    }
                    else break;
                }
                radek = posledniTah.Row;
                sloupec = posledniTah.Column;
                while (true)
                {
                    sloupec++;
                    radek++;
                    if (sloupec >= pole.GetLength(1) || radek >= pole.GetLength(0)) break;
                    else if (pole[radek, sloupec] == hrac.Symbol)
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
}
