public class Solution
{
    // DP Template
    // Time: O(n)
    // Space: O(n)
    public int MaxProfit(int[] prices)
    {
        /*
            states: dp[i][s], i: index of day [0,n-1], s: 0 no stock, 1 has stock
            options: buy, sell, do nothing

            dp[i][0] = Math.Max(dp[i-1][0], dp[i-1][1] + prices[i])
            dp[i][1] = Math.Max(dp[i-1][1], dp[i-2][0] - prices[i])

            goal: dp[n-1][0]

            base case:
            dp[-1][0] = 0
            dp[-1][1] = int.MinValue
            dp[-2][0] = 0
            dp[-2][1] = int.MinValue
        */
        int n = prices.Length;
        var dp = new int[n][];
        for (int i = 0; i < n; i++)
            dp[i] = new int[2];

        for (int i = 0; i < n; i++)
        {
            if (i - 1 == -1)
            {
                dp[i][0] = 0;
                dp[i][1] = -prices[i];
                continue;
            }
            if (i - 2 == -1)
            {
                dp[i][0] = Math.Max(dp[i - 1][0], dp[i - 1][1] + prices[i]);
                dp[i][1] = Math.Max(dp[i - 1][1], -prices[i]);
                continue;
            }
            dp[i][0] = Math.Max(dp[i - 1][0], dp[i - 1][1] + prices[i]);
            dp[i][1] = Math.Max(dp[i - 1][1], dp[i - 2][0] - prices[i]);
        }
        return dp[n - 1][0];
    }
}

var s = new Solution();
var prices = new int[] { 1, 2, 3, 0, 2 };
var result = s.MaxProfit(prices);
Console.WriteLine(result);
