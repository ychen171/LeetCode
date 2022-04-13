public class MyStack
{

    Queue<int> q1;
    Queue<int> q2;
    public MyStack()
    {
        q1 = new Queue<int>();
        q2 = new Queue<int>();
    }

    public void Push(int x)
    {
        if (q1.Count == 0)
        {
            q1.Enqueue(x);
            while (q2.Count != 0)
            {
                q1.Enqueue(q2.Dequeue());
            }
        }
        else
        {
            q2.Enqueue(x);
            while (q1.Count != 0)
            {
                q2.Enqueue(q1.Dequeue());
            }
        }
    }

    public int Pop()
    {
        if (q1.Count != 0)
            return q1.Dequeue();
        else if (q2.Count != 0)
            return q2.Dequeue();
        else
            return -1;
    }

    public int Top()
    {
        if (q1.Count != 0)
            return q1.Peek();
        else if (q2.Count != 0)
            return q2.Peek();
        else
            return -1;
    }

    public bool Empty()
    {
        return q1.Count == 0 && q2.Count == 0;
    }
}

/**
 * Your MyStack object will be instantiated and called as such:
 * MyStack obj = new MyStack();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Top();
 * bool param_4 = obj.Empty();
 */
