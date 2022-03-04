public class Solution
{
    // Sort
    // Time: O(n log n)
    // Space: O(1)
    public int FindKthLargest(int[] nums, int k)
    {
        Array.Sort(nums);
        return nums[nums.Length - k];
    }

    // Priority Queue | Min heap
    // Time: O(n log k)
    // Space: O(k)
    public int FindKthLargestPQ(int[] nums, int k)
    {
        var pq = new PriorityQueue<int, int>();
        foreach (var num in nums)
        {
            pq.Enqueue(num, num);
            if (pq.Count > k)
                pq.Dequeue();
        }
        return pq.Peek();
    }
}


var s = new Solution();
var result = s.FindKthLargestPQ(new int[]{3,2,1,5,6,4}, 2);

