public class MyCircularQueue
{
    int head;
    int tail;
    int size;
    int[] arr;

    public MyCircularQueue(int k)
    {
        // [head, tail]
        size = k;
        head = 0;
        tail = -1;
        arr = new int[size];
    }

    public bool EnQueue(int value)
    {
        if (IsFull())
            return false;

        tail = (tail + 1) % size;
        arr[tail] = value;
        return true;
    }

    public bool DeQueue()
    {
        if (IsEmpty())
            return false;
        // last one
        if (head == tail)
        {
            head = 0;
            tail = -1;
        }
        else // at least two
        {
            head = (head + 1) % size;
        }
        return true;
    }

    public int Front()
    {
        if (IsEmpty())
            return -1;
        return arr[head];
    }

    public int Rear()
    {
        if (IsEmpty())
            return -1;
        return arr[tail];
    }

    public bool IsEmpty()
    {
        return tail == -1;
    }

    public bool IsFull()
    {
        if (IsEmpty())
            return false;
        return head == (tail + 1) % size;
    }
}

/**
 * Your MyCircularQueue object will be instantiated and called as such:
 * MyCircularQueue obj = new MyCircularQueue(k);
 * bool param_1 = obj.EnQueue(value);
 * bool param_2 = obj.DeQueue();
 * int param_3 = obj.Front();
 * int param_4 = obj.Rear();
 * bool param_5 = obj.IsEmpty();
 * bool param_6 = obj.IsFull();
 */

MyCircularQueue obj = new MyCircularQueue(3);
Console.WriteLine(obj.EnQueue(1));
Console.WriteLine(obj.EnQueue(2));
Console.WriteLine(obj.EnQueue(3));
Console.WriteLine(obj.EnQueue(4));
