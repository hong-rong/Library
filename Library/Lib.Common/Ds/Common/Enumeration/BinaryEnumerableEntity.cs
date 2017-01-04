using System;
using System.Collections;
using System.Collections.Generic;

namespace Lib.Common.Ds.Common.Enumeration
{
    public class BinaryEnumerableEntity<TData, TChild> : IEnumerator<TChild>, IEnumerable<TChild> where TChild : BinaryNodeBase<TData, TChild>, new()
    {
        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public TChild Current { get; private set; }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public IEnumerator<TChild> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Dispose()
        {

        }
    }
}
