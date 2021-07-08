namespace Sorting_N_able.CustomList
{
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Item { get; set; }

        public Node(T item, Node<T> node)
        {
            Item = item;
            Next = node;
        }
    }
}
