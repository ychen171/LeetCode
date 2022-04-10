public class MyCircularQueue
{

    int[] queue;
    int head;
    int tail;
    int size;
    public MyCircularQueue(int k)
    {
        size = k;
        queue = new int[k];
        head = -1;
        tail = -1;
    }

    public bool EnQueue(int value)
    {
        if (IsFull())
            return false;
        
        if (IsEmpty())
            head = 0;

        tail = (tail + 1) % size;
        queue[tail] = value;
        return true;
    }

    public bool DeQueue()
    {
        if (IsEmpty())
            return false;
        if (head == tail)
        {
            head = -1;
            tail = -1;
        }
        else
        {
            head = (head + 1) % size;
        }
        return true;
    }

    public int Front()
    {
        if (IsEmpty())
            return -1;
        return queue[head];
    }

    public int Rear()
    {
        if (IsEmpty())
            return -1;
        return queue[tail];
    }

    public bool IsEmpty()
    {
        return head == -1;
    }

    public bool IsFull()
    {
        return (tail + 1) % size == head;
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