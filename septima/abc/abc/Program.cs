using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string vstup = Console.ReadLine();
            Graph graf = new Graph(vstup);
        }
        class Graph
        {
            private Dictionary<char, Node> nodes { get; set; }

            public Graph(string vstup)
            {
                nodes = new Dictionary<char, Node>();
                string[] slova = vstup.Split(' ');

                foreach (string s in slova) //všechny slova na vstupu
                {
                    foreach (char c in s) // projde všchny písmena
                    {
                        if (nodes.ContainsKey(c)) 
                        { }
                        else
                            nodes[c] = new Node(c);
                    }
                }
                for (int i = 0; i < slova.Length-1; i++) 
                {
                    string slovo1 = slova[i];
                    string slovo2 = slova[i+1];
                    int a = slovo1.Length;
                    int b = slovo2.Length;
                    int min = -1;
                    if (a <= b) 
                        min = a;
                    else
                        min = b;
                    for (int j = 0; j < min; j++)
                    {
                        if (slovo1[j] != slovo2[j])
                        {
                            nodes[slovo1[j]].Succesors.Add(nodes[slovo2[j]]);
                            nodes[slovo2[j]].Predecesors.Add(nodes[slovo1[j]]);
                            break;
                        }
                    }
                }

            }

            private Node DFS(Node initialNode) // vrací buď stok nebo null
            {
                initialNode.NodeState = Node.State.Open;
                int Time = 0;
                Node stok = null;
                DFS2(initialNode);
                return stok;

                void DFS2(Node node)
                {
                    node.NodeState = Node.State.Open;
                    Time += 1;
                    node.InTime = Time;
                    if (node.Succesors.Count > 0) // je kam pokračovat
                    {
                        foreach (Node successor in node.Succesors)
                        {
                            if (successor.NodeState == Node.State.Unvisited)
                            {
                                DFS2(successor);
                                if (stok != null) // pokud se našel stok
                                    return;
                            }
                        }
                        node.NodeState = Node.State.Closed;
                        Time += 1;
                        node.OutTime = Time;
                    }
                    else // našli jsme stok
                    {
                        stok = node;
                        return;
                    }

                }
            }
        }



        class Node
        {

            public Node(char letter)
            {
                Name = letter;

                Succesors = new List<Node>();
                Predecesors = new List<Node>();

                NodeState = State.Unvisited;
                InTime = null;
                OutTime = null;
            }
            public char Name { get; }

            public List<Node> Succesors { get; set; }
            public List<Node> Predecesors { get; set; }

            public enum State { Open, Unvisited, Closed }
            public State NodeState { get; set; }

            public int? InTime { get; set; }
            public int? OutTime { get; set; }

            public override string ToString()
            {
                return Name.ToString();
            }


        }
    }
}
