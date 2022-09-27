public class FrontMiddleBackQueue
{
    // Two LinkedLists
    // left length <= right length
    // when size is even, PushMiddle is to add element into right list
    // when size is odd, PopMiddle is to remove element from right list
    // when size is 1, PopFront is to remove element from right list

    // Time: O(n)
    // Space: O(n)
    LinkedList<int> left;
    LinkedList<int> right;
    public FrontMiddleBackQueue()
    {
        left = new LinkedList<int>();
        right = new LinkedList<int>();
    }

    public void PushFront(int val)
    {
        left.AddFirst(val);
        Balance();
    }

    public void PushMiddle(int val)
    {
        int size = left.Count + right.Count;
        if (size % 2 == 0) // even
            right.AddFirst(val);
        else // odd
            left.AddLast(val);
        Balance();
    }

    public void PushBack(int val)
    {
        right.AddLast(val);
        Balance();
    }

    public int PopFront()
    {
        int size = left.Count + right.Count;
        if (size == 0)
            return -1;

        int ans = -1;
        if (size == 1)
        {
            ans = right.Last.Value;
            right.RemoveLast();
        }
        else
        {
            ans = left.First.Value;
            left.RemoveFirst();
        }
        Balance();
        return ans;
    }

    public int PopMiddle()
    {
        int size = left.Count + right.Count;
        if (size == 0)
            return -1;

        int ans = -1;

        if (size % 2 == 0) // even
        {
            ans = left.Last.Value;
            left.RemoveLast();
        }
        else // odd
        {
            ans = right.First.Value;
            right.RemoveFirst();
        }
        Balance();
        return ans;
    }

    public int PopBack()
    {
        int size = left.Count + right.Count;
        if (size == 0)
            return -1;

        int ans = -1;
        ans = right.Last.Value;
        right.RemoveLast();
        Balance();
        return ans;
    }

    private void Balance()
    {
        if (right.Count > left.Count + 1)
        {
            left.AddLast(right.First.Value);
            right.RemoveFirst();
        }
        if (left.Count > right.Count)
        {
            right.AddFirst(left.Last.Value);
            left.RemoveLast();
        }
    }
}

/**
 * Your FrontMiddleBackQueue object will be instantiated and called as such:
 * FrontMiddleBackQueue obj = new FrontMiddleBackQueue();
 * obj.PushFront(val);
 * obj.PushMiddle(val);
 * obj.PushBack(val);
 * int param_4 = obj.PopFront();
 * int param_5 = obj.PopMiddle();
 * int param_6 = obj.PopBack();
 */
