using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace fix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int co = Vstup();
            Fix fix = new Fix();
            fix.Main2(co);
            Console.ReadLine();
        }

        static int Vstup()
        {
            Console.WriteLine("Pro vyhodnocení Prefixu zadej: 1 ");
            Console.WriteLine("Pro vyhodnocení Postfixu zadej: 2");
            return Convert.ToInt16(Console.ReadLine());
        }
    }
    //moje classa
    class Fix
    {
        public void Main2(int jakyFix)
        {
            
            if (jakyFix == 1)
            {
                string[] list = vstupPre();
                float? vysledek = Prefix(list);
                Console.WriteLine(vysledek);
            }
            else if (jakyFix == 2)
            {
                string[] list = vstupPost();
                float? vysledek = Postfix(list);
                Console.WriteLine(vysledek);
            }
            else
            {
                Console.WriteLine("Nebylo zadáno číslo vyhovující poadavkům.");
            }
        }

        string[] vstupPost()
        {
            string[] vstup = Console.ReadLine().Split(' ');
            return vstup;
        }

        string[] vstupPre()
        {
            string[] vstup = Console.ReadLine().Split(' ');
            Array.Reverse(vstup);
            return vstup;
        }

        float? Postfix(string[] list)
        {
            Stack<float> stack = new Stack<float>();
            for (int i = 0; i < list.Length; i++)
            {
                try
                {
                    float operand = float.Parse(list[i], CultureInfo.InvariantCulture);
                    stack.Push(operand);
                }
                catch 
                {
                    char operato = Convert.ToChar(list[i]);
                    float a;
                    float b;
                    try
                    {
                        b = stack.Pop();
                        a = stack.Pop();
                    }
                    catch 
                    {
                        Console.WriteLine("Nedostatek operandů v zásobníku");
                        return null;
                    }
                    switch (operato)
                    {
                        case '+':
                            stack.Push(a + b);
                            break;
                        case '-':
                            stack.Push(a - b);
                            break;
                        case '*':
                            stack.Push(a * b);
                            break;
                        case '/':
                            if(b==0)
                            {
                                Console.WriteLine("Neděl nulou!");
                                return null;
                            }
                            float cislo = a / b;
                            stack.Push(cislo);
                            break;
                    }
                }

            }
            if (stack.Count != 1)
            {
                Console.WriteLine("Špatný počet operandů a operátorů");
                return null;
            }
            else
            {  

                return stack.Pop();
            }

        }
        float? Prefix(string[] list)
        {
            Stack<float> stack = new Stack<float>();
            for (int i = 0; i < list.Length; i++)
            {
                try
                {
                    float operand = float.Parse(list[i], CultureInfo.InvariantCulture);
                    stack.Push(operand);
                }
                catch
                {
                    char operato = Convert.ToChar(list[i]);
                    float a;
                    float b;
                    try
                    {
                        a = stack.Pop();
                        b = stack.Pop();
                    }
                    catch
                    {
                        Console.WriteLine("Nedostatek operandů v zásobníku");
                        return null;
                    }
                    switch (operato)
                    {
                        case '+':
                            stack.Push(a + b);
                            break;
                        case '-':
                            stack.Push(a - b);
                            break;
                        case '*':
                            stack.Push(a * b);
                            break;
                        case '/':
                            if (b == 0)
                            {
                                Console.WriteLine("Neděl nulou!");
                                return null;
                            }
                            float cislo = a / b;
                            stack.Push(cislo);
                            break;
                    }
                }

            }
            if (stack.Count != 1)
            {
                Console.WriteLine("Špatný počet operandů a operátorů");
                return null;
            }
            else
            {

                return stack.Pop();
            }

        }
    }
}
