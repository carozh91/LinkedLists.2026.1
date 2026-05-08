using Shared;

namespace DoubleList;

public class DoubleLinkedList<T> : ILinkedList<T>
{
    private Node<T>? _head;
    private Node<T>? _tail;

    public DoubleLinkedList()
    {
        _head = null;
        _tail = null;
    }

    public bool Contains(T data)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Data != null && current.Data.Equals(data))
            {
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public void InsertAtBeginning(T data)
    {
        var newNode = new Node<T>(data);
        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            newNode.Next = _head;
            _head.Previous = newNode;
            _head = newNode;
        }
    }

    public void InsertAtEnding(T data)
    {
        var newNode = new Node<T>(data);
        if (_tail == null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            _tail.Next = newNode;
            newNode.Previous = _tail;
            _tail = newNode;
        }
    }

    public void InsertOrdered(T data)
    {
        var newNode = new Node<T>(data);

        if (_head == null) 
        {
            _head = newNode;
            _tail = newNode;
            return;
        }

        if (Comparer<T>.Default.Compare(data, _head.Data!) < 0) 
        {
            newNode.Next = _head;
            _head.Previous = newNode;
            _head = newNode;
            return;
        }

        var current = _head;

        while (current.Next != null && Comparer<T>.Default.Compare(data, current.Next.Data!) > 0)
        {
            current = current.Next;
        }

        newNode.Next = current.Next;
        newNode.Previous = current;

        if (current.Next != null)
        {
            current.Next.Previous = newNode;
        }
        else
        {
            _tail = newNode;
        }
        current.Next = newNode;
    }

    public void Remove(T data)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Data!.Equals(data))
            {
                if (current == _head) // Found at the head
                {
                    _head = _head.Next;
                    _head!.Previous = null;
                }
                else if (current == _tail) // Found at the tail
                {
                    _tail = _tail.Previous;
                    _tail!.Next = null;
                }
                else // Found in the middle
                {
                    current.Previous!.Next = current.Next;
                    current.Next!.Previous = current.Previous;
                }
                return;
            }
            current = current.Next;
        }
    }

    public void Reverse()
    {
        
        var current = _head;
        Node<T>? aux = null;
        while (current != null)
        {
            aux = current.Previous;
            current.Previous = current.Next;
            current.Next = aux;
            current = current.Previous;
        }
        aux = _head;
        _head = _tail;
        _tail = aux;
    }

    public void Sort()
    {
        Reverse();
    }

    override public string ToString()
    {
        var current = _head;
        var result = string.Empty;
        while (current != null)
        {
            result += $"{current.Data} -> ";
            current = current.Next;
        }
        result += "null";
        return result;
    }

    public string ToStringReverse()
    {
        var current = _tail;
        var result = string.Empty;
        while (current != null)
        {
            result += $"{current.Data} -> ";
            current = current.Previous;
        }
        result += "null";
        return result;
    }

    public void RemoveAll(T data)
    {
        var current = _head;

        while (current != null)
        {
            var next = current.Next;

            if (current.Data != null && current.Data.Equals(data))
            {
                if (current == _head)
                {
                    _head = _head.Next;

                    if (_head != null)
                    {
                        _head.Previous = null;
                    }
                    else
                    {
                        _tail = null;
                    }
                }
                else if (current == _tail)
                {
                    _tail = _tail.Previous;

                    if (_tail != null)
                    {
                        _tail.Next = null;
                    }
                }
                else
                {
                    current.Previous!.Next = current.Next;
                    current.Next!.Previous = current.Previous;
                }
            }

            current = next;
        }
    }

    public void ShowModes()
    {
        if (_head == null)
        {
            Console.WriteLine("List is empty.");
            return;
        }

        var current = _head;
        var maxCount = 0;
        var count = 1;
        var result = string.Empty;

        while (current.Next != null)
        {
            if (current.Data != null &&
                current.Data.Equals(current.Next.Data))
            {
                count++;
            }
            else
            {
                if (count > maxCount)
                {
                    maxCount = count;
                    result = $"{current.Data}";
                }
                else if (count == maxCount)
                {
                    result += $" {current.Data}";
                }

                count = 1;
            }

            current = current.Next;
        }

        if (count > maxCount)
        {
            result = $"{current.Data}";
        }
        else if (count == maxCount)
        {
            result += $" {current.Data}";
        }

        Console.WriteLine($"Mode(s): {result}");
    }

    public void ShowGraph()
    {
        if (_head == null)
        {
            Console.WriteLine("List is empty.");
            return;
        }

        var current = _head;
        var count = 1;

        while (current.Next != null)
        {
            if (current.Data != null &&
                current.Data.Equals(current.Next.Data))
            {
                count++;
            }
            else
            {
                Console.Write($"{current.Data} ");

                for (int i = 0; i < count; i++)
                {
                    Console.Write("*");
                }

                Console.WriteLine();

                count = 1;
            }

            current = current.Next;
        }

        Console.Write($"{current.Data} ");

        for (int i = 0; i < count; i++)
        {
            Console.Write("*");
        }

        Console.WriteLine();
    }
}