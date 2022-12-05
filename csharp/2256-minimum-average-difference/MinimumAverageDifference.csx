public class Solution
{
    public int MinimumAverageDifference(int[] nums)
    {
        int n = nums.Length;
        var preSum = new long[n + 1];
        for (int i = 0; i < n; i++)
        {
            preSum[i + 1] = preSum[i] + nums[i];
        }
        int minAvgDiff = int.MaxValue;
        int ans = -1;
        for (int i = 0; i < n; i++)
        {
            long left = preSum[i + 1];
            long right = preSum[n] - preSum[i + 1];
            long leftAvg = left / (i + 1);
            long rightAvg = right == 0 ? 0 : right / (n - i - 1);
            int avgDiff = (int)Math.Abs(leftAvg - rightAvg);
            if (avgDiff < minAvgDiff)
            {
                minAvgDiff = avgDiff;
                ans = i;
            }
        }
        return ans;
    }
}
// Prefix Sum
// Time: O(n log n)
// Space: O(n)
