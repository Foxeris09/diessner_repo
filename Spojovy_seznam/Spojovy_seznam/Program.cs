using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spojovy_seznam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Node uzlik = new Node(8);
        }

        class Node
        {
            public Node(int value) //konstruktor
            {
                Value = value;
            }
            public int Value { get; }
            public Node Next { get; set; }
        }

        class LinkedList
        {
            public Node Head { get; set; }

            public void Add(int value)
            {
                if (Head == null)
                    Head = new Node(value);
                else
                {
                    Node newNode = new Node(value);
                    Head = newNode;
                }

            }
            public bool Find(int value)
            {
                
                Node node = Head;
                while (node != null)
                {
                    if (node.Value == value)
                        return true;
                    node = node.Next;
                }
                return false;
            }
        }
    }
}
