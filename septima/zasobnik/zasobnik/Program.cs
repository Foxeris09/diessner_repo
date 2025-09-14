using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zasobnik
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string vstup = Console.ReadLine();
            char[] zavorky = vstup.ToCharArray();
            bool vpoho = true;
            Stack<char> zasobnik = new Stack<char>();
            for (int i = 0; i < zavorky.Length;i++)
            {
                if (vpoho == false)
                    break;
                if (zavorky[i] == '(' || zavorky[i] == '[' || zavorky[i] == '{')
                    zasobnik.Push(zavorky[i]);
                else
                    vpoho = parovani(zavorky[i], zasobnik);
            }
            if (vpoho == true && zasobnik.Count == 0)
                Console.WriteLine("Správně");
            else
                Console.WriteLine("Špatně");
            Console.ReadLine();
           
        }
        static bool parovani(char a, Stack<char> c)
        {
            char b = c.Pop();
            if (a ==  ')')
            {
                if (b != '(')
                    return false;
                else return true;
            }
            
            if (a == ']')
            {
                if (b != '[')
                    return false;
                else return true;
            }
           
            if (a == '}')
            {
                if (b != '{')
                    return false;
                else return true;
            }
            else
                return true;
        }
    }
}
