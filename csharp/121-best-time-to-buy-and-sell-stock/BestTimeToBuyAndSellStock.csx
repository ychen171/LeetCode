public class Solution
{
    // Brute force
    // Time: O(n^2)
    // Space: O(1)
    public int MaxProfit(int[] prices)
    {
        int profit = 0;
        for (int i = 0; i < prices.Length; i++)
        {
            for (int j = i + 1; j < prices.Length; j++)
            {
                profit = Math.Max(prices[j] - prices[i], profit);
            }
        }

        return profit;
    }

    // One Pass
    // Time: O(n)
    // Space: O(1)
    public int MaxProfitOnePass(int[] prices)
    {
        int minPrice = int.MaxValue;
        int profit = 0;
        for (int i = 0; i < prices.Length; i++)
        {
            if (prices[i] < minPrice)
                minPrice = prices[i];
            else if (prices[i] - minPrice > profit)
                profit = prices[i] - minPrice;
        }
        return profit;
    }

    // Two Pointers
    // Time: O(n)
    // Space: O(1)
    public int MaxProfitTwoPointers(int[] prices)
    {
        int n = prices.Length;
        if (n == 1)
            return 0;

        int left = 0;
        int profit = 0;
        // find the buy point
        for (int right = 1; right < n; right++)
        {
            if (prices[right - 1] > prices[right]) // descreasing
            {
                if (prices[left] > prices[right])
                {
                    left = right; // new low
                }
            }
            else // increasing
            {
                // new high
                profit = Math.Max(profit, prices[right] - prices[left]);
            }

        }

        return profit;
    }

    // DP Template
    // Time: O(n)
    // Space: O(n)
    public int MaxProfit1(int[] prices)
    {
        /*
            dp[i][s] // i is 0-based index of day, s == 0 no stock, s == 1 has stock

            dp[i][0] = max(dp[i - 1][0], dp[i - 1][1] + prices[i])
            dp[i][1] = max(dp[i - 1][1], 0 - prices[i])

            goal: dp[n - 1][0]

            base case:
            dp[-1][0] = 0
            dp[-1][1] = int.MinValue
        */

        int n = prices.Length;
        var dp = new int[n][];
        Array.Fill(dp, new int[2]);

        for (int i = 0; i < n; i++)
        {
            // base case
            if (i - 1 == -1)
            {
                dp[i][0] = 0; // max(0, int.MinValue + prices[0])
                dp[i][1] = -prices[0]; // max(int.MinValue, 0 - prices[0])
                continue;
            }

            // recurrence relation
            dp[i][0] = Math.Max(dp[i - 1][0], dp[i - 1][1] + prices[i]);
            dp[i][1] = Math.Max(dp[i - 1][1], 0 - prices[i]);
        }

        return dp[n - 1][0];
    }

    // DP Template
    // Time: O(n)
    // Space: O(1)
    public int MaxProfit2(int[] prices)
    {
        int n = prices.Length;
        int dp_i_0 = 0; // the profit at ith day, without stock 
        int dp_i_1 = int.MinValue; // profit at ith day, with stock
        for (int i = 0; i < n; i++)
        {
            dp_i_0 = Math.Max(dp_i_0, dp_i_1 + prices[i]);
            dp_i_1 = Math.Max(dp_i_1, -prices[i]);
        }

        return dp_i_0;
    }
}

var s = new Solution();
Console.WriteLine(s.MaxProfitOnePass(new int[] { 2, 3, 4, 3, 2, 1, 2 }));

