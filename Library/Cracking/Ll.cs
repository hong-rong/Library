using System;
using System.Collections.Generic;

namespace Cracking
{
    public class LinkedLists
    {
        #region questions
        public Node RemoveDuplicats(Node n)
        {
            //HashSet<int> tab = new HashSet<int>();
            //Node current = new Node(-1);
            //current.Next = n;
            //while (current.Next != null)
            //{
            //    if (tab.Contains(current.Next.Data))
            //    {
            //        current.Next = current.Next.Next;
            //    }
            //    else
            //    {
            //        tab.Add(current.Next.Data);
            //        current = current.Next;
            //    }
            //}
            //return n;


            Node current = null;
            Node previous = null;
            System.Collections.Generic.HashSet<int> table = new
                System.Collections.Generic.HashSet<int>();

            current = n;
            while (current != null)
            {
                if (table.Contains(current.Data))
                {
                    previous.Next = current.Next;
                }
                else
                {
                    table.Add(current.Data);
                    previous = current;
                }
                current = current.Next;
            }

            return n;


            //Node current = n;
            //Node runner = null;

            //while (current != null)
            //{
            //    runner = current;
            //    while (runner.Next != null)
            //    {
            //        if (current.Data == runner.Next.Data)
            //        {
            //            runner.Next = runner.Next.Next;
            //        }
            //        else
            //        {
            //            runner = runner.Next;
            //        }
            //    }
            //    current = current.Next;
            //}

            //return n;
        }

        public Node GetkElement(Node entity, int k)
        {
            Node n1 = entity;
            Node n2 = entity;

            int index = 0;
            while (n1 != null)
            {
                n1 = n1.Next;
                if (index < k)
                {
                    index++;
                }
                else if (index == k)
                {
                    n2 = n2.Next;
                }
            }
            return index == k ? n2 : null;
        }

        public Node GetkElement_Iterative(Node entity, int k)
        {
            if (k < 1 && entity == null) throw new ArgumentException("invalid");
            int count = 1;
            return MoveAndCount(entity, k, ref count);
        }

        private Node MoveAndCount(Node entity, int k, ref int count)
        {
            if (entity.Next != null)
            {
                MoveAndCount(entity.Next, k, ref count);
                if (count == k) return new Node(entity.Data);
                count++;
                return null;
            }
            if (count == k) return new Node(entity.Data);
            return null;
        }

        //assume can't access entity, here just for testing purpose
        public bool DeleteMiddle(Node entity, Node middle)
        {
            if (middle == null || middle.Next == null) return false;
            middle.Data = middle.Next.Data;
            middle.Next = middle.Next.Next;
            return true;
        }

        public Node Partition(Node entity, int p)
        {
            if (entity == null) return entity;
            Node lp = new Node(-1);
            Node rp = new Node(-1);
            Node lh = lp;
            Node rh = rp;

            lp.Next = entity;
            while (lp.Next != null)
            {
                if (lp.Next.Data >= p)
                {
                    rp.Next = lp.Next;
                    lp.Next = lp.Next.Next;
                    rp = rp.Next;
                    rp.Next = null;
                }
                else
                {
                    lp = lp.Next;
                }
            }
            lp.Next = rh.Next;

            return lh.Next;
        }

        public Node SumReverseOrder(Node n1, Node n2)
        {
            if (n1 == null) return n2;
            if (n2 == null) return n1;

            Node np1 = new Node(-1);
            Node np2 = new Node(-1);
            np1.Next = n1;
            np2.Next = n2;

            bool c = false;
            while (np1.Next != null || np2.Next != null)
            {
                int d = (np1.Next == null ? 0 : np1.Next.Data) + (np2.Next == null ? 0 : np2.Next.Data) + (c ? 1 : 0);
                if (d >= 10)
                {
                    c = true;
                    d = d - 10;
                }
                else
                {
                    c = false;
                }

                if (np1.Next == null)
                {
                    np1.Next = np2.Next;
                    np2.Next = null;
                }
                np1.Next.Data = d;

                if (!c && np2.Next == null)
                {
                    break;
                }

                if (np1.Next != null) np1 = np1.Next;
                if (np2.Next != null) np2 = np2.Next;
            }
            if (c)
            {
                np1.Next = new Node(1);
            }

            return n1;
        }

        public Node SumForwardOrder(Node n1, Node n2)
        {
            var sum = SumReverseOrder(Reverse(n1), Reverse(n2));
            return Reverse(sum);
        }

        public Node Reverse(Node n)
        {
            return ReverseRec(null, n);
        }

        public Node ReverseIter(Node n)
        {
            var h = n;
            Node p = null;
            while (h != null)
            {
                var t = h;
                h = h.Next;
                t.Next = p;
                p = t;
            }
            return p;
        }

        private Node ReverseRec(Node pre, Node curr)
        {
            if (curr == null) return pre;
            var n = curr.Next;
            curr.Next = pre;
            return ReverseRec(curr, n);
        }

        public Node SumReverseOrderRec(Node n1, Node n2)
        {
            return SumReverseOrderRec(n1, n2, false);
        }
        private Node SumReverseOrderRec(Node n1, Node n2, bool carry)
        {
            if (n1 == null && n2 == null && !carry) return null;

            int d = (n1 == null ? 0 : n1.Data) + (n2 == null ? 0 : n2.Data) + (carry ? 1 : 0);
            if (d >= 10)
            {
                d = d - 10;
                carry = true;
            }
            else
            {
                carry = false;
            }
            Node n = new Node(d);
            n.Next = SumReverseOrderRec(n1 == null ? null : n1.Next, n2 == null ? null : n2.Next, carry);
            return n;
        }

