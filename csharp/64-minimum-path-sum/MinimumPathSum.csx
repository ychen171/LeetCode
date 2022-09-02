public class Solution
{
    // DP | Memoization | Recursion
    // Time: O(m * n)
    // Space: O(m * n)
    public int MinPathSum(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        var memo = new int[m][];
        for (int r = 0; r < m; r++)
        {
            memo[r] = new int[n];
            for (int c = 0; c < n; c++)
                memo[r][c] = int.MaxValue;
        }
        return Helper(grid, m - 1, n - 1, memo);
    }

    public int Helper(int[][] grid, int r, int c, int[][] memo)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        // base case
        if (r == 0 && c == 0)
            return grid[r][c];
        if (r < 0 || c < 0)
            return int.MaxValue;

        if (memo[r][c] != int.MaxValue)
            return memo[r][c];
        // recursive case
        int sub1 = Helper(grid, r, c - 1, memo);
        int sub2 = Helper(grid, r - 1, c, memo);
        int result = grid[r][c] + Math.Min(sub1, sub2);
        memo[r][c] = result;
        return result;
    }

    // DP | Tabulation | Iteration
    // Time: O(m * n)
    // Space: O(m * n)
    public int MinPathSum1(int[][] grid)
    {
        /*
            states: dp[r][c], r: [0, m-1], c: [0, n-1]
            options: go down, go right
            goal: dp[m-1][n-1]

            dp[r][c] = Math.Min(dp[r-1][c], dp[r][c-1]) + grid[r][c]

            base case:
            r == 0
            dp[0][c] = Math.Min(dp[-1][c], dp[0][c-1]) + grid[0][c]
                     = dp[0][c-1] + grid[0][c]
            
            c == 0
            dp[r][0] = Math.Min(dp[r-1][0], dp[r][-1]) + grid[r][0]
                     = dp[r-1][0] + grid[r][0]
        */

        var m = grid.Length;
        var n = grid[0].Length;
        var dp = new int[m][];
        for (int r = 0; r < m; r++)
            dp[r] = new int[n];
        // base case
        dp[0][0] = grid[0][0];
        for (int r = 1; r < m; r++)
            dp[r][0] = dp[r - 1][0] + grid[r][0];
        for (int c = 1; c < n; c++)
            dp[0][c] = dp[0][c - 1] + grid[0][c];

        for (int r = 1; r < m; r++)
        {
            for (int c = 1; c < n; c++)
                dp[r][c] = Math.Min(dp[r - 1][c], dp[r][c - 1]) + grid[r][c];
        }

        return dp[m - 1][n - 1];
    }
}
