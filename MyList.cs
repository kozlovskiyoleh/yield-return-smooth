using System.Collections;
using System.Collections.Generic;

namespace yield;

public class MyList<T> : IEnumerable<T>
{
    public Node<T> head;
    public int Count { get; private set; }


    public void AddToEnd(T item)
    {
        if (head == null)
        {
            head = new Node<T>(item);
        }
        else
        {
            Node<T> current = head;
            while (current.next != null)
            {
                current = current.next;
            }
            current.next = new Node<T>(item);
        }
        Count++;
    }

    /*public void Pop() => head = head.next;

    public T Peek() => head.data;

    public void AddToStart(T item)
    {
        if (head == null)
        {
            head = new Node<T>(item);
        }
        else
        {
            Node<T> current = new Node<T>(item, head);
            head = current;
        }
        Count++;
    }
    */
    public IEnumerator<T> GetEnumerator()
    {
        var currentList = head;
        while (currentList != null)
        {
            yield return currentList.data;
            currentList = currentList.next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
