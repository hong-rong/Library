namespace Lib.Common.Ds.Common
{
    public class NodeBase<TValue>
    {
        private TValue _value;

        public NodeBase()
        { }

        public NodeBase(TValue data)
            : this(data, null)
        { }

        public NodeBase(TValue value, NodeList<TValue> siblings)
        {
            _value = value;
            Siblings = siblings;
        }

        public virtual TValue Value
        {
            get { return _value; }
            set { _value = value; }
        }

        protected NodeList<TValue> Siblings { get; set; }
    }
}
