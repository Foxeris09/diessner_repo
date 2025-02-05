using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BST //binary search tree - binární vyhledávací strom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Node<string> node1 = new Node<string>(1,"ahoj");
            Node<string> node2 = new Node<string>(2, "cs");
            Node<string> node3 = new Node<string>(4, "nazdar");

            node2.Levy = node1;
            node2.Pravy = node3;

            BinarniVyhledavaciStrom<string> strom = new BinarniVyhledavaciStrom<string>();
            strom.Koren = node2;

            strom.Insert(3, "ahojdaa");
            Console.WriteLine(strom.Find(3));
            Console.WriteLine(strom.Min(strom.Koren));
            Console.WriteLine(strom.Show());
            Console.ReadLine();

        }
    }

    class Node<T> // generický typ T
    {
        public int Key { get; set; } // neměnitelné, muselo by být set zatím
        public T Value { get; set; } //má obecný typ
        public Node<T> Levy { get; set; }
        public Node<T> Pravy { get; set; }


        // konstruktor
        public Node(int key, T value)
        {
            Key = key;
            Value = value;
        }
    }
    class BinarniVyhledavaciStrom<T>
    { 
        public Node<T> Koren { get; set; }

        public string Show()
        {
            //vrací string, abychom mohli použít cw tab tab

            string output = "";

            void _show(Node<T> node)
            {
                if (node == null)
                    return;
                _show(node.Levy);

                output += node.Key.ToString() + " ";

                _show(node.Pravy);

            }
            if (Koren == null)
                return "Strom je prázdný";
            _show(Koren);
            return output;

        }

        public T Find(int key)
        {
            Node<T> _find(Node<T> node, int key2)
            {
                if (node == null)
                    return null;
                if (node.Key == key2)
                    return node;
                if (key2 < node.Key)
                    return _find(node.Levy, key2);
                else
                    return _find(node.Pravy, key2);

            }
            Node<T> output = _find(Koren, key);
            if (output == null)
                return default(T);
            return output.Value;
        }

        public T Min(Node<T> v)
        {
            Node<T> _min(Node<T> node)
            {
                if (node.Levy == null)
                    return node;
                else
                    return _min(node.Levy);
            }

            
            return _min(v).Value;


        }

        public void Insert(int key, T value)
        {
            void _insert(Node<T> node)
            {

                
                if (key < node.Key)
                {
                    if (node.Levy == null)
                    {
                        node.Levy = new Node<T>(key, value);
                        return;
                    }
                    _insert(node.Levy);
                }
                if (key > node.Key)
                {
                    if(node.Pravy == null)
                    {
                        node.Pravy = new Node<T>(key,value);
                        return;
                    }
                    _insert(node.Pravy);
                }
                else                
                    return;
                
            }
            
            
             _insert(Koren);
           
        }

        public void Delete(int key)
        {
            
                
            void _delete(Node<T> v)
            {
                if (v == null)
                    return;
                if (key < v.Key)
                    _delete(v.Levy);
                if (key > v.Key)
                    _delete(v.Pravy);
                else
                {
                    if (v.Levy == null && v.Pravy == null)                    
                        v = null;                    
                    if (v.Levy == null)
                        v = v.Pravy;
                    if (v.Pravy == null)
                        v = v.Levy; // KROK 7!





                }
            }




            _delete(Koren);

        }
    }
}
