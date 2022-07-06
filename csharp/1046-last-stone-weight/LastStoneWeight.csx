public class Solution
{
    // Priority Queue
    // Time: O(n log n)
    // Space: O(n)
    public int LastStoneWeight(int[] stones)
    {
        // edge case
        int n = stones.Length;
        if (n < 2)
            return stones[0];

        var pq = new PriorityQueue<int, int>(); // max heap <weight, -weight>
        foreach (var weight in stones)
        {
            pq.Enqueue(weight, -weight);
        }

        while (pq.Count > 1)
        {
            int y = pq.Dequeue();
            int x = pq.Dequeue();
            int diff = y - x;
            if (diff > 0)
                pq.Enqueue(diff, -diff);
        }

        return pq.Count == 0 ? 0 : pq.Peek();
    }
}

var s = new Solution();
var result = s.LastStoneWeight(new int[] { 2, 7, 4, 1, 8, 1 });
Console.WriteLine(result);
