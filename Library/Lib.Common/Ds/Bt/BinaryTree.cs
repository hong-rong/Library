namespace Lib.Common.Ds.Bt
{
    public class BinaryTree<T>
    {
        public BinaryNode<T> Root;

        public BinaryTree()
        {
            Root = null;
        }

        public void Clear()
        {
            Root = null;
        }
    }
}
