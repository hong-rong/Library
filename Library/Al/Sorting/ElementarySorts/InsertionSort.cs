using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm.Sorting.ElementarySorts
{
    public class InsertionSort : SortBase
    {
        public override void Sort(IComparable[] a)
        {
            Print(a);
            for (int i = 1; i < a.Length; i++)
            {
                for (int j = i; j > 0 && Less(a[j], a[j - 1]); j--)
                {
                    Exchange(a, j, j - 1);
                }

                Print(a);
            }
        }
    }
}
