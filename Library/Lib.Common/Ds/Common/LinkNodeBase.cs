namespace Lib.Common.Ds.Common
{
    public class LinkNodeBase<T, TNext> : NodeBase<T> where TNext : NodeBase<T>
    {
        public virtual TNext Next
        {
            get
            {
                if (Siblings == null)
                    return default(TNext);

                return Siblings[0] as TNext;
            }

            set
            {
                if (Siblings == null)
                    Siblings = new NodeList<T>(1);

                Siblings[0] = value;
            }
        }
    }
}
