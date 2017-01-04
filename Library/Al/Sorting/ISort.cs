using System;
namespace Algorithm.Sorting
{
    public interface ISort
    {
        void Exchange(IComparable[] a, int i, int j);

        bool Less(IComparable v, IComparable w);

        void Print(IComparable[] a);

        void Sort(IComparable[] a);
    }
}
