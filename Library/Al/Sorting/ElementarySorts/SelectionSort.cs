using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Algorithm.Sorting.ElementarySorts
{
    public class SelectionSort : SortBase
    {
        public override void Sort(IComparable[] a)
        {
            Print(a);
            for (int i = 0; i < a.Length; i++)
            {
                int min = i;
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (Less(a[j], a[min]))
                    {
                        min = j;
                    }
                }

                Exchange(a, i, min);

                Print(a);
            }
        }
    }
}
