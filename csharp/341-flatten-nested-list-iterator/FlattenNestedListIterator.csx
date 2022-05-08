
// This is the interface that allows for creating nested lists.
// You should not implement it, or speculate about its implementation
public interface NestedInteger
{

    // @return true if this NestedInteger holds a single integer, rather than a nested list.
    public bool IsInteger();

    // @return the single integer that this NestedInteger holds, if it holds a single integer
    // Return null if this NestedInteger holds a nested list
    public int GetInteger();

    // @return the nested list that this NestedInteger holds, if it holds a nested list
    // Return null if this NestedInteger holds a single integer
    public IList<NestedInteger> GetList();
}


public class NestedIterator
{
    private Stack<NestedInteger> stack;
    public NestedIterator(IList<NestedInteger> nestedList)
    {
        stack = new Stack<NestedInteger>();
        for (int i = nestedList.Count - 1; i >= 0; i--)
        {
            stack.Push(nestedList[i]);
        }
    }

    public bool HasNext()
    {
        // check if there are integers left by getting one onto the top of stack
        MakeStackTopAnInteger();
        // if there are any intergers remaining, one will be on the top of stack,
        // and therefore the stack can't possibly be empty. 
        return !(stack.Count == 0);
    }

    public int Next()
    {
        if (!HasNext())
            return -1;
        
        return stack.Pop().GetInteger();
    }

    private void MakeStackTopAnInteger()
    {
        // while there are items remaining on the deque and the front of deque is a list, keep unpacking
        while (stack.Count != 0 && !stack.Peek().IsInteger())
        {
            var nestedList = stack.Pop().GetList();
            for (int i = nestedList.Count - 1; i >= 0; i--)
            {
                stack.Push(nestedList[i]);
            }
        }
    }
}

/**
 * Your NestedIterator will be called like this:
 * NestedIterator i = new NestedIterator(nestedList);
 * while (i.HasNext()) v[f()] = i.Next();
 */
