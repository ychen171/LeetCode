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

    public int[] MaxSlidingWindow1(int[] nums, int k)
    {
        int n = nums.Length;
        var window = new MonoQueue();
        var ans = new List<int>();
        for (int i = 0; i < n; i++)
        {
            if (i < k - 1)
            {
                window.Push(nums[i]);
            }
            else
            {
                window.Push(nums[i]);
                ans.Add(window.Max());
                window.Pop(nums[i - k + 1]);
            }
        }

        return ans.ToArray();
    }
}

public class MonoQueue
{
    LinkedList<int> queue;
    public MonoQueue()
    {
        queue = new LinkedList<int>();
    }

    public void Push(int num)
    {
        while (queue.Count != 0 && queue.Last.Value < num)
            queue.RemoveLast();
        queue.AddLast(num);
    }

    public void Pop(int num)
    {
        if (queue.First.Value == num)
            queue.RemoveFirst();
    }

    public int Max()
    {
        return queue.First.Value;
    }
}
