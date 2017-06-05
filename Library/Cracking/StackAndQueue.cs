using System;
using System.Collections.Generic;

namespace Cracking
{
    #region helper

    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        public Node(T data)
        {
            Data = data;
        }
    }

    public class S<T> : IS<T>
    {
        public Node<T> Top { get; set; }

        public virtual T Pop()
        {
            if (Top == null) throw new InvalidOperationException("Empty stack");
            T item = Top.Data;
            Top = Top.Next;
            return item;
        }

        public virtual void Push(T item)
        {
            Node<T> t = new Node<T>(item) { Next = Top };
            Top = t;
        }

        public T Peek()
        {
            if (Top == null) throw new InvalidOperationException("Empty stack");
            return Top.Data;
        }

        public bool IsEmpty()
        {
            return Top == null;
        }
    }

    public interface IS<T>
    {
        Node<T> Top
        {
            get;
        }

        T Pop();

        void Push(T item);

        T Peek();

        bool IsEmpty();
    }

    public class Q<T> : IQ<T>
    {
        public Node<T> First { get; set; }
        public Node<T> Last { get; set; }

        public void Add(T item)
        {
            Node<T> t = new Node<T>(item);
            if (Last != null)
            {
                Last.Next = t;
            }
            Last = t;
            if (First == null)
            {
                First = Last;
            }
        }

        public T Remove()
        {
            if (First == null) throw new InvalidOperationException("No such element");
            T data = First.Data;
            First = First.Next;
            if (First == null)
            {
                Last = null;
            }
            return data;
        }

        public T Peek()
        {
            if (First == null) throw new InvalidOperationException("No such element");
            return First.Data;
        }

        public bool IsEmpty()
        {
            return First == null;
        }
    }

    public interface IQ<T>
    {
        Node<T> First { get; set; }
        Node<T> Last { get; set; }

        void Add(T item);
        bool IsEmpty();
        T Peek();
        T Remove();
    }

    #endregion

    public class StackAndQueue
    {
        #region test

        #region min

        public class SWithNodeMin : S<int>
        {
            public class NodeWithMin : Node<int>
            {
                public int Min { get; set; }

                public NodeWithMin(int data, int min)
                    : base(data)
                {
                    Min = min;
                }
            }

            public override void Push(int item)
            {
                var min = GetMin(item);
                NodeWithMin t = new NodeWithMin(item, min) { Next = Top };
                Top = t;
            }

            private int GetMin(int i)
            {
                if (IsEmpty())
                {
                    return i;
                }

                return Top.Data <= i ? Top.Data : i;
            }

            public int Min
            {
                get
                {
                    if (!IsEmpty())
                    {
                        return ((NodeWithMin)Top).Min;
                    }
                    throw new InvalidOperationException();
                }
            }
        }

        public class SwithStackMin : S<int>//use stack
        {
            private readonly S<int> _minS = new S<int>();

            public override int Pop()
            {
                int t = base.Pop();

                if (t == _minS.Peek())
                {
                    _minS.Pop();
                }

                return t;
            }

            public override void Push(int item)
            {
                if (IsEmpty())
                {
                    _minS.Push(item);
                }
                else if (item <= _minS.Peek())
                {
                    _minS.Push(item);
                }

                base.Push(item);
            }

            public int Min
            {
                get { return _minS.Peek(); }
            }
        }

        #endregion

        #region set of s

        #region s with a
        public class SWithA<T>
        {
            public const int Capacity = 4;
            private int _size = -1;
            private readonly T[] _t = new T[Capacity];

            public T Pop()
            {
                if (IsEmpty()) throw new InvalidOperationException("empty");
                return _t[_size--];
            }

            public void Push(T item)
            {
                if (IsFull()) throw new InvalidOperationException("full");
                _t[++_size] = item;
            }

            public T Peek()
            {
                if (IsEmpty()) throw new InvalidOperationException("empty");
                return _t[_size];
            }

            public bool IsEmpty()
            {
                return _size == -1;
            }

            public bool IsFull()
            {
                return _size + 1 == Capacity;
            }
        }
        #endregion

        #region set of s

        public class SetOfS<T>
        {
            private readonly List<SWithA<T>> _list = new List<SWithA<T>>();

            public T Pop()
            {
                if (IsEmpty()) throw new InvalidOperationException("empty");
                var t = _list[_list.Count - 1].Pop();
                if (_list[_list.Count - 1].IsEmpty())
                {
                    _list.Remove(_list[_list.Count - 1]);
                }
                return t;
            }

            public void Push(T item)
            {
                if (_list.Count == 0 || _list[_list.Count - 1].IsFull())
                {
                    _list.Add(new SWithA<T>());
                }
                _list[_list.Count - 1].Push(item);
            }

            public T Peek()
            {
                if (IsEmpty()) throw new InvalidOperationException("empty");
                return _list[_list.Count - 1].Peek();
            }

            public bool IsEmpty()
            {
                return _list.Count == 0;
            }
        }

        #endregion

        #endregion

        #region q with s

        public class QWithS<T>
        {
            private readonly S<T> _new = new S<T>();
            private readonly S<T> _old = new S<T>();

            public T First
            {
                get
                {
                    if (IsEmpty()) throw new InvalidOperationException("empty");
                    while (!_new.IsEmpty())
                    {
                        _old.Push(_new.Pop());
                    }
                    return _old.Peek();
                }
            }

            public T Last
            {
                get
                {
                    if (IsEmpty()) throw new InvalidOperationException("empty");
                    while (!_old.IsEmpty())
                    {
                        _new.Push(_old.Pop());
                    }
                    return _new.Peek();
                }
            }

            public void Add(T item)
            {
                while (!_old.IsEmpty())
                {
                    _new.Push(_old.Pop());
                }
                _new.Push(item);
            }

            public T Remove()
            {
                if (IsEmpty()) throw new InvalidOperationException("empty");
                while (!_new.IsEmpty())
                {
                    _old.Push(_new.Pop());
                }
                return _old.Pop();
            }

            public bool IsEmpty()
            {
                return _new.IsEmpty() && _old.IsEmpty();
            }
        }

        #endregion

        #region sort s

        public class SortS : IS<int>
        {
            private readonly S<int> _small = new S<int>();
            private readonly S<int> _large = new S<int>();

            public Node<int> Top
            {
                get
                {
                    if (IsEmpty()) throw new InvalidOperationException("empty");
                    return new Node<int>(_small.Peek());
                }
            }
            public int Pop()
            {
                if (IsEmpty()) throw new InvalidOperationException("empty");
                return _small.Pop();
            }

            public void Push(int item)
            {
                if (IsEmpty() || item <= _small.Peek())
                {
                    _small.Push(item);
                }
                else
                {
                    while (!_small.IsEmpty())
                    {
                        var t = _small.Pop();
                        if (t <= item)
                        {
                            _large.Push(t);
                        }
                        else
                        {
                            _small.Push(item);
                            _small.Push(t);
                            break;
                        }
                    }
                    if (item > _large.Peek())
                    {
                        _small.Push(item);
                    }

                    while (!_large.IsEmpty())
                    {
                        _small.Push(_large.Pop());
                    }
                }
            }

            public int Peek()
            {
                if (IsEmpty()) throw new InvalidOperationException("empty");
                return _small.Peek();
            }

            public bool IsEmpty()
            {
                return _small.IsEmpty();
            }
        }

        #endregion

        //skip 3.6 as it is easy

        #endregion
    }
}
