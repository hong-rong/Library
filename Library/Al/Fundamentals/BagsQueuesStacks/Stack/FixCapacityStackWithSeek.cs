using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm.Fundamentals.BagsQueuesStacks
{
    public class FixCapacityStackWithSeek<T> : EnumerableFixCapacityStack<T>
    {
        protected T _recent;

        public FixCapacityStackWithSeek(int n)
            : base(n)
        {
            _recent = default(T);
        }

        public override void Push(T t)
        {
            _recent = t;

            base.Push(t);
        }

        public T Seek()
        {
            return _recent;
        }
    }
}
