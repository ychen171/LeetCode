public class Solution
{
    // DP | Top-down | Memoization | Recursion
    // Time: O(amount * denomination count)
    // Space: O(amount)
    private Dictionary<int, int> memo;
    public int CoinChange(int[] coins, int amount)
    {
        this.memo = new Dictionary<int, int>();
        return Helper(coins, amount); // solve the problem recursively
    }

    public int Helper(int[] coins, int amount)
    {
        // base case
        if (memo.ContainsKey(amount)) return memo[amount];
        if (amount < 0) return -1; // cannot make up a negative amount
        if (amount == 0) return 0; // do not need to choose a coin

        int minCount = int.MaxValue; // declare a variable to update the minCount
        foreach (var coin in coins)
        {
            var remainder = amount - coin;              // choose a coin
            var count = Helper(coins, remainder);       // solve the subproblems
            if (count == -1) continue;
            minCount = Math.Min(minCount, count + 1);   // update the minCount
        }

        // return the minCount if it has been updated, otherwise return -1
        var result = minCount == int.MaxValue ? -1 : minCount;
        memo[amount] = result;
        return result;
    }

    // DP | Bottom-up | Tabulation | Iteration
    // Time: O(amount * denomination count)
    // Space: O(amount)
    public int CoinChangeTabulation(int[] coins, int amount)
    {
        // initialize the table with default values
        var table = new List<int>();
        for (int i = 0; i <= amount; i++)
            table.Add(amount + 1);
        // seed the trivial answer into the table
        table[0] = 0;
        // fill further positions with current position
        for (int i = 1; i <= amount; i++)
        {
            foreach (var coin in coins)
            {
                if (i - coin < 0) continue;
                table[i] = Math.Min(table[i], table[i - coin] + 1);
            }
        }

        return table[amount] == amount + 1 ? -1 : table[amount];
    }

    public int CoinChangeTabulation1(int[] coins, int amount)
    {
        // initialize the table with default values
        var table = new int[amount + 1];
        // seed the trivial answer into the table
        table[0] = 0;
        for (int i = 1; i < amount + 1; i++)
            table[i] = int.MaxValue;
        // fill further positions based on current position
        foreach (var coin in coins)
        {
            for (int i = coin; i < amount + 1; i++)
            {
                if (table[i - coin] == int.MaxValue)
                    continue;
                table[i] = Math.Min(table[i], table[i - coin] + 1);
            }
        }

        return table[amount] == int.MaxValue ? -1 : table[amount];
    }
}
