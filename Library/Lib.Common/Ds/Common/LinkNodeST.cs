namespace Lib.Common.Ds.Common
{
    public class LinkNodeST<TKey, TValue> : LinkNodeBase<TValue, LinkNodeST<TKey, TValue>>
    {
        public TKey Key;
    }
}
