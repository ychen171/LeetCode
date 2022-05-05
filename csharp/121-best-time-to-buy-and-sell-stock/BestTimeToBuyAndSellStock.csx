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
}

var s = new Solution();
Console.WriteLine(s.MaxProfitOnePass(new int[] { 2, 3, 4, 3, 2, 1, 2 }));

