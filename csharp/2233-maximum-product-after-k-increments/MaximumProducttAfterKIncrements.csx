public class Solution
{
    // Greedy + Priority Queue
    // Time: O(n log n + k)
    // Space: O(n)
    public int MaximumProduct(int[] nums, int k)
    {
        int MOD = 1000000007;
        int n = nums.Length;
        var pq = new PriorityQueue<int, int>(); // min heap
        foreach (var num in nums)
        {
            pq.Enqueue(num, num);
        }
        while (k > 0)
        {
            var curr = pq.Dequeue();
            curr++;
            k--;
            pq.Enqueue(curr, curr);
        }
        long ans = 1;
        while (pq.Count != 0)
        {
            ans *= pq.Dequeue();
            ans %= MOD;
        }
        return (int)(ans % MOD);
    }
}
