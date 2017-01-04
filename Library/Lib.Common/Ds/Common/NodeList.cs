using System.Collections.ObjectModel;

namespace Lib.Common.Ds.Common
{
    public class NodeList<TValue> : Collection<NodeBase<TValue>>
    {
        public NodeList() : base() { }

        public NodeList(int size)
        {
            for (int i = 0; i < size; i++)
            {
                Items.Add(default(NodeBase<TValue>));
            }
        }

        public NodeBase<TValue> FindByValue(TValue value)
        {
            foreach (var item in Items)
                if (item.Value.Equals(value))
                    return item;

            return null;
        }
    }
}
