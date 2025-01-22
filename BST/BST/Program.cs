using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST //binary search tree - binární vyhledávací strom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Node<Person> node = new Node<Person>(); // místo T mužu dávat jakýkoliv typ
            Node<int> node2 = new Node<int>();
        }
    }

    class Node<T> // generický typ T
    {
        public int Key { get; }  // neměnitelné, muselo by být set zatím
        public T Value { get; } //má obecný typ
    }
    class Person
    { 
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
