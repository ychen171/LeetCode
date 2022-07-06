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

    public int[] TopKFrequent1(int[] nums, int k)
    {
        var countDict = new Dictionary<int, int>();
        foreach (var num in nums)
        {
            countDict[num] = countDict.GetValueOrDefault(num, 0) + 1;
        }
        // edge case
        if (countDict.Count == k)
            return countDict.Keys.ToArray();

        var pq = new PriorityQueue<int, int>(); // min heap, <num, count>
        foreach (var kv in countDict)
        {
            int num = kv.Key;
            int count = kv.Value;
            pq.Enqueue(num, count);
            if (pq.Count > k)
                pq.Dequeue();
        }
        var ans = new int[k];
        for (int i = 0; i < k; i++)
        {
            ans[i] = pq.Dequeue();
        }

        return ans;
    }
}

var s = new Solution();
var result1 = s.TopKFrequent1(new int[] { 1, 1, 1, 2, 2, 3 }, 2);
var result2 = s.TopKFrequent1(new int[] { 1 }, 1);
foreach (var num in result1)
{
    Console.Write(num);
    Console.Write(" ");
}
Console.WriteLine();
foreach (var num in result2)
{
    Console.Write(num);
    Console.Write(" ");
}
Console.WriteLine();
