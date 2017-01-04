using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm.Fundamentals.BagsQueuesStacks
{
    public class FixedCapacityStackOfStrings : EnumerableFixCapacityStack<string>
    {
        public FixedCapacityStackOfStrings(int capacity)
            : base(capacity)
        { }
    }
}
