using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Common
{
    //- ### Arrays
    //- [ ] Implement a vector (mutable array with automatic resizing):
    //    - [ ] Practice coding using arrays and pointers, and pointer math to jump to an index instead of using indexing.
    //    - [ ] new raw data array with allocated memory
    //        - can allocate int array under the hood, just not use its features
    //        - start with 16, or if starting number is greater, use power of 2 - 16, 32, 64, 128
    //    - [ ] size() - number of items
    //    - [ ] capacity() - number of items it can hold
    //    - [ ] is_empty()
    //    - [ ] at(index) - returns item at given index, blows up if index out of bounds
    //    - [ ] push(item)
    //    - [ ] insert(index, item) - inserts item at index, shifts that index's value and trailing elements to the right
    //    - [ ] prepend(item) - can use insert above at index 0
    //    - [ ] pop() - remove from end, return value
    //    - [ ] delete(index) - delete item at index, shifting all trailing elements left
    //    - [ ] remove(item) - looks for value and removes index holding it (even if in multiple places)
    //    - [ ] find(item) - looks for value and returns first index with that value, -1 if not found
    //    - [ ] resize(new_capacity) // private function
    //        - when you reach capacity, resize to double the size
    //        - when popping an item, if size is 1/4 of capacity, resize to half
    //- [ ] Time
    //    - O(1) to add/remove at end (amortized for allocations for more space), index, or update
    //    - O(n) to insert/remove elsewhere
    //- [ ] Space
    //    - contiguous in memory, so proximity helps performance
    //    - space needed = (array capacity, which is >= n) * size of item, but even if 2n, still O(n)

    public class ResizableArray<T>
    {
        private T[] _t;
        private int _n;

        public ResizableArray()
        {
            _t = new T[16];
            _n = 0;
        }

        public int Size() //- number of items
        {
            throw new NotImplementedException();
        }

        public int Capacity() //- number of items it can hold
        {
            throw new NotImplementedException();
        }

        public bool IsEmpty()
        {
            throw new NotImplementedException();
        }

        public void At(int index) //- returns item at given index, blows up if index out of bounds
        {
            throw new NotImplementedException();
        }

        public void Push(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item) //- inserts item at index, shifts that index's value and trailing elements to the right
        {
            throw new NotImplementedException();
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