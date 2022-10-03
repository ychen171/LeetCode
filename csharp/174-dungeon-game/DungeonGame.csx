public class Solution
{
    // DP | Memoization Recursion
    // Time: O(m * n)
    // Space: O(m * n)
    int[][] memo;
    public int CalculateMinimumHP(int[][] dungeon)
    {
        int m = dungeon.Length;
        int n = dungeon[0].Length;
        memo = new int[m][];
        for (int i = 0; i < m; i++)
            memo[i] = new int[n];
        return Helper(dungeon, 0, 0);
    }

    public int Helper(int[][] dungeon, int r, int c)
    {
        int m = dungeon.Length;
        int n = dungeon[0].Length;
        // base case
        if (r < 0 || r >= m || c < 0 || c >= n)
            return int.MaxValue;
        if (r == m - 1 && c == n - 1)
            return dungeon[r][c] >= 0 ? 1 : 1 - dungeon[r][c];
        if (memo[r][c] != 0)
            return memo[r][c];

        // recursive case
        int sub1 = Helper(dungeon, r + 1, c);
        int sub2 = Helper(dungeon, r, c + 1);
        // hp must be at least 1
        int result = Math.Max(1, Math.Min(sub1, sub2) - dungeon[r][c]);

        memo[r][c] = result;
        return result;
    }

    // DP | Tabulation
    // Time: O(m*n)
    // Space: O(m*n)
    public int CalculateMinimumHP1(int[][] dungeon)
    {
        /*
            states: dp[r][c]
            option: down, right
            goal: dp[0][0]

            dp[r][c] = Math.Max(1, Math.Min(dp[r + 1][c], dp[r][c + 1]) - dungeon[r][c]);

            base case:
            dp[m-1][n-1] = Math.Max(1, 1 - dungeon[m-1][n-1])

            dp[m-1][c] = Math.Max(1, dp[m - 1][c + 1] - dungeon[r][c]);
            dp[r][n-1] = Math.Max(1, dp[r + 1][n - 1] - dungeon[r][c]);
        */
        int m = dungeon.Length;
        int n = dungeon[0].Length;
        var dp = new int[m][];
        for (int r = 0; r < m; r++)
            dp[r] = new int[n];
        dp[m - 1][n - 1] = Math.Max(1, 1 - dungeon[m - 1][n - 1]);
        for (int r = m - 2; r >= 0; r--)
            dp[r][n - 1] = Math.Max(1, dp[r + 1][n - 1] - dungeon[r][n - 1]);
        for (int c = n - 2; c >= 0; c--)
            dp[m - 1][c] = Math.Max(1, dp[m - 1][c + 1] - dungeon[m - 1][c]);

        for (int r = m - 2; r >= 0; r--)
        {
            for (int c = n - 2; c >= 0; c--)
            {
                dp[r][c] = Math.Max(1, Math.Min(dp[r + 1][c], dp[r][c + 1]) - dungeon[r][c]);
            }
        }

        return dp[0][0];
    }

    public int CalculateMinimumHP2(int[][] dungeon)
    {
        int m = dungeon.Length;
        int n = dungeon[0].Length;
        var dp = new int[m + 1][];
        for (int r = 0; r < m + 1; r++)
            dp[r] = new int[n + 1];

        for (int r = m; r >= 0; r--)
        {
            for (int c = n; c >= 0; c--)
            {
                if (r == m || c == n)
                {
                    dp[r][c] = int.MaxValue;
                    continue;
                }
                if (r == m - 1 && c == n - 1)
                {
                    dp[r][c] = dungeon[r][c] >= 0 ? 1 : 1 - dungeon[r][c];
                    continue;
                }
                dp[r][c] = Math.Max(1, Math.Min(dp[r + 1][c], dp[r][c + 1]) - dungeon[r][c]);
            }
        }

        return dp[0][0];
    }
}
