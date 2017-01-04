using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Algorithm.Fundamentals.BagsQueuesStacks
{
    public class DoublingStackOfStrings : FixedCapacityStackOfStrings
    {
        public DoublingStackOfStrings(int n)
            : base(n) { }

        private void Resize(int size)
        {
            string[] temp = new string[size];
            for (int i = 0; i < _a.Length; i++)
            {
                temp[i] = _a[i];
            }

            _a = temp;

            Debug.WriteLine(string.Format("Resize to {0}", _a.Length));
        }

        public override void Push(string t)
        {
            if (_n == _a.Length)
                Resize(_a.Length * 2);

            base.Push(t);
        }
    }
}
