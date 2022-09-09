public class Solution
{
    // DP
    // Time: O(n)
    // Space: O(n)
    public long GetDescentPeriods(int[] prices)
    {
        /*
            states: dp[i], the number of smooth descent periods ending at i, i = [0, n-1]
            options: join previous, start new
            goal: dp.Sum()

            dp[i] = dp[i-1] + 1, if prices[i-1] - prices[i] == 1
            dp[i] = 1

            base case:
            dp[i] = 1
        */

        var n = prices.Length;
        var dp = new long[n];
        for (int i = 0; i < n; i++)
        {
            if (i == 0)
            {
                dp[i] = 1;
                continue;
            }
            if (prices[i - 1] - prices[i] == 1)
                dp[i] = dp[i - 1] + 1;
            else
                dp[i] = 1;
        }

        return dp.Sum();
    }
}
