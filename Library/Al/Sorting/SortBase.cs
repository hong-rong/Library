using System;
using System.Diagnostics;

namespace Algorithm.Sorting
{
    public abstract class SortBase : ISort
    {
        public abstract void Sort(IComparable[] a);

        public virtual bool Less(IComparable v, IComparable w)
        {
            return v.CompareTo(w) < 0;
        }

        public virtual void Exchange(IComparable[] a, int i, int j)
        {
            IComparable t = a[i];
            a[i] = a[j];
            a[j] = t;
        }

        public virtual void Print(IComparable[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Debug.Write(string.Format("{0}, ", a[i]));
            }
            Debug.WriteLine("");
        }

        public virtual void PrintColumnNum(int num)
        {
            for (int i = 0; i < num; i++)
            {
                Debug.Write(string.Format("{0}, ", i));
            }
            Debug.WriteLine("");
        }
    }
}
