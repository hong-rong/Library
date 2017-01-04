using System;

namespace Algorithm.Sorting.MergeSort
{
    public class Bound
    {
        public int Low { get; set; }
        public int High { get; set; }
        public int Middle
        {
            get { return (High + Low) / 2; }
        }

        public int Length
        {
            get { return High - Low + 1; }
        }
    }

    public class MergeSortV2 : SortBase
    {
        private IComparable[] _aux;

        public override void Sort(IComparable[] a)
        {
            _aux = new IComparable[a.Length];
            //System.Diagnostics.Debug.WriteLine(Merge(a, 0, a.Length / 2, a.Length / 2 + 1, a.Length - 1));

            //Print(MergeSort(a));
            MergeSort(a, new Bound { Low = 0, High = a.Length - 1 });
            Print(_aux);
        }

        //private IComparable[] MergeSort(IComparable[] a)
        //{
        //    IComparable[] a1 = new IComparable[a.Length / 2];
        //    IComparable[] a2 = new IComparable[a.Length - a.Length / 2];
        //    Array.Copy(a, a1, a.Length / 2);
        //    Array.Copy(a, a.Length / 2, a2, 0, a.Length - a.Length / 2);

        //    if (a.Length > 1)
        //        return Merge(MergeSort(a1), MergeSort(a2));

        //    return a;
        //}

        private Bound MergeSort(IComparable[] a, Bound b)
        {
            if (b.Length > 1)
            {
                var lowBound = new Bound { Low = b.Low, High = b.Middle };
                var highBound = new Bound { Low = b.Middle + 1, High = b.High };

                return Merge(a, MergeSort(a, lowBound), MergeSort(a, highBound));
            }
            else
                return b;
        }

        private Bound Merge(IComparable[] a, Bound l, Bound h)
        {
            if (l.Low == l.High)
            {
                CopyToAux(a, h);
                return h;
            }
            if (h.Low == h.High)
            {
                CopyToAux(a, l);
                return l;
            }

            //if (!Less(a[l.Low], a[h.Low]))
            if (a[l.Low].CompareTo(a[h.Low]) <= 0)
            {
                _aux[l.Low] = a[l.Low];
                Merge(a, new Bound() { Low = l.Low + 1, High = l.High }, h);

                return l;
            }
            else
            {
                _aux[h.Low] = a[h.Low];
                Merge(a, l, new Bound() { Low = h.Low + 1, High = h.High });

                return h;
            }
        }

        private void CopyToAux(IComparable[] arr, Bound b)
        {
            for (var i = b.Low; i <= b.High; i++)
            {
                _aux[i] = arr[i];
            }
        }

        private IComparable[] Merge(IComparable[] a, IComparable[] b)
        {
            if (a.Length == 0) return b;
            if (b.Length == 0) return a;

            if (!Less(a[0], b[0]))
            {
                IComparable[] b1 = new IComparable[b.Length - 1];
                Array.Copy(b, 1, b1, 0, b.Length - 1);
                return Concat(b[0], Merge(a, b1));
            }
            else
            {
                IComparable[] a1 = new IComparable[a.Length - 1];
                Array.Copy(a, 1, a1, 0, a.Length - 1);
                return Concat(a[0], Merge(a1, b));
            }
        }

        private IComparable[] Concat(IComparable comparable1, IComparable[] comparable2)
        {
            IComparable[] a = new IComparable[comparable2.Length + 1];
            a[0] = comparable1;
            Array.Copy(comparable2, 0, a, 1, a.Length - 1);

            return a;
        }

        //private string IntArrayToString(IComparable[] a, int h1, int h2)
        //{
        //    StringBuilder sb = new StringBuilder();

        //    for (int i = h1; i <= h2; i++)
        //        sb.Append(a[i]);

        //    return sb.ToString();
        //}

        //private void Merge(IComparable[] a, int l1, int l2, int h1, int h2)
        //{
        //    if (l2 == l1) return;
        //    if (h2 == h1) return;

        //    if (!Less(a[l1], a[h1]))
        //    {
        //        //Exchange(a, l1, h1);
        //        _aux[l1] = a[h1];

        //        Merge(a, l1, l2, h1 + 1, h2);
        //    }
        //    else
        //    {
        //        //Exchange(a, l1, h1);
        //        _aux[h1] = a[h1];

        //        Merge(a, l1 + 1, l2, h1, h2);
        //    }
        //}
    }
}
