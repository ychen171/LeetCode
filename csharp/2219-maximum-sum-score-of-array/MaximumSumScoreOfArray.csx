public class Solution
{
    // Prefix Sum
    // Time: O(n)
    // Space: O(n)
    public long MaximumSumScore(int[] nums)
    {
        int n = nums.Length;
        var preSum = new long[n + 1];
        for (int i = 0; i < n; i++)
            preSum[i + 1] = preSum[i] + nums[i];

        long ans = long.MinValue;
        for (int i = 0; i < n; i++)
        {
            var curr = Math.Max(preSum[i + 1], preSum[n] - preSum[i]);
            ans = Math.Max(ans, curr);
        }

        return ans;
    }
}
