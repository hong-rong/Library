namespace Lib.Common.Ds.Ll
{
    public interface ILinkedList<T>
    {
        T Get(int index);

        /// <summary>
        /// first occurrence
        /// </summary>
        int FirstIndexOf(T t);

        bool Contains(T t);

        int Size();

        void AddFirst(T t);

        void AddLast(T t);

        void Add(int index, T t);

        T RemoveFirst();

        T RemoveLast();

        /// <summary>
        /// remove item in position index
        /// </summary>
        T Remove(int index);

        void Clear();

        T[] ToArray();
    }
}