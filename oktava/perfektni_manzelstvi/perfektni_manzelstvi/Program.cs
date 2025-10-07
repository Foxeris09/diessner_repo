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
            main.volenka();

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(main.zeny[i, main.poradi[i]-1]);
            }
            Console.ReadLine();

        }
        
        
    }
    class Matice
    {
        public Matice(int n)
        {
            zeny = new int[n, n];
            muzi = new int[n, n];
            poradi = new int[n];
            stavMuzu = new int[n];
            for (int i = 0; i < n; i++) //nastavi do celeho seznamu hodnoty n
            {
                stavMuzu[i] = n;
            }

            queue = new Queue<int>();
            for (int i = 0; i < n; i++)
            {
                queue.Enqueue(i);
            }
        }

        public int[,] zeny;
        private int[,] muzi;
        public int[] poradi; //držím si inty u každé ženy, abych věděl, který muž je na řadě
        private int[] stavMuzu; //udává kolikátá je mužova aktuální žena
        private Queue<int> queue; //jsou v ní ženy co momentálně nejsou zadané

        //!!! Jediné čím si nejsem jistý, je to, že ta fronta mi občas neudží to pořadí, že se to někdy nebude vyhodnocovat z leva, 
        // jen nevím, jestli mi to v nějakém případě zkazí výsledek, protože jsem na žádný takový příklad nepřišel.

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

        /// <summary>
        /// hlavní program, který poběží, dokud nebudou všechny ženy zadané
        /// </summary>
        public void volenka()
        {
            while (queue.Count != 0 )
            {
                int zenaNaRade = queue.Dequeue();
                int vyvoleny = zeny[zenaNaRade, poradi[zenaNaRade]] -1;
                chceMuz(zenaNaRade, vyvoleny);
                poradi[zenaNaRade] += 1;
            }
        }

        /// <summary>
        /// vyhodnotí jednu volbu od ženy
        /// </summary>
        /// <param name="jaka">žena, která vybíra</param>
        /// <param name="ktery">muž, kterého si vybrala</param>
        private void chceMuz(int jaka, int ktery)
        {
            for (int i = 0; i < stavMuzu.Length; i++) 
            {
                if (muzi[ktery,i]-1 == jaka) //potrebuji projit muzuv seznam a najit na nem danou zenu
                {
                    if (stavMuzu[ktery] == stavMuzu.Length) //když muz jeste nemel prirazenou zenu
                    {
                        stavMuzu[ktery] = i;
                        break;
                    }
                    else if (stavMuzu[ktery] > i)  //kdyz je dana žena lepší tak si ji vybere a uvolni svoji starou
                    {
                        queue.Enqueue(muzi[ktery,stavMuzu[ktery]]-1);
                        stavMuzu[ktery] = i;
                        break;
                    }
                    else //kdyz uz je muz lepe zadany
                    {
                        queue.Enqueue(jaka);
                        break;
                    }
                }
            }
        }

    }
}
