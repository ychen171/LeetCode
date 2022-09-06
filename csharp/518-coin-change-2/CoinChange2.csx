public class Solution
{
    // Backtrack
    // Time: O(n^k)
    // Space: O(k)
    // n = the number of coins
    // k = amount
    public int Change(int amount, int[] coins)
    {
        Array.Sort(coins);
        var memo = new Dictionary<int, int>();
        return Backtrack(amount, coins, 0);
    }

    private int Backtrack(int amount, int[] coins, int index)
    {
        // base case
        if (amount == 0)
            return 1;
        if (amount < 0)
            return 0;

        // recursive case
        int ans = 0;
        for (int i = index; i < coins.Length; i++)
        {
            var coin = coins[i];
            ans += Backtrack(amount - coin, coins, i);
        }

        return ans;
    }

    // DP | Tabulation
    // Time: O(n * k)
    // Space: O(k)
    // n = the number of coins
    // k = amount
    public int Change1(int amount, int[] coins)
    {
        // initialize the table with default values
        var table = new int[amount + 1]; // [0, 1, 2, ... amount]
        // seed the trivial answer into the table
        table[0] = 1;
        // fill further positions based on current position
        foreach (var coin in coins)
        {
            for (int i = coin; i < amount + 1; i++)
            {
                table[i] += table[i - coin];
            }
        }

        return table[amount];
    }

    public int Change2(int amount, int[] coins)
    {
        int n = coins.Length;
        var dp = new int[n + 1][];
        for (int i = 0; i < n + 1; i++)
        {
            dp[i] = new int[amount + 1];
            dp[i][0] = 1;
        }

        for (int i = 1; i < n + 1; i++)
        {
            for (int j = 0; j < amount + 1; j++)
            {
                if (j >= coins[i - 1])
                {
                    dp[i][j] = dp[i - 1][j] + dp[i][j - coins[i - 1]];
                }
                else
                {
                    dp[i][j] = dp[i - 1][j];
                }
            }
        }

        return dp[n][amount];
    }
}
