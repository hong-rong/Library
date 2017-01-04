namespace Lib.Common.Ds.Common.Enumeration
{
    public class LinkedListEnumerable<TData> : EnumerableEntity<TData>
    {
        protected LinkNode<TData> Header;

        protected LinkNode<TData> _enumerableItem;

        public override TData Current
        {
            get { return _enumerableItem.Value; }
        }

        public override bool MoveNext()
        {
            if (_enumerableItem.Next == null) return false;

            _enumerableItem = _enumerableItem.Next;

            return true;
        }

        public override void Reset()
        {
            //this is important!!!
            _enumerableItem = new LinkNode<TData> { Next = Header };
        }
    }
}
