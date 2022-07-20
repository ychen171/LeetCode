public class Solution
{
    // DP Template
    // Time: O(n)
    // Space: O(n)
    public int MaxProfit(int[] prices)
    {
        /*
            states: dp[i][s] // i: 0-based index of day, s: 0 no stock, 1 has stock
            options: buy, sell, do nothing

            dp[i][0] = max(dp[i-1][0], dp[i-1][1] + prices[i])
            dp[i][1] = max(dp[i-1][1], dp[i-1][0] - prices[i])

            goal: dp[n-1][0]

            base case:
            dp[-1][0] = 0
            dp[-1][1] = int.MinValue
        */

        int n = prices.Length;
        var dp = new int[n][];
        for (int i = 0; i < n; i++)
            dp[i] = new int[2];

        for (int i = 0; i < n; i++)
        {
            // base case
            if (i - 1 == -1)
            {
                dp[i][0] = 0;
                dp[i][1] = -prices[0];
                continue;
            }
            dp[i][0] = Math.Max(dp[i - 1][0], dp[i - 1][1] + prices[i]);
            dp[i][1] = Math.Max(dp[i - 1][1], dp[i - 1][0] - prices[i]);
        }

        return dp[n - 1][0];
    }

    // DP Template Optimized
    // Time: O(n)
    // Space: O(1)
    public int MaxProfit1(int[] prices)
    {
        int n = prices.Length;
        // base case
        int dp_i_0 = 0;
        int dp_i_1 = int.MinValue;

        for (int i = 0; i < n; i++)
        {
            int dp_prev_0 = dp_i_0;
            int dp_prev_1 = dp_i_1;
            dp_i_0 = Math.Max(dp_prev_0, dp_prev_1 + prices[i]);
            dp_i_1 = Math.Max(dp_prev_1, dp_prev_0 - prices[i]);
        }

        return dp_i_0;
    }
}
