public class MaxStack
{
    LinkedList<int[]> list;
    SortedList<int, List<LinkedListNode<int[]>>> dict; // value to list of nodes
    int index;
    // Space: O(n)
    public MaxStack()
    {
        dict = new SortedList<int, List<LinkedListNode<int[]>>>();
        list = new LinkedList<int[]>();
        index = 0;
    }

    // Time: O(log n)
    public void Push(int x)
    {
        var pair = new int[] { index, x };
        index++;
        var node = new LinkedListNode<int[]>(pair);
        if (!dict.ContainsKey(x))
            dict[x] = new List<LinkedListNode<int[]>>();
        dict[x].Add(node);
        list.AddLast(node);
    }

    // Time: O(log n)
    public int Pop()
    {
        var node = list.Last;
        list.RemoveLast();
        var value = node.Value[1];
        Remove(value);
        return value;
    }

    // Time: O(1)
    public int Top()
    {
        var node = list.Last;
        return node.Value[1];
    }

    // Time: O(1)
    public int PeekMax()
    {
        var maxValue = dict.Keys.Last();
        return maxValue;
    }

    // Time: O(log n)
    public int PopMax()
    {
        var maxValue = dict.Keys.Last();
        var maxNode = dict[maxValue].Last();
        list.Remove(maxNode);
        Remove(maxValue);
        return maxValue;
    }

    // Time: O(log n)
    private void Remove(int key)
    {
        var list = dict[key];
        if (list.Count == 1)
            dict.Remove(key);
        else
            list.RemoveAt(list.Count - 1);
    }
}

/**
 * Your MaxStack object will be instantiated and called as such:
 * MaxStack obj = new MaxStack();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.PeekMax();
 * int param_5 = obj.PopMax();
 */