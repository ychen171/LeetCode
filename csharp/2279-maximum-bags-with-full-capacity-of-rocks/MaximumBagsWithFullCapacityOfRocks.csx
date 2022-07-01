public class Solution
{
    // Priority Queue
    // Time: O(n log n)
    // Space: O(n)
    public int MaximumBags(int[] capacity, int[] rocks, int additionalRocks)
    {
        // index   [capacity, rocks]
        // 0       [2, 1]
        // 1       [3, 2]
        // 2       [4, 5]
        // 3       [5, 4]
        // additional rocks = 2

        // sort [capacity, rocks] by avalibility = capactiy - rocks in ascending order

        var pq = new PriorityQueue<int[], int>(); // index, avalibility
        int n = capacity.Length;
        for (int i = 0; i < n; i++)
        {
            var avalibility = capacity[i] - rocks[i];
            pq.Enqueue(new int[] { i, avalibility }, avalibility);
        }

        int maxBags = 0;
        while (pq.Count != 0)
        {
            var curr = pq.Dequeue();
            int avalibility = curr[1];
            if (avalibility <= additionalRocks)
            {
                maxBags++;
            }
            additionalRocks -= Math.Min(additionalRocks, avalibility);
            if (additionalRocks == 0)
                break;
        }

        return maxBags;
    }
}