        public Node SumForwardOrderRec(Node n1, Node n2)
        {
            var p1 = Reverse(n1);
            var p2 = Reverse(n2);
            var n = SumReverseOrderRec(p1, p2);
            return Reverse(n);
        }

        public bool IsPalin(Node n)
        {
            if (n == null || n.Next == null) return true;

            Node r = ReverseAndCopy(n);
            while (n != null && r != null)
            {
                if (n.Data != r.Data) return false;
                n = n.Next;
                r = r.Next;
            }

            return true;
        }
        public Node ReverseAndCopy(Node n)
        {
            Node curr = n;
            Node prev = null;
            while (curr != null)
            {
                Node temp = new Node(curr.Data);
                temp.Next = prev;
                prev = temp;
                curr = curr.Next;
            }

            return prev;
        }

        public bool IsPalinIterativeStack(Node n)
        {
            if (n == null || n.Next == null) return true;
            System.Collections.Generic.Stack<int> stack = new System.Collections.Generic.Stack<int>();
            Node s = n;
            Node f = n;

            while (f != null && f.Next != null)
            {
                stack.Push(s.Data);
                s = s.Next;
                f = f.Next.Next;
            }
            if (f != null)
            {
                s = s.Next;
            }

            while (s != null)
            {
                if (s.Data != stack.Pop()) return false;
                s = s.Next;
            }

            return true;
        }

        #region IsPalinRec

        public bool IsPalinRec(Node n)
        {
            if (n == null || n.Next == null) return true;

            int length = CountLength(n);
            return IsPalin(n, length).IsPaline;
        }

        private ReturnEntity IsPalin(Node n, int length)
        {
            if (length == 0 || length == 1)
            {
                return new ReturnEntity
                {
                    IsPaline = true,
                    Node = length == 0 ? n : n.Next
                };
            }

            var returnNode = IsPalin(n.Next, length - 2);
            if (!returnNode.IsPaline) return returnNode;

            returnNode.IsPaline = returnNode.Node.Data == n.Data;
            returnNode.Node = returnNode.Node.Next;
            return returnNode;
        }

        private static int CountLength(Node n)
        {
            int length = 0;
            while (n != null)
            {
                length++;
                n = n.Next;
            }
            return length;
        }

        #endregion

        public Node Intersection(Node n1, Node n2)
        {
            if (n1 == null || n2 == null) return null;

            int l1 = 0;
            int l2 = 0;
            Node p1 = new Node(-1);
            Node p2 = new Node(-1);

            p1.Next = n1;
            p2.Next = n2;
            while (p1.Next != null)
            {
                l1++;
                p1 = p1.Next;
            }
            while (p2.Next != null)
            {
                l2++;
                p2 = p2.Next;
            }
            if (p1 != p2) return null;

            p1 = n1;
            p2 = n2;
            int dat = 0;
            if (l1 > l2)
            {
                dat = l1 - l2;
                while (dat > 0)
                {
                    p1 = p1.Next;
                    dat--;
                }
            }
            else if (l2 > l1)
            {
                dat = l2 - l1;
                while (dat > 0)
                {
                    p2 = p2.Next;
                    dat--;
                }
            }

            do
            {
                if (p1 == p2) return p1;
                p1 = p1.Next;
                p2 = p2.Next;
            } while (p1 != null);

            throw new InvalidOperationException();
        }

        public Node Loop(Node n)
        {
            if (n == null) return null;

            Node s = n;
            Node f = n;

            do
            {
                s = s.Next;
                f = f.Next.Next;
            } while (s != f);

            s = n;
            while (s != f)
            {
                s = s.Next;
                f = f.Next;
            }

            return s;
        }
        #endregion

        #region helper
        public class Node
        {
            public Node(int d)
            {
                Data = d;
            }

            public int Data { get; set; }
            public Node Next { get; set; }

            //append to tail
            public void Append(int d)
            {
                Node end = new Node(d);
                Node n = this;
                while (n.Next != null)
                {
                    n = n.Next;
                }
                n.Next = end;
            }

            public void Append(Node entity)
            {
                if (entity == null) throw new ArgumentNullException("entity");
                Node n = this;
                while (n.Next != null)
                {
                    n = n.Next;
                }
                n.Next = entity;
            }

            public Node Last
            {
                get
                {
                    if (this == null) throw new InvalidOperationException("entity is null");
                    Node n = this;
                    while (n.Next != null)
                    {
                        n = n.Next;
                    }
                    return n;
                }
            }

            public Node Delete(Node header, int d)
            {
                Node n = header;
                if (n.Data == d)
                {
                    return n.Next;
                }

                while (n.Next != null)
                {
                    if (n.Next.Data == d)
                    {
                        n.Next = n.Next.Next;
                        return header;

                    }
                    n = n.Next;
                }
                return header;
            }
        }

        public class ReturnEntity
        {
            public Node Node { get; set; }
            public bool IsPaline { get; set; }
        }
        #endregion
    }
}
