using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm.Fundamentals.BagsQueuesStacks.LinkedList
{
    public class NodeBase<T>
    {
        private int _id;

        public NodeBase(int id)
        {
            _id = id;
        }

        public virtual int Id
        {
            get { return _id; }
        }

        public virtual T Item { get; set; }
    }
}
