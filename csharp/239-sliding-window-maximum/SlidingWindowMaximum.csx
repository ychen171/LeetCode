public class Solution
{
    // Double-ended Queue
    // Time: O(n)
    // Space: O(k)
    public int[] MaxSlidingWindow(int[] nums, int k)
    {
        int n = nums.Length;
        int left = 0;
        int right = 0;
        var deQueue = new LinkedList<int>();
        var ans = new List<int>();
        for (right = 0; right < n; right++)
        {
            while (deQueue.Count != 0 && nums[deQueue.Last.Value] < nums[right])
            {
                deQueue.RemoveLast();
            }

            deQueue.AddLast(right);

            if (right + 1 >= k)
            {
                ans.Add(nums[deQueue.First.Value]);
                left++;
            }

            if (left > deQueue.First.Value)
            {
                deQueue.RemoveFirst();
            }
        }

        return ans.ToArray();
    }

    // Max Queue + Sliding Window
    // Time: O(n)
    // Space: O(k)
    public int[] MaxSlidingWindow1(int[] nums, int k)
    {
        int n = nums.Length;
        var window = new MonoQueue();
        var ans = new List<int>();
        // [left, right)
        int left = 0, right = 0;
        while (right < n)
        {
            var num = nums[right];
            right++;
            if (right < k)
            {
                window.Push(num);
            }
            else
            {
                window.Push(num);
                ans.Add(window.Max());
                window.Pop(nums[right - k]);
                left++;
            }
        }

        return ans.ToArray();
    }
}

public class MonoQueue
{
    LinkedList<int> maxQ;
    int removeCount;
    public MonoQueue()
    {
        removeCount = 0;
        maxQ = new LinkedList<int>();
    }

    public void Push(int num)
    {
        int removeCount = 0;
        while (maxQ.Count != 0 && maxQ.Last.Value < num)
        {
            removeCount++;
            maxQ.RemoveLast();
        }
        maxQ.AddLast(num);
    }

    public void Pop(int num)
    {
        if (maxQ.First.Value == num)
            maxQ.RemoveFirst();
    }

    public int Max()
    {
        return maxQ.First.Value;
    }
}
