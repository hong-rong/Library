using System;

namespace Lib.Exercise
{
    //- [ ] Implement a vector (mutable array with automatic resizing):
    //        - when you reach capacity, resize to double the size
    //        - when popping an item, if size is 1/4 of capacity, resize to half
    //- [ ] Time
    //    - O(1) to add/remove at end (amortized for allocations for more space), index, or update
    //    - O(n) to insert/remove elsewhere
    //- [ ] Space
    //    - contiguous in memory, so proximity helps performance
    //    - space needed = (array capacity, which is >= n) * size of item, but even if 2n, still O(n)
    public class Ra<T>
    {
        private T[] _arr;
        private int _index;

        public Ra()
        {
            _arr = new T[16];
            _index = -1;
        }

        public int Size() //- number of items
        {
            return _index + 1;
        }

        public int Capacity() //- number of items it can hold
        {
            return _arr.Length;
        }

        public bool IsEmpty()
        {
            return _index == -1;
        }

        public T At(int index) //- returns item at given index, blows up if index out of bounds
        {
            if (index > _index || index < 0) throw new ArgumentException("out of range");
            return _arr[index];
        }

        public void Push(T item)
        {
            if (Size() == Capacity())
                Resize(2 * Capacity());
            _arr[++_index] = item;
        }

        public void Insert(int index, T item) //- inserts item at index, shifts that index's value and trailing elements to the right
        {
            if (index > _index || index < 0) throw new ArgumentException("out of range");
            if (Size() == Capacity()) Resize(2 * Capacity());
            for (int i = _index + 1; i > index; i++)
            {
                _arr[i] = _arr[i - 1];
            }
            _arr[index] = item;
        }

        public void Prepend(T item) //- can use insert above at index 0
        {
            throw new NotImplementedException();
        }

        public T Pop() //- remove from end, return value
        {
            throw new NotImplementedException();
        }

        public void Delete(int index) //- delete item at index, shifting all trailing elements left
        {
            throw new NotImplementedException();
        }

        public void Remove(T item) //- looks for value and removes index holding it (even if in multiple places)
        {
            throw new NotImplementedException();
        }

        public void Find(T item) //- looks for value and returns first index with that value, -1 if not found
        {
            throw new NotImplementedException();
        }

        public void Resize(int newCpacity) // private function
        {
            throw new NotImplementedException();
        }
    }
}