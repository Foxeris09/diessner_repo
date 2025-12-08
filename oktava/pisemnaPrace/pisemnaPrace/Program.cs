using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Data.SqlTypes;

namespace pisemnaPrace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] sachovnice = new int[8, 8];
            string[] pozice = Vstup(sachovnice).Split(' ');
            int startX = Convert.ToInt16(pozice[0]);
            int startY = Convert.ToInt16(pozice[1]);
            int cilX = Convert.ToInt16(pozice[2]);
            int cilY = Convert.ToInt16(pozice[3]);
            int vysledek = Pohyb(sachovnice, startX, startY, cilX, cilY);
            Vystup(vysledek);
            
        }
        static string Vstup(int[,] pole)
        {
            StringBuilder sb = new StringBuilder();
            using (StreamReader sr = new StreamReader(@"vstupni_soubory\3.txt"))
            {
                int n = Convert.ToInt16(sr.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    string[] prekazka = sr.ReadLine().Split(' ');
                    int x = Convert.ToInt16(prekazka[0]);
                    int y = Convert.ToInt16(prekazka[1]);
                    pole[x,y] = -1;
                }
                sb.Append(sr.ReadLine());
                sb.Append(' ');
                sb.Append(sr.ReadLine());
            }
            return sb.ToString();
        }
        static int Pohyb(int[,] pole, int sX, int sY, int cX, int cY)
        {
            int[,] mozneTahy = { { -2, -1 }, { -2, 1 }, { -1, -2 }, { -1, 2 }, { 1, -2 }, { 1, 2 }, { 2, -1 }, { 2, -1 }, };
            Queue<int[]> fronta = new Queue<int[]>();
            int[] start = { sX, sY };
            fronta.Enqueue(start);
            bool mamCil = false;
            while (fronta.Count > 0)
            {
                int[] aktualniPoloha = fronta.Dequeue();
                int x = aktualniPoloha[0];
                int y = aktualniPoloha[1];
                for (int i = 0; i < 8; i++)
                {
                    try // pokud by kun vyjel ze sachovnice tak bude program pokracovat dal
                    {
                        if (pole[x + mozneTahy[i,0], y + mozneTahy[i,1]] != -1)   // asi jsem se měl lépe zorientovt co je osa x a co y ted uz vubec nevim :(
                        {
                            int[] dalsiKrok = { x + mozneTahy[i, 0], y + mozneTahy[i, 1] };
                            fronta.Enqueue(dalsiKrok);
                            pole[x + mozneTahy[i, 0], y + mozneTahy[i, 1]] = pole[x, y] +1;
                        }
                        if (x + mozneTahy[i, 0] == cY && y + mozneTahy[i, 1] == cX)
                        {
                            mamCil = true;
                            break;
                        }
                    }
                    catch
                    {
                        continue;
                    }
                    
                }
                if (mamCil)
                    break;
            }
            return pole[cY,cX];

        }
        static void Vystup(int n)
        {
            using(StreamWriter sw = new StreamWriter("vystup.txt"))
            {
                sw.WriteLine(n);
            }
        }


    }

    
}
