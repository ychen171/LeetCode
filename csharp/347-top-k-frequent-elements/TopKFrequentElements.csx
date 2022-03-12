public class Solution
{
    // Priority Queue | Min Heap
    // Time: O(n log k)
    // Space: O(n + k)
    public int[] TopKFrequent(int[] nums, int k)
    {
        if (nums.Length == k) return nums;
        var pq = new PriorityQueue<int, int>();
        var numCountDict = new Dictionary<int, int>();
        foreach (var num in nums)
        {
            numCountDict[num] = numCountDict.GetValueOrDefault(num, 0) + 1;
        }

        foreach (var kv in numCountDict)
        {
            var num = kv.Key;
            var count = kv.Value;
            pq.Enqueue(num, count);
            if (pq.Count > k)
            {
                pq.Dequeue();
            }
        }

        var result = new int[k];
        for (int i = 0; i < k; i++)
        {
            result[i] = pq.Dequeue();
        }

        return result;
    }
}
