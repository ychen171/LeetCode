public class MinStack
{
    Stack<int> valStack;
    Stack<int> minStack;
    // Two Stacks
    // Time: O(1)
    // Space: O(1)
    public MinStack()
    {
        valStack = new Stack<int>();
        minStack = new Stack<int>();
    }

    public void Push(int val)
    {
        valStack.Push(val);
        if (minStack.Count == 0 || val <= minStack.Peek())
            minStack.Push(val);
    }

    public void Pop()
    {
        if (valStack.Count == 0)
            return;
        
        if (minStack.Peek() == valStack.Peek())
            minStack.Pop();
        
        valStack.Pop();
    }

    public int Top()
    {
        if (valStack.Count == 0)
            return -1;

        return valStack.Peek();
    }

    public int GetMin()
    {
        if (minStack.Count == 0)
            return -1;
        
        return minStack.Peek();
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(val);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */