public class MyCircularDeque
{
    int size;
    int[] arr;
    int head;
    int tail;

    public MyCircularDeque(int k)
    {
        size = k;
        arr = new int[k];
        // head: the pointer of front element
        // tail: the pointer of rear element
        head = -1;
        tail = -1;
    }

    public bool InsertFront(int value)
    {
        if (IsFull())
            return false;

        if (IsEmpty())
        {
            arr[0] = value;
            head = 0;
            tail = 0;
        }
        else
        {
            if (head == 0)
                head = size - 1;
            else
                head--;
            arr[head] = value;
        }

        return true;
    }

    public bool InsertLast(int value)
    {
        if (IsFull())
            return false;
        if (IsEmpty())
        {
            arr[0] = value;
            head = 0;
            tail = 0;
        }
        else
        {
            tail = (tail + 1) % size;
            arr[tail] = value;
        }

        return true;
    }

    public bool DeleteFront()
    {
        if (IsEmpty())
            return false;
        // only one left
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

    public bool DeleteLast()
    {
        if (IsEmpty())
            return false;
        // only one left
        if (head == tail)
        {
            head = -1;
            tail = -1;
        }
        else
        {
            if (tail == 0)
                tail = size - 1;
            else
                tail--;
        }

        return true;
    }

    public int GetFront()
    {
        if (IsEmpty())
            return -1;
        return arr[head];
    }

    public int GetRear()
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

        return (tail + 1) % size == head;
    }
}

/**
 * Your MyCircularDeque object will be instantiated and called as such:
 * MyCircularDeque obj = new MyCircularDeque(k);
 * bool param_1 = obj.InsertFront(value);
 * bool param_2 = obj.InsertLast(value);
 * bool param_3 = obj.DeleteFront();
 * bool param_4 = obj.DeleteLast();
 * int param_5 = obj.GetFront();
 * int param_6 = obj.GetRear();
 * bool param_7 = obj.IsEmpty();
 * bool param_8 = obj.IsFull();
 */
