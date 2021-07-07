using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_N_able.CustomList
{
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Item { get; }

        public Node(T item, Node<T> node)
        {
            Item = item;
            Next = node;
        }
    }
}
