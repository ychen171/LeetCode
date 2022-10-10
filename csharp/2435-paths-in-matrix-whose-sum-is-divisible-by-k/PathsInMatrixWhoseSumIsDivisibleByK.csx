public class Solution
{
    // DP | Memoization Recursion + Modular Arithmetic
    // Time: O(m * n * k)
    // Space: O(m * n * k)
    int MOD = 1000000007;
    int[][] grid;
    int m;
    int n;
    int k;
    long[][][] memo;
    public int NumberOfPaths(int[][] grid, int k)
    {
        this.grid = grid;
        this.m = grid.Length;
        this.n = grid[0].Length;
        this.k = k;
        memo = new long[m][][];
        for (int r = 0; r < m; r++)
        {
            memo[r] = new long[n][];
            for (int c = 0; c < n; c++)
            {
                memo[r][c] = new long[k];
                for (int i = 0; i < k; i++)
                    memo[r][c][i] = -1;
            }
        }
        return (int)(Helper(0, 0, 0) % MOD);
    }

    public long Helper(long currSum, int r, int c)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        // base case
        if (r == m || c == n)
            return 0;
        if (r == m - 1 && c == n - 1)
        {
            if ((currSum + grid[r][c]) % k == 0)
                return 1;
            return 0;
        }

        if (memo[r][c][currSum] != -1)
            return memo[r][c][currSum];

        // recursive case
        long result = 0;
        var nextSum = (currSum + grid[r][c]) % k;
        result = (result + Helper(nextSum, r + 1, c)) % MOD;
        result = (result + Helper(nextSum, r, c + 1)) % MOD;
        memo[r][c][currSum] = result;
        return result;
    }
}
