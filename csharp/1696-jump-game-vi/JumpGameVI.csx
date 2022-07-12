public class Solution
{
    // TLE
    // DP | Top-down | Memoization | Recursion
    // Time: O(n*k)
    // Space: O(n)
    public int MaxResult(int[] nums, int k)
    {
        int n = nums.Length;
        var memo = new int[n];
        Array.Fill(memo, int.MinValue);
        return Helper(nums, k, n - 1, memo);
    }

    public int Helper(int[] nums, int k, int curr, int[] memo)
    {
        if (memo[curr] != int.MinValue)
            return memo[curr];
        int n = nums.Length;
        // scores[i] = nums[i] + Max(scores[j]), where j is all indexes can be reached from i 
        // j = [i + 1, min(n-1, i+k)]

        // base case
        if (curr == 0)
            return nums[0];

        // recursive case
        int ans = int.MinValue;
        for (int prev = curr - 1; prev >= Math.Max(0, curr - k); prev--)
        {
            var prevAns = Helper(nums, k, prev, memo);
            if (prevAns == int.MinValue)
                continue;
            ans = Math.Max(ans, nums[curr] + prevAns);
        }

        memo[curr] = ans;
        return ans;
    }

    // DP + DeQueue (monotonic queue)
    // Time: O(n)
    // Spacee: O(n)
    public int MaxResult1(int[] nums, int k)
    {
        int n = nums.Length;
        var scores = new int[n];
        scores[0] = nums[0];
        var dq = new LinkedList<int>();
        dq.AddLast(0);
        for (int i = 1; i < n; i++)
        {
            // pop old index
            while (dq.Count != 0 && dq.First.Value < i - k)
            {
                dq.RemoveFirst();
            }
            scores[i] = scores[dq.First.Value] + nums[i];
            // pop teh smaller value
            while (dq.Count != 0 && scores[dq.Last.Value] < scores[i])
            {
                dq.RemoveLast();
            }
            dq.AddLast(i);
        }

        return scores[n - 1];
    }

    // DP + PriorityQueue
    // Time: O(n log n)
    // Space: O(n)
    public int MaxResult2(int[] nums, int k)
    {
        int n = nums.Length;
        var scores = new int[n];
        scores[0] = nums[0];
        var pq = new PriorityQueue<int[], int>(); // max heap   <[score, index], -score>
        pq.Enqueue(new int[] { nums[0], 0 }, -nums[0]);
        for (int i = 1; i < n; i++)
        {
            // pop old index
            while (pq.Count != 0 && pq.Peek()[1] < i - k)
            {
                pq.Dequeue();
            }
            scores[i] = pq.Peek()[0] + nums[i];
            pq.Enqueue(new int[] { scores[i], i }, -scores[i]);
        }

        return scores[n - 1];
    }
}

var s = new Solution();
var nums = new int[] { 1, -1, -2, 4, -7, 3 };
var k = 2;
var result = s.MaxResult(nums, k);
Console.WriteLine(result);
var result1 = s.MaxResult1(nums, k);
Console.WriteLine(result1);
