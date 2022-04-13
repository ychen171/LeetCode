public class MyQueue
{
    // 1 2 3 4 5


    Stack<int> input;
    Stack<int> output;
    public MyQueue()
    {
        input = new Stack<int>();
        output = new Stack<int>();
    }

    public void Push(int x)
    {
        while (output.Count != 0)
        {
            input.Push(output.Pop());
        }
        input.Push(x);
    }

    public int Pop()
    {
        while (input.Count != 0)
        {
            output.Push(input.Pop());
        }
        return output.Pop();
    }

    public int Peek()
    {
        while (input.Count != 0)
        {
            output.Push(input.Pop());
        }
        return output.Peek();
    }

    public bool Empty()
    {
        return input.Count == 0 && output.Count == 0;
    }
}

/**
 * Your MyQueue object will be instantiated and called as such:
 * MyQueue obj = new MyQueue();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Peek();
 * bool param_4 = obj.Empty();
 */
