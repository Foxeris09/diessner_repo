using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace retizek_pratelstvi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = pocetUzivatelu(); //pocet uzivatelu
            funkce(n);
            
           
            
            Console.ReadLine();

        }

        static int pocetUzivatelu()
        {
            return Convert.ToInt32(Console.ReadLine());
        }
        
        static void funkce(int a)
        {
           
            string[] dvojice = Console.ReadLine().Split(); //dvojice s "-"

            List<int>[] spojeni = new List<int>[a + 1]; //list ... n+1 abyhc jich tam mel skutecne az do cisla N. pozici 0 necham prazdnou
            for (int i = 0; i < a + 1; i++)  //list s listy
            {
                spojeni[i] = new List<int>();
            }

            for (int x = 0; x < dvojice.Length; x++) //vkladani cisel do listu
            {
                string[] oba = dvojice[x].Split('-');
                int cislo1 = Int32.Parse(oba[0]);
                int cislo2 = Int32.Parse(oba[1]);
                spojeni[cislo1].Add(cislo2);
                spojeni[cislo2].Add(cislo1);
            }

            string[] zacatek = Console.ReadLine().Split(); // nacte sstart a cil 
            int start = Int32.Parse(zacatek[0]);
            int cil = Int32.Parse(zacatek[1]);

           


            Dictionary<int, int> predchozi = new Dictionary<int, int>();
            bool[] otevreno = new bool[a + 1];
            Queue<int> q = new Queue<int>();
            q.Enqueue(start);
            otevreno[start] = true;
            predchozi[start] = -1;

                       
            bool hotovo = false;

            while (q.Count > 0)
            { 
                int ted = q.Dequeue();
                if (ted == cil)
                {
                    hotovo = true;
                    break;
                }

                foreach ( int soused in spojeni[ted])
                {
                    if (otevreno[soused]==false)
                    {
                        otevreno[soused] = true;
                        q.Enqueue(soused);
                        predchozi.Add(soused, ted);

                    }
                }
            }
            List<int> cestaZpet = new List<int>();
            if (hotovo == true) 
            {
                int zpet = cil;
                
                while (zpet != -1)
                {
                    cestaZpet.Add(zpet);
                    zpet = predchozi[zpet];
                }
                cestaZpet.Reverse();
                
            }
            if (cestaZpet.Count == 2 && hotovo == true)
            {
                Console.WriteLine("start a cíl jsou prátelé.");
            }
            else if (cestaZpet.Count > 2)
            {
                Console.WriteLine(string.Join(" ",cestaZpet));
            }
            else
            {
                Console.WriteLine("neexistuje");
            }








        }
       
        

       

        





    }
}
