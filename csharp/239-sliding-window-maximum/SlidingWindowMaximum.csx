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
}
