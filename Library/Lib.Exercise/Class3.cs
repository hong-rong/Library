namespace Lib.Exercise
{
    //- ### Trees - Notes & Background
    //- [ ] [Series: Core Trees (video)](https://www.coursera.org/learn/data-structures-optimizing-performance/lecture/ovovP/core-trees)
    //- [ ] [Series: Trees (video)](https://www.coursera.org/learn/data-structures/lecture/95qda/trees)
    //- basic tree construction
    //- traversal
    //- manipulation algorithms
    //- BFS (breadth-first search)
    //    - [MIT (video)](https://www.youtube.com/watch?v=s-CYnVz-uh4&list=PLUl4u3cNGP61Oq3tWYp6V_F-5jb5L2iHb&index=13)
    //    - level order (BFS, using queue)
    //        time complexity: O(n)
    //        space complexity: best: O(1), worst: O(n/2)=O(n)
    //- DFS (depth-first search)
    //    - [MIT (video)](https://www.youtube.com/watch?v=AfSk24UTFS8&list=PLUl4u3cNGP61Oq3tWYp6V_F-5jb5L2iHb&index=14)
    //    - notes:
    //        time complexity: O(n)
    //        space complexity:
    //            best: O(log n) - avg. height of tree
    //            worst: O(n)
    //    - inorder (DFS: left, self, right)
    //    - postorder (DFS: left, right, self)
    //    - preorder (DFS: self, left, right)

    //- ### Binary search trees: BSTs
    //- [ ] Implement:
    //    - [ ] insert    // insert value into tree
    //    - [ ] get_node_count // get count of values stored
    //    - [ ] print_values // prints the values in the tree, from min to max
    //    - [ ] delete_tree
    //    - [ ] is_in_tree // returns true if given value exists in the tree
    //    - [ ] get_height // returns the height in nodes (single node's height is 1)
    //    - [ ] get_min   // returns the minimum value stored in the tree
    //    - [ ] get_max   // returns the maximum value stored in the tree
    //    - [ ] is_binary_search_tree
    //    - [ ] delete_value
    //    - [ ] get_successor // returns next-highest value in tree after given value, -1 if none

    //- ### Heap / Priority Queue / Binary Heap
    //- [ ] Implement a max-heap:
    //    - [ ] insert
    //    - [ ] sift_up - needed for insert
    //    - [ ] get_max - returns the max item, without removing it
    //    - [ ] get_size() - return number of elements stored
    //    - [ ] is_empty() - returns true if heap contains no elements
    //    - [ ] extract_max - returns the max item, removing it
    //    - [ ] sift_down - needed for extract_max
    //    - [ ] remove(i) - removes item at index x
    //    - [ ] heapify - create a heap from an array of elements, needed for heap_sort
    //    - [ ] heap_sort() - take an unsorted array and turn it into a sorted array in-place using a max heap
    //        - note: using a min heap instead would save operations, but double the space needed (cannot do in-place).

    public class Class3
    {

    }
}
