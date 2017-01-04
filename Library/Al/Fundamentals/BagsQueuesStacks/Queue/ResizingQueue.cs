using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Algorithm.Fundamentals.BagsQueuesStacks.Queue
{
    public class ResizingQueue<T> : EnumerableQueue<T>
    {
        public ResizingQueue()
            : this(2)
        { }

        public ResizingQueue(int size)
            : base(size)
        { }

        public override void Enqueue(T t)
        {
            if (IsFull())
            {
                Debug.WriteLine(string.Format("Resize to {0}", Queue.Length * 2));
                Resizing(Queue.Length * 2);
            }

            EnqueueWithoutErrorCheck(t);
        }

        protected void Resizing(int size)
        {
            T[] temp = new T[size];

            for (int i = 0; i < Queue.Length; i++)
            {
                temp[i] = Queue[i];
            }

            if (End < Front)
            {
                for (int i = 0; i <= End; i++)
                {
                    temp[(Queue.Length + i) % size] = Queue[i];
                }
            }

            Queue = temp;
        }
    }
}
