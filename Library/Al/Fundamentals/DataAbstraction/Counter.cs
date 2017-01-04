using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm.Fundamentals.DataAbstraction
{
    public class Counter
    {
        private string _id;
        private int _counter;

        public Counter(string Id)
        {
            _id = Id;
            _counter = 0;
        }

        public void Increment() { _counter++; }

        public int Tally() { return _counter; }

        public override string ToString()
        {
            return string.Format("{0}: {1}", _id, _counter);
        }
    }
}
