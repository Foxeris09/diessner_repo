using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace fixtree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zadej Postfix");
            string vstup = Console.ReadLine();

            FixTree fixTree = new FixTree();
            fixTree.ExpressionTree(vstup);

            Console.WriteLine("Prefix:");
            Console.WriteLine(fixTree.VypisPrefix());

            Console.WriteLine("Infix:");
            Console.WriteLine(fixTree.VypisInfix());

            Console.WriteLine("Postfix:");
            Console.WriteLine(fixTree.VypisPostfix());

            Console.WriteLine("Vysledek:");
            Console.WriteLine(Postfix(vstup));
            Console.ReadLine();
        }
        static float? Postfix(string list1)
        {
            string[] list = list1.Split(' ');
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

    class Node
    {
        public string Operator { get; set; }
        public float Operand { get; set; }
        public Node Levy { get; set; }
        public Node Pravy { get; set; }
        public Node Rodic { get; set; }
        public bool jeCislo { get; set; }

        public Node(string value)
        {
            try
            {
                Operand = float.Parse(value, CultureInfo.InvariantCulture);
                jeCislo = true;
            }
            catch
            {
                Operator = value;
                jeCislo = false;
            }
            Levy = null;
            Pravy = null;
            Rodic = null;
        }

    }
    class FixTree
    {
        Node koren { get; set; }
        public void ExpressionTree(string list) 
        {
            Stack<Node> stack = new Stack<Node>();
            string[] postfix = list.Split(' ');
            foreach (string prvek in postfix) 
            { 
                Node node = new Node(prvek);
                if(node.jeCislo == true)
                    stack.Push(node);
                else
                {
                    Node b = stack.Pop();
                    Node a = stack.Pop();
                    node.Levy = a;
                    node.Pravy = b;
                    a.Rodic = node;
                    b.Rodic = node;
                    stack.Push(node);
                }
            }
            if (stack.Count == 1)
                koren = stack.Pop();
            else
                koren = null;
        }
        public string VypisPrefix()
        {
            if (koren == null)
                return "Nezakořenils";
            StringBuilder sb = new StringBuilder();
            void _prefix(Node node)
            {
                if (node.jeCislo == true)           // vloží do stringBuilderu operator nebo operand
                    sb.Append(node.Operand + " ");
                else
                {
                    sb.Append(node.Operator + " ");
                    
                }
                if(node.Levy != null)
                {
                    _prefix(node.Levy);    //když má levého jde do levého podstromu
                }
                if (node.Pravy != null)
                {
                    _prefix(node.Pravy);
                }
            }
            _prefix(koren);
            return sb.ToString();

        }
        public string VypisInfix()
        {
            if (koren == null)
                return "Nezakořenils";
            StringBuilder sb = new StringBuilder();
            void _infix(Node node)
            {
                if (node.jeCislo != true)
                    sb.Append("(");
                else
                {
                    sb.Append(node.Operand);
                    
                }
                if (node.Levy != null)
                {
                    _infix(node.Levy);
                    sb.Append( " " + node.Operator + " ");
                }
                
                if (node.Pravy != null)
                {
                    _infix(node.Pravy);
                    sb.Append(")");
                }
                
            }
            _infix(koren);
            sb.Remove(0,1);
            sb.Remove(sb.Length-1,1);
            return sb.ToString();
        }
        public string VypisPostfix()
        {
            if (koren == null)
                return "Nezakořenils";
            StringBuilder sb = new StringBuilder();
            void _postfix(Node node)
            {
                if (node.Levy != null)
                {
                    _postfix(node.Levy);
                }
                if (node.Pravy != null)
                {
                    _postfix(node.Pravy);
                }
                if (node.jeCislo == true)           // vloží do stringBuilderu operator nebo operand
                    sb.Append(node.Operand + " ");
                else
                {
                    sb.Append(node.Operator + " ");
                }
            }
            _postfix(koren);
            return sb.ToString();
               
        }

    }
}
