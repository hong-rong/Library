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
    public class ResizableArray
    {
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

        public void Push(double item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, double item) //- inserts item at index, shifts that index's value and trailing elements to the right
        {
            throw new NotImplementedException();
        }

        public void Prepend(double item) //- can use insert above at index 0
        {
            throw new NotImplementedException();
        }

        public double Pop() //- remove from end, return value
        {
            throw new NotImplementedException();
        }

        public void Delete(int index) //- delete item at index, shifting all trailing elements left
        {
            throw new NotImplementedException();
        }

        public void Remove(double item) //- looks for value and removes index holding it (even if in multiple places)
        {
            throw new NotImplementedException();
        }

        public void Find(double item) //- looks for value and returns first index with that value, -1 if not found
        {
            throw new NotImplementedException();
        }

        public void Resize(int newCpacity) // private function
        {
            throw new NotImplementedException();
        }
    }

    //- ### Linked Lists
    //- [ ] implement (I did with tail pointer & without):
    //    - [ ] size() - returns number of data elements in list
    //    - [ ] empty() - bool returns true if empty
    //    - [ ] value_at(index) - returns the value of the nth item (starting at 0 for first)
    //    - [ ] push_front(value) - adds an item to the front of the list
    //    - [ ] pop_front() - remove front item and return its value
    //    - [ ] push_back(value) - adds an item at the end
    //    - [ ] pop_back() - removes end item and returns its value
    //    - [ ] front() - get value of front item
    //    - [ ] back() - get value of end item
    //    - [ ] insert(index, value) - insert value at index, so current item at that index is pointed to by new item at index
    //    - [ ] erase(index) - removes node at given index
    //    - [ ] value_n_from_end(n) - returns the value of the node at nth position from the end of the list
    //    - [ ] reverse() - reverses the list
    //    - [ ] remove_value(value) - removes the first item in the list with this value

    //- ### Queue
    //- [ ] Implement using linked-list, with tail pointer:
    //    - enqueue(value) - adds value at position at tail
    //    - dequeue() - returns value and removes least recently added element (front)
    //    - empty()
    //- [ ] Implement using fixed-sized array:
    //    - enqueue(value) - adds item at end of available storage
    //    - dequeue() - returns value and removes least recently added element
    //    - empty()
    //    - full()
    //- [ ] Cost:
    //    - a bad implementation using linked list where you enqueue at head and dequeue at tail would be O(n)
    //        because you'd need the next to last element, causing a full traversal each dequeue
    //    - enqueue: O(1) (amortized, linked list and array [probing])
    //    - dequeue: O(1) (linked list and array)
    //    - empty: O(1) (linked list and array)


    //- ### Hash table
    //- [ ] implement with array using linear probing
    //    - hash(k, m) - m is size of hash table
    //    - add(key, value) - if key already exists, update value
    //    - exists(key)
    //    - get(key)
    //    - remove(key)

    //- [ ] implement with array using hash chaining
}