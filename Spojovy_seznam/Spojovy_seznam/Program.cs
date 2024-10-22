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
            LinkedList seznam = new LinkedList();
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

            public void Add(int value)  //slozitost O(1)
            {
                if (Head == null)
                    Head = new Node(value);
                else
                {
                    Node newNode = new Node(value);
                    newNode.Next = Head;
                    Head = newNode;
                }

            }
            public bool Find(int value)  //slozitost O(n)
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
            public int Min()  //slozitost O(n)
            {
                if(Head == null)
                    return 0;
                int minimum = Head.Value;
                Node ted = Head.Next;
                while (ted != null) 
                {
                    if (ted.Value <= minimum)
                        minimum = ted.Value;
                    ted = ted.Next;
                }
                return minimum;
            }
        }
    }
}
