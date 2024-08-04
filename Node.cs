namespace yield;

public class Node<T>
{
    public T data;
    public Node<T> next;

    public Node(T data = default(T), Node<T> next = null)
    {
        this.data = data;
        this.next = next;
    }
}
