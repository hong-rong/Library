using System;
using System.Collections.Generic;

namespace Cracking
{
    public class LinkedLists
    {
        #region questions
        public Entity RemoveDuplicats(Entity entity)
        {
            HashSet<int> tab = new HashSet<int>();
            Entity n = new Entity(-1);
            n.Next = entity;
            while (n.Next != null)
            {
                if (tab.Contains(n.Next.Data))
                {
                    n.Next = n.Next.Next;
                }
                else
                {
                    tab.Add(n.Next.Data);
                    n = n.Next;
                }
            }
            return entity;
        }

        public Entity GetkElement(Entity entity, int k)
        {
            if (k < 1 && entity == null) throw new ArgumentException("invalid");

            int index = 1;
            Entity n1 = entity, n2 = entity;
            while (n1.Next != null)
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
            return index == k ? new Entity(n2.Data) : null;
        }

        public Entity GetkElement_Iterative(Entity entity, int k)
        {
            if (k < 1 && entity == null) throw new ArgumentException("invalid");
            int count = 1;
            return MoveAndCount(entity, k, ref count);
        }

        private Entity MoveAndCount(Entity entity, int k, ref int count)
        {
            if (entity.Next != null)
            {
                MoveAndCount(entity.Next, k, ref count);
                if (count == k) return new Entity(entity.Data);
                count++;
                return null;
            }
            if (count == k) return new Entity(entity.Data);
            return null;
        }

        //assume can't access entity, here just for testing purpose
        public bool DeleteMiddle(Entity entity, Entity middle)
        {
            if (middle == null || middle.Next == null) return false;
            middle.Data = middle.Next.Data;
            middle.Next = middle.Next.Next;
            return true;
        }

        public Entity Partition(Entity entity, int p)
        {
            if (entity == null || entity.Next == null) return entity;

            Entity rp = new Entity(0);
            Entity rh = rp;

            Entity lp = new Entity(0);
            Entity lh = new Entity(0);
            lp.Next = entity;
            lh.Next = entity;
            while (lh.Next != null)
            {
                if (lh.Next.Data < p)
                {
                    lh = lh.Next;
                    break;
                }
                lh = lh.Next;
            }

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
            return lh;
        }

