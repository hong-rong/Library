namespace Lib.Common.Ds.Common
{
    public class BinaryNodeBase<TValue, TChild> : NodeBase<TValue> where TChild : NodeBase<TValue>
    {
        public virtual TChild Left
        {
            get
            {
                if (Siblings == null)
                    return null;

                return Siblings[0] as TChild;
            }

            set
            {
                if (Siblings == null)
                    Siblings = new NodeList<TValue>(2);

                Siblings[0] = value;
            }
        }

        public virtual TChild Right
        {
            get
            {
                if (Siblings == null)
                    return null;

                return Siblings[1] as TChild;
            }

            set
            {
                if (Siblings == null)
                    Siblings = new NodeList<TValue>(2);

                Siblings[1] = value;
            }
        }
    }
}
