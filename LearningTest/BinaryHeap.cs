using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    /// <summary>
    /// For complete balanced binary tree
    /// </summary>
    class BinaryHeap<T>
       
    {
        List<T> a = new List<T>();
        Func<T,T,int> _comparer { get; }

        public int Count => a.Count;
        public T Root => a.Count > 0 ? a[0] : default(T);

        
        public BinaryHeap(Func<T,T,int> comparer)
        {
            _comparer = comparer;
        }
        
        public int left(int i) => 2 * i + 1;
        public int right(int i) => 2 * i + 2;
        public int parent(int i) => (i - 1) / 2;


        public bool add (T x)
        {
            a.Add(x);
            bubleUp(a.Count - 1);
            return true;
        }
       
        public T remove()
        {
            T x = a[0];
            int n = a.Count - 1;  // last index (before removal)
            a[0] = a[n];
            a.RemoveAt(n);
            trickleDown(0);
            
            return x;
        }
        private void swap (int i, int p)
        {
            T temp = a[i];
            a[i] = a[p];
            a[p] = temp;
        }
        
        private void  bubleUp(int i)
        {
            int p = parent(i);
            while (i>0 && _comparer(a[i],a[p])<0)
            {
                swap(i, p);
                i = p;
                p = parent(i);
            }
        }
        
        private void trickleDown(int i)
        {
            do
            {
                int j = -1;
                int r = right(i);
                if (r < a.Count && _comparer(a[r],a[i]) < 0)
                {
                    int l = left(i);
                    if ( _comparer(a[l],a[r]) < 0)
                    {
                        j = l;
                    }
                    else
                    {
                        j = r;
                    }
                }
                else
                {
                    int l = left(i);
                    if (l < a.Count && _comparer(a[l],a[i]) < 0)
                    {
                        j = l;
                    }
                }
                if (j >= 0) swap(i, j);   //swap parent and child
                i = j;
            } while (i >= 0);

        }

       
    }
}