        public Entity SumReverseOrder(Entity n1, Entity n2)
        {
            if (n1 == null || n2 == null) throw new ArgumentNullException("n1 or n2 is null");
            Entity n1p = new Entity(0);
            n1p.Next = n1;
            Entity n2p = new Entity(0);
            n2p.Next = n2;
            //1
            //9
            sbyte overflow = 0;
            int d;
            while (true)
            {
                d = (n1p.Next != null ? n1p.Next.Data : 0) + (n2p.Next != null ? n2p.Next.Data : 0) + overflow;
                if (d >= 10)
                {
                    d = d - 10;
                    overflow = 1;
                }
                else
                {
                    overflow = 0;
                }

                if (n1p.Next != null && n2p.Next != null)
                {
                    n1p.Next.Data = d;
                    n1p = n1p.Next;
                    n2p = n2p.Next;
                }
                else if (n1p.Next != null && n2p.Next == null)
                {
                    n1p.Next.Data = d;
                    n1p = n1p.Next;
                    if (overflow == 0)
                    {
                        break;
                    }
                }
                else if (n1p.Next == null && n2p.Next != null)
                {
                    n1p.Next = new Entity(d);
                    n1p = n1p.Next;
                    n2p = n2p.Next;
                }
                else if (n1p.Next == null && n2p.Next == null)
                {
                    if (d != 0 || overflow != 0)
                    {
                        n1p.Next = new Entity(d);
                        n1p = n1p.Next;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
            return n1;
        }
        public Entity SumForwardOrder(Entity n1, Entity n2)
        {
            var sum = SumReverseOrder(Reverse(n1), Reverse(n2));
            return Reverse(sum);
        }

        public Entity Reverse(Entity entity)
        {
            //1->2->3
            if (entity == null || entity.Next == null) return entity;
            Entity n = new Entity(0);
            Entity p = new Entity(0);
            n.Next = entity.Next;
            p.Next = entity;
            entity.Next = null;
            while (n.Next != null)
            {
                var t = n.Next;
                n.Next = n.Next.Next;//not n = n.Next
                t.Next = p.Next;
                p.Next = t;
            }
            return p.Next;
        }
        public Entity SumReverseOrderRec(Entity n1, Entity n2)
        {
            return SumReverseOrderRec(n1, n2, 0);
        }
        private Entity SumReverseOrderRec(Entity n1, Entity n2, int carry)
        {
            if (n1 == null && n2 == null && carry == 0) return null;
            int d = 0;
            if (n1 != null) d = d + n1.Data;
            if (n2 != null) d = d + n2.Data;
            if (carry != 0) d = d + carry;
            Entity n = new Entity(d % 10);
            carry = d >= 10 ? 1 : 0;

            var next = SumReverseOrderRec(n1 == null ? null : n1.Next, n2 == null ? null : n2.Next, carry);
            n.Next = next;

            return n;
        }

        public Entity SumForwardOrderRec(Entity n1, Entity n2)
        {
            var p1 = Reverse(n1);
            var p2 = Reverse(n2);
            var n = SumReverseOrderRec(p1, p2);
            return Reverse(n);
        }

        public bool IsPalin(Entity n)
        {
            if (n == null || n.Next == null) return true;
            var r = ReverseAndCopy(n);
            Entity one = new Entity(0);
            one.Next = n;
            Entity two = new Entity(0);
            two.Next = r;
            while (one.Next != null && two.Next != null)
            {
                if (one.Next.Data != two.Next.Data) return false;
                two.Next = two.Next.Next;
                one.Next = one.Next.Next;
            }
            return one.Next == null && two.Next == null;
        }
        public Entity ReverseAndCopy(Entity n)
        {
            if (n == null || n.Next == null) return n;
            Entity p = new Entity(0);
            Entity h = new Entity(0);
            p.Next = n;
            while (p.Next != null)
            {
                var t = new Entity(p.Next.Data);
                t.Next = h.Next;
                h.Next = t;
                p.Next = p.Next.Next;
            }
            return h.Next;
        }

        public bool IsPalinIterativeStack(Entity n)
        {
            if (n == null) throw new ArgumentNullException();
            if (n.Next == null) return true;
            Entity s = new Entity(0);
            s.Next = n;
            Entity f = new Entity(0);
            f.Next = n;
            int index = 0;
            Stack<Entity> st = new Stack<Entity>(16);
            st.Push(s.Next);
            //1 1
            //1 2 1
            //1 2 2 1
            //1 2 3 4
            //1 2 3 4 5
            while (f.Next != null)
            {
                f.Next = f.Next.Next;
                index++;
                if (f.Next == null) break;
                f.Next = f.Next.Next;
                index++;
                s.Next = s.Next.Next;
                st.Push(s.Next);
            }

            if (index % 2 == 1)
            {
                s.Next = s.Next.Next;
            }
            st.Pop();
            while (s.Next != null)
            {
                var pop = st.Pop();
                if (pop.Data != s.Next.Data) return false;
                s.Next = s.Next.Next;
            }

            return true;
        }

        public bool IsPalinIterativeStackRefined(Entity n)
        {
            if (n == null) throw new ArgumentNullException();
            if (n.Next == null) return true;
            Entity s = n;
            Entity f = n;
            Stack<int> st = new Stack<int>(16);
            //1 1
            //1 2 1
            //1 2 2 1
            //1 2 3 4 5
            while (f != null && f.Next != null)
            {
                f = f.Next.Next;
                st.Push(s.Data);
                s = s.Next;
            }
            if (f != null)
            {
                s = s.Next;
            }
            while (s != null)
            {
                var pop = st.Pop();
                if (pop != s.Data) return false;
                s = s.Next;
            }

            return true;
        }


        #region IsPalinRec

        public bool IsPalinRec(Entity n)
        {
            if (n == null) throw new ArgumentNullException();
            if (n.Next == null) return true;

            int length = CountLength(n);

            Entity t = n;
            //1 2 2 1
            return IsPalin(t, length).IsPaline;
        }

        private ReturnEntity IsPalin(Entity n, int length)
        {
            //if (n == null || length == 0)
            if (length == 0)
            {
                return new ReturnEntity
                {
                    Entity = n,
                    IsPaline = true
                };
            }
            if (length == 1)
            {
                return new ReturnEntity
                {
                    Entity = n.Next,
                    IsPaline = true
                };
            }

            var returnNode = IsPalin(n.Next, length - 2);
            if (!returnNode.IsPaline)
            {
                returnNode.Entity = returnNode.Entity.Next;
                return returnNode;
            }

            returnNode.IsPaline = returnNode.Entity.Data == n.Data;
            returnNode.Entity = returnNode.Entity.Next;

            return returnNode;
        }

        private static int CountLength(Entity n)
        {
            int length = 0;
            Entity t = n;
            while (t != null)
            {
                length++;
                t = t.Next;
            }
            return length;
        }

        #endregion


        public Entity Intersection(Entity n1, Entity n2)
        {
            //123
            //23
            if (n1 == null || n2 == null) return null;
            Entity l = n1;
            Entity s = n2;
            int len1 = 1;
            int len2 = 1;
            int dat;
            while (l.Next != null)
            {
                len1++;
                l = l.Next;
            }
            while (s.Next != null)
            {
                len2++;
                s = s.Next;
            }
            if (l != s) return null;
            if (len1 >= len2)
            {
                l = n1;
                s = n2;
                dat = len1 - len2;
            }
            else
            {
                l = n2;
                s = n1;
                dat = len2 - len1;
            }
            for (int i = 0; i < dat; i++)
            {
                l = l.Next;
            }
            while (l != null)
            {
                if (l == s) return l;
                l = l.Next;
                s = s.Next;
            }
            throw new InvalidCastException();
        }

        public Entity Loop(Entity n)
        {
            if (n == null || n.Next == null) return n;
            Entity h = new Entity(0) { Next = n };
            Entity f = n;
            Entity s = n;
            //12345(3)
            while (s != null)
            {
                s = s.Next;
                f = f.Next.Next;
                if (f.Data == s.Data)
                {
                    s = h.Next;
                    break;
                }
            }

            while (f.Data != s.Data)
            {
                f = f.Next;
                s = s.Next;
            }

            return f;
        }
        #endregion

        #region helper
        public class Entity
        {
            public Entity(int d)
            {
                Data = d;
            }

            public int Data { get; set; }
            public Entity Next { get; set; }

            //append to tail
            public void Append(int d)
            {
                Entity end = new Entity(d);
                Entity n = this;
                while (n.Next != null)
                {
                    n = n.Next;
                }
                n.Next = end;
            }

            public void Append(Entity entity)
            {
                if (entity == null) throw new ArgumentNullException("entity");
                Entity n = this;
                while (n.Next != null)
                {
                    n = n.Next;
                }
                n.Next = entity;
            }

            public Entity Last
            {
                get
                {
                    if (this == null) throw new InvalidOperationException("entity is null");
                    Entity n = this;
                    while (n.Next != null)
                    {
                        n = n.Next;
                    }
                    return n;
                }
            }

            public Entity Delete(Entity header, int d)
            {
                Entity n = header;
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
            public Entity Entity { get; set; }
            public bool IsPaline { get; set; }
        }
        #endregion
    }
}
