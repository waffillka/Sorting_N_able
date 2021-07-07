using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_N_able.CustomList
{
    class CustomList<T>
    {
        private Node<T> head;
        public int Size { get; private set; }

        public CustomList()
        {
            this.Size = 0;
            this.head = null;
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
            while(temp.Next != null)
            {
                temp = temp.Next;
            }

            temp.Next = new Node<T>(info, null);
        }

        public T Pop_back()
        {
            if (head is null)
                return default;

            Node<T> temp, temp2;
            temp2 = null;
            temp = head;
            while(temp.Next != null)
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
