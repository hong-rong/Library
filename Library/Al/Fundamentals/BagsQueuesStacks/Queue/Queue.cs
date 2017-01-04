using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm.Fundamentals.BagsQueuesStacks.Queue
{
    public class QueueBase<T>
    {
        protected T[] Queue;
        protected int Front;
        protected int End;
        protected int N;

        public QueueBase(int size)
        {
            Queue = new T[size];
            Front = 0;
            End = 0;
            N = 0;
        }

        public virtual void Enqueue(T t)
        {
            if (IsFull())
                throw new InvalidOperationException(string.Format("Full"));

            EnqueueWithoutErrorCheck(t);
        }

        protected void EnqueueWithoutErrorCheck(T t)
        {
            Queue[(End++) % Queue.Length] = t;
            N++;
        }

        public virtual T Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException(string.Format("Empty"));

            N--;

            return Queue[(Front++) % Queue.Length];
        }

        public virtual bool IsEmpty()
        {
            return N == 0;
        }

        protected virtual bool IsFull()
        {
            return N == Queue.Length;
        }

        public virtual int Size
        {
            get
            {
                return N;
            }
        }
    }
}
