using System.Collections;
using System.Collections.Generic;

namespace Lib.Common.Ds.Common.Enumeration
{
    public abstract class EnumerableEntity<TData> : IEnumerator<TData>, IEnumerable<TData>
    {
        public abstract TData Current { get; }

        public abstract bool MoveNext();

        public abstract void Reset();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public virtual IEnumerator<TData> GetEnumerator()
        {
            Reset();

            while (MoveNext())
            {
                yield return Current;
            }
        }

        public void Dispose()
        { }
    }
}