using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fixtree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string vstup = Console.ReadLine();

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
        void ExpressionTree(string list) 
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
        void VypisPrefix()
        {
            if (koren == null)
                return;
            StringBuilder sb = new StringBuilder();
            void _prefix(Node node)
            {
                if (node.jeCislo == true)           // vloží do stringBuilderu operator nebo operand
                    sb.Append(node.Operand);
                else
                    sb.Append(node.Operator);
                if(node.Levy != null)
                {
                    _prefix(node.Levy);    //když má levého jde do levého podstromu
                }
            }

        }
    }
}
