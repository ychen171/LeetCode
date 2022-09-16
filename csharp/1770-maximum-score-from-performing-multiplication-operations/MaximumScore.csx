
public class Solution
{
    // DP | Top-down | Memoization | Recursion
    // Time: O(m^2)
    // Space: O(m^2)
    private int[] nums, multipliers;
    private int n, m;
    private int[,] memo;
    public int MaximumScore(int[] nums, int[] multipliers)
    {
        this.n = nums.Length;
        this.m = multipliers.Length;
        this.nums = nums;
        this.multipliers = multipliers;
        memo = new int[m + 1, m + 1];

        return Helper(0, 0);
    }

    public int Helper(int i, int left)
    {
        if (memo[i, left] != 0) return memo[i, left];
        if (i == m) return 0; // base case

        var mult = multipliers[i];
        var right = n - 1 - (i - left);
        var result = Math.Max(mult * nums[left] + Helper(i + 1, left + 1), mult * nums[right] + Helper(i + 1, left));
        memo[i, left] = result;
        return result;
    }

    // DP | Bottom-up | Tabulation | Iteration
    // Time: O(m^2)
    // Space: O(m^2)
    public int MaximumScoreTabulation(int[] nums, int[] multipliers)
    {
        var n = nums.Length;
        var m = multipliers.Length;
        // initialize table with default values
        // seed the trivial answer into the table
        int[,] dp = new int[m + 1, m + 1];
        // fill further positions with current position
        for (int i = m - 1; i >= 0; i--)
        {
            for (int left = i; left >= 0; left--)
            {
                var mult = multipliers[i];
                var right = n - 1 - (i - left);
                dp[i, left] = Math.Max(mult * nums[left] + dp[i + 1, left + 1], mult * nums[right] + dp[i + 1, left]);
            }
        }

        return dp[0, 0];
    }
}

var s = new Solution();
Console.WriteLine(s.MaximumScore(new int[] { 1, 2, 3 }, new int[] { 3, 2, 1 }));


