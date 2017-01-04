using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Common
{
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