using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm.Fundamentals.BagsQueuesStacks
{
    public class FixCapacityStack<T> 
    {
        protected T[] _a;

        protected int _n;

        public FixCapacityStack(int n)
        {
            _a = new T[n];
            _n = 0;
        }

        public virtual bool IsEmpty()
        {
            return _n == 0;
        }

        public virtual bool IsFull()
        {
            return _n == _a.Length;
        }

        public virtual int Size
        {
            get { return _n; }
        }

        public virtual void Push(T t)
        {
            _a[_n++] = t;
        }

        public virtual T Pop()
        {
            return _a[--_n];
        }
    }
}
