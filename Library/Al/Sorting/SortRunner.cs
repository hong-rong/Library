using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm.Sorting
{
    public class SortRunner
    {
        protected ISort _sort;

        public SortRunner(ISort sort)
        {
            _sort = sort;
        }

        public void RunSort(IComparable[] a)
        {
            _sort.Sort(a);
        }
    }
}
