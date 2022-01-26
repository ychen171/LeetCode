public class Solution
{
    // Memoization Recursion
    // Time: O(n)
    // Space: O(n)
    public int MinCostClimbingStairsMemo(int[] cost)
    {
        return Helper(cost.Length, cost, new Dictionary<int, int>());
    }
    public int Helper(int n, int[] cost, Dictionary<int, int> memo)
    {
        if (memo.ContainsKey(n)) return memo[n];
        if (n == 0) return 0;
        if (n == 1) return 0;
        var result = Math.Min(Helper(n - 1, cost, memo) + cost[n - 1], Helper(n - 2, cost, memo) + cost[n - 2]);
        memo[n] = result;
        return result;
    }

    // Tabulation | Iteration | Bottom-up
    // Time: O(n)
    // Space: O(n)
    public int MinCostClimbingStairs(int[] cost)
    {
        var table = new List<int>();
        // initialize the table with default value
        for (int i = 0; i <= cost.Length; i++)
            table.Add(0);
        // seed the trivial answer into the table
        table[0] = 0;
        table[1] = 0;
        // fill further positions with current position
        for (int i = 2; i <= cost.Length; i++)
            table[i] = Math.Min(table[i - 1] + cost[i - 1], table[i - 2] + cost[i - 2]);

        return table[cost.Length];
    }

    // Iteration | Bottom-up | Constant Space
    // Time: O(n)
    // Space: O(1)
    public int MinCostClimbingStairsConstant(int[] cost)
    {
        int prevOne = 0;
        int prevTwo = 0;
        for (int i = 2; i <= cost.Length; i++)
        {
            var temp = prevOne;
            prevOne = Math.Min(prevOne + cost[i - 1], prevTwo + cost[i - 2]);
            prevTwo = temp;
        }

        return prevOne;
    }
}


var s = new Solution();
Console.WriteLine(s.MinCostClimbingStairsMemo(new int[] { 10, 15, 20 }));
Console.WriteLine(s.MinCostClimbingStairs(new int[] { 10, 15, 20 }));
Console.WriteLine(s.MinCostClimbingStairsConstant(new int[] { 10, 15, 20 }));

