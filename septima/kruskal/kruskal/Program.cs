using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace kruskal
{
    internal class Program
    {
        public class UnionFind
        {
            private int[] parent;
            private int[] hloubka;
            public UnionFind(int n)
            {
                parent = new int[n];
                hloubka = new int[n];
                for (int i = 0; i < n; i++)
                {
                    parent[i] = i;
                    hloubka[i] = 0;
                }
            }
            public int koren(int i)
            {
                while (parent[i] != i) 
                {
                    i = parent[i];
                }
                return i;
            }
            public bool Find(int u, int v) 
            {
                if (koren(u) == koren(v))
                    return true;
                else return false;
            }
            public void Union(int u, int v)
            {
                int a = koren(u);
                int b = koren(v);
                if (a != b)
                {
                    if (hloubka[a] < hloubka[b])
                        parent[a] = b;
                    else if (hloubka[a] > hloubka[b])
                        parent[b] = a;
                    else
                    {
                        parent[b] = a;
                        hloubka[a]++;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
        }
    }
}
