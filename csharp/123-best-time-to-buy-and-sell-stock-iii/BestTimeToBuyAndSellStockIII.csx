public class Solution
{
    // DP Template
    // Time: O(n)
    // Space: O(n)
    public int MaxProfit(int[] prices)
    {
        /*
            states: dp[i][k][s], 
            i: 0-based index of day [0,n-1], k: at most transactions [1,2], s: 0 no stock, 1 has stock
            options: buy, sell, do nothing
            
            dp[i][k][0] = Math.Max(dp[i-1][k][0], dp[i-1][k][1] + prices[i])
            dp[i][k][1] = Math.Max(dp[i-1][k][1], dp[i-1][k-1][0] - prices[i])

            goal: dp[n-1][2][0]

            base case:
            dp[-1][k][0] = 0
            dp[-1][k][1] = int.MinValue
        */

        int n = prices.Length;
        var dp = new int[n][][];
        for (int i = 0; i < n; i++)
        {
            dp[i] = new int[3][];
            for (int k = 0; k <= 2; k++)
            {
                dp[i][k] = new int[2];
            }
        }

        for (int i = 0; i < n; i++)
        {
            for (int k = 1; k <= 2; k++)
            {
                // base case
                if (i - 1 == -1)
                {
                    dp[i][k][0] = 0;
                    dp[i][k][1] = 0 - prices[i];
                    continue;
                }
                dp[i][k][0] = Math.Max(dp[i - 1][k][0], dp[i - 1][k][1] + prices[i]);
                dp[i][k][1] = Math.Max(dp[i - 1][k][1], dp[i - 1][k - 1][0] - prices[i]);
            }
        }

        return dp[n - 1][2][0];
    }

    // DP Template Optimized
    // Time: O(n)
    // Space: O(1)
    public int MaxProfit1(int[] prices)
    {
        /*
            dp[i][2][0] = max(dp[i-1][2][0], dp[i-1][2][1] + prices[i])
            dp[i][2][1] = max(dp[i-1][2][1], dp[i-1][1][0] - prices[i])
            dp[i][1][0] = max(dp[i-1][1][0], dp[i-1][1][1] + prices[i])
            dp[i][1][1] = max(dp[i-1][1][1], dp[i-1][0][0] - prices[i])

            dp[-1][1,2][0] = 0
            dp[-1][1,2][1] = int.MinValue
            dp[0,n-1][0][0] = 0

        */
        int n = prices.Length;
        int dp_i20 = 0, dp_i21 = int.MinValue;
        int dp_i10 = 0, dp_i11 = int.MinValue;
        for (int i = 0; i < n; i++)
        {
            dp_i20 = Math.Max(dp_i20, dp_i21 + prices[i]);
            dp_i21 = Math.Max(dp_i21, dp_i10 - prices[i]);
            dp_i10 = Math.Max(dp_i10, dp_i11 + prices[i]);
            dp_i11 = Math.Max(dp_i11, 0 - prices[i]);
        }

        return dp_i20;
    }
}
