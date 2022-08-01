
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
    IList<int> intList;
    int index;
    // Time: O(N + L)
    // Space: O(N + H)
    public NestedIterator(IList<NestedInteger> nestedList)
    {
        intList = new List<int>();
        index = 0;
        foreach (var node in nestedList)
        {
            Flatten(node, intList);
        }
    }
    
    private void Flatten(NestedInteger node, IList<int> intList)
    {
        // base case
        if (node.IsInteger())
        {
            intList.Add(node.GetInteger());
            return;
        }

        // recursive case
        foreach (var child in node.GetList())
        {
            Flatten(child, intList);
        }
    }

    // Time: O(1)
    public bool HasNext()
    {
        return index < intList.Count;
    }

    // Time: O(1)
    public int Next()
    {
        if (!HasNext())
            return -1;
        return intList[index++];
    }
}

/**
 * Your NestedIterator will be called like this:
 * NestedIterator i = new NestedIterator(nestedList);
 * while (i.HasNext()) v[f()] = i.Next();
 */
