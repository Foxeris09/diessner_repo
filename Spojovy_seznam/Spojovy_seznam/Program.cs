﻿using System;
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
<<<<<<< Updated upstream
            LinkedList seznam = new LinkedList();
            seznam.Add(1);
            seznam.Add(1);
            seznam.Add(2);
            seznam.Add(7);
            seznam.Add(-1);

            LinkedList seznam2 = new LinkedList();
            seznam2.Add(3);
            seznam2.Add(7);
            seznam2.Add(1);
            seznam2.Add(3);
            seznam2.Add(-1);

           
            Console.ReadLine();
=======
            LinkedList linkedList = new LinkedList();
            linkedList.Add(4);
            linkedList.Add(5);  
            linkedList.Add(2);
            linkedList.Add(7);
            Console.WriteLine(linkedList.PrintLinkedList());
            linkedList.SortLinkedList();
            Console.WriteLine(linkedList.PrintLinkedList());
            Console.ReadLine();

>>>>>>> Stashed changes
        }

        class Node
        {
            public Node(int value) //konstruktor
            {
                Value = value;
            }
            public int Value { get; set; }
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
<<<<<<< Updated upstream
            public int Min()  //slozitost O(n)
            {
                if (Head == null)
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
=======
>>>>>>> Stashed changes
            public string PrintLinkedList()
            {
                if (Head == null)
                    return "Seznam je prázdný";
                Node praveTed = Head;
                StringBuilder listCisel = new StringBuilder();

                while (praveTed != null)
                {
                    listCisel.Append(praveTed.Value + " ");
                    praveTed = praveTed.Next;
                }
                return listCisel.ToString();
            }

            public void SortLinkedList()
            {
<<<<<<< Updated upstream
                if (Head == null)
                    return;

                Node praveTed = Head;
                int promena = 0;
                bool uz = false;
                while (true)
                {
                    uz = false;
                    praveTed = Head;
                    while (praveTed != null)
=======
                
                if (Head == null)
                    return;
                Node praveTed = Head;
                int promena = 0;
                while(true)
                {
                    bool uz = false;
                    while (praveTed.Next != null)
>>>>>>> Stashed changes
                    {
                        if (praveTed.Value > praveTed.Next.Value)
                        {
                            promena = praveTed.Value;
                            praveTed.Value = praveTed.Next.Value;
                            praveTed.Next.Value = promena;
                            uz = true;
<<<<<<< Updated upstream
                        }
                        praveTed = praveTed.Next;
                    }
                    if (uz == false)
                        break;
                }
            }

            public void ClearList()
            {
                Head = null;
            }

            public static void AbradabraFucDuplicates(LinkedList list) 
            {
                if (list == null) return;
                if (list.Head == null) return;
                else
                {
                    Node praveTed = list.Head;
                    while (praveTed.Next != null)
                    {
                        Node promenaKontrola = praveTed;
                        while (promenaKontrola.Next != null)
                        {
                            if (promenaKontrola.Next.Value == praveTed.Value)
                            {
                                promenaKontrola.Next = promenaKontrola.Next.Next; //odstraním uzel
                            }
                            else
                            {
                                promenaKontrola = promenaKontrola.Next;
                            }
                        }
                        if (praveTed.Next == null)
                            break;
                        praveTed = praveTed.Next;
                    }
                }
            }

            public static void DestruktivniPrunik(LinkedList list1, LinkedList list2)
            {
                AbradabraFucDuplicates(list1);
                Node praveTed1 = list1.Head;
                Node predTed1 = null;

                while (praveTed1 != null)
                {
                    Node praveTed2 = list2.Head;
                    bool nalezenoVlist2 = false;

                    while (praveTed2 != null)
                    {
                        if (praveTed1.Value == praveTed2.Value) //najdu stejný prvek v obou seznamech
                        {
                            nalezenoVlist2 = true;
                            break;
                        }
                        praveTed2 = praveTed2.Next;
                    }

                    if (nalezenoVlist2 == false) 
                    {
                        if (predTed1 != null) 
                        {
                            predTed1.Next = praveTed1.Next; 
                        }
                        else 
                        {
                            list1.Head = praveTed1.Next;
                        }
                        praveTed1 = praveTed1.Next;
                    }
                    else 
                    {
                        predTed1 = praveTed1;
                        praveTed1 = praveTed1.Next;
                    }
                }
                list2.ClearList();
            }

            public static void DestruktivniSjednoceni(LinkedList list1, LinkedList list2)
            {
                AbradabraFucDuplicates(list1);
                AbradabraFucDuplicates(list2);

                Node praveTed1 = list1.Head;
                Node praveTed2 = list2.Head;

                while (praveTed2 != null)
                {
                    if (list1.Find(praveTed2.Value) == false)
                    {
                        list1.Add(praveTed2.Value);
                    }
                    praveTed2 = praveTed2.Next;
                }
                list2.ClearList();

            }

=======
                            
                        }
                        praveTed = praveTed.Next;
                    }
                    
                    if (uz == false)
                        break;
                    praveTed = Head;
                    
                }
                      


            }
>>>>>>> Stashed changes
        }
    }
}
