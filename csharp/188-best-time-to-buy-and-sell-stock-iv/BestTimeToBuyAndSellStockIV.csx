public class Solution
{
    // DP Template
    // Time: O(n * k)
    // Space: O(n * k)
    public int MaxProfit(int k, int[] prices)
    {
        /*
            states: dp[i][k][s], i: day index [0, n-1], k: [1, k], s: 0 no stock, 1 has stock
            options: buy, sell, do nothing
            goal: dp[n-1][k][0]

            dp[i][k][0] = Math.Max(dp[i-1][k][0], dp[i-1][k][1] + prices[i])
            dp[i][k][1] = Math.Max(dp[i-1][k][1], dp[i-1][k-1][0] - prices[i])

            base case:
            dp[-1][k][0] = 0
            dp[-1][k][1] = int.MinValue

            dp[i][0][0] = 0
            dp[i][0][1] = int.MinValue
        */

        int n = prices.Length;
        if (n == 0)
            return 0;

        var dp = new int[n][][];
        for (int i = 0; i < n; i++)
        {
            dp[i] = new int[k + 1][];
            for (int j = 0; j < k + 1; j++)
            {
                dp[i][j] = new int[2];
            }
            dp[i][0][0] = 0;
            dp[i][0][1] = int.MinValue;
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 1; j <= k; j++)
            {
                // base case
                if (i - 1 == -1)
                {
                    dp[i][j][0] = 0;
                    dp[i][j][1] = 0 - prices[i];
                    continue;
                }
                dp[i][j][0] = Math.Max(dp[i - 1][j][0], dp[i - 1][j][1] + prices[i]);
                dp[i][j][1] = Math.Max(dp[i - 1][j][1], dp[i - 1][j - 1][0] - prices[i]);
            }
        }

        return dp[n - 1][k][0];
    }
}
