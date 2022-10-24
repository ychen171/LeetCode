public class MaxStack
{
    SortedList<int[], int[]> indexValueList; // [index, value]
    SortedList<int[], int[]> valueIndexList; // [value, index]
    int index;

    public MaxStack()
    {
        var comparer = new MyComparer();
        indexValueList = new SortedList<int[], int[]>(comparer);
        valueIndexList = new SortedList<int[], int[]>(comparer);
        index = 0;
    }

    public void Push(int x)
    {
        var indexValue = new int[] { index, x };
        var valueIndex = new int[] { x, index };
        indexValueList.Add(indexValue, indexValue);
        valueIndexList.Add(valueIndex, valueIndex);
        index++;
    }

    public int Pop()
    {
        var pair = indexValueList.Last().Key;
        var index = pair[0];
        var value = pair[1];
        indexValueList.RemoveAt(indexValueList.Count - 1);
        valueIndexList.Remove(new int[] { value, index });
        return value;
    }

    public int Top()
    {
        var pair = indexValueList.Last().Key;
        return pair[1];
    }

    public int PeekMax()
    {
        var pair = valueIndexList.Last().Key;
        return pair[0];
    }

    public int PopMax()
    {
        var pair = valueIndexList.Last().Key;
        var value = pair[0];
        var index = pair[1];
        valueIndexList.RemoveAt(valueIndexList.Count - 1);
        indexValueList.Remove(new int[] { index, value });
        return value;
    }
}

public class MyComparer : IComparer<int[]>
{
    public int Compare(int[] a, int[] b)
    {
        if (a[0] == b[0])
            return a[1] - b[1];

        return a[0] - b[0];
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
