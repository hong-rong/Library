using Lib.Common.Ds.Common.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Common.Ds.Queue
{
    public class QueueEnumerableEntity<T> : EnumerableEntity<T>
    {
        protected DoubleLinkNode<T> Header;
        protected DoubleLinkNode<T> _last;

        private DoubleLinkNode<T> _enumerableItem;

        public override T Current
        {
            get { return _enumerableItem.Value; }
        }

        public override bool MoveNext()
        {
            if (_enumerableItem.Previous == null) return false;

            _enumerableItem = _enumerableItem.Previous;

            return true;
        }

        public override void Reset()
        {
            _enumerableItem = new DoubleLinkNode<T> { Previous = _last };
        }
    }
}