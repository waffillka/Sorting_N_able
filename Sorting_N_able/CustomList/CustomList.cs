using System;
using System.Collections.Generic;

namespace Sorting_N_able.CustomList
{
    class CustomList<T> //, IList<T>
    {
        private Node<T> head;
        public int Size { get; private set; }

        public T this[int index]
        {
            get
            {
                if (head == null)
                {
                    throw new ArgumentNullException("List is empty");
                }

                int count = 0;
                var temp = head;

                while (temp.Next != null && count != index)
                {
                    temp = temp.Next;
                    count++;
                }

                if (count != index)
                    throw new ArgumentOutOfRangeException("Out of range");

                return temp.Item;
            }

            set
            {
                if (head == null)
                {
                    head = new Node<T>(value, null);
                }

                int count = 0;
                var temp = head;

                while (temp.Next != null && count != index)
                {
                    temp = temp.Next;
                    count++;
                }

                if (count != index)
                {
                    temp.Next = new Node<T>(value, null);
                    Size++;
                }
                else
                {
                    temp.Item = value;
                }
            }
        }
        public CustomList()
        {
            this.Size = 0;
            this.head = null;
        }

        public T RemoveAt(int n)
        {
            if (Size == 0)
            {
                return default(T);
            }
            else if (n > Size - 1)
                throw new ArgumentOutOfRangeException("Out of range");
            else if (n == 0)
            {
                return Pop_front();
            }

            var temp = head;

            for (int i = 0; i < n; i++)
            {
                temp = temp.Next;
            }

            var toDelete = temp.Next;
            temp.Next = toDelete.Next;
            --Size;

            return toDelete.Item;
        }

        public void InsertAt(T item, int index)
        {
            if (index > Size - 1)
            {
                throw new ArgumentOutOfRangeException("sfcds");
            }
            else if (index == 0)
            {
                Push_front(item);
            }
            else
            {
                var temp = head;

                for (int i = 0; i < Size; i++)
                {
                    temp = temp.Next;
                }
                var newNode = new Node<T>(item, temp.Next);
                temp.Next = newNode;
                Size++;
            }
        }

        public bool Empty() => head == null;

        public void Push_front(T info)
        {
            this.head = new Node<T>(info, head);
            this.Size++;
        }

        public T Pop_front()
        {
            if (head is null)
                return default;

            T item = head.Item;
            head = head.Next;
            this.Size--;

            return item;
        }

        public void Push_back(T info)
        {
            if (head is null)
                Push_front(info);

            var temp = head;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }

            temp.Next = new Node<T>(info, null);
            Size++;
        }

        public T Pop_back()
        {
            if (head is null)
                return default;

            Node<T> temp, temp2;
            temp2 = null;
            temp = head;
            while (temp.Next != null)
            {
                temp2 = temp;
                temp = temp.Next;
            }

            T item;

            if (temp2 == null)
            {
                item = head.Item;
            }
            else
            {
                temp2.Next = null;
                item = temp.Item;
            }

            this.Size--;

            return item;
        }

        public IEnumerable<T> ToList()
        {
            Node<T> node = head;
            while (node != null)
            {
                yield return node.Item;
                node = node.Next;
            }
        }
    }
}
