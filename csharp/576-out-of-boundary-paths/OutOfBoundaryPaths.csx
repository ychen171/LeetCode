public class Solution
{
    int[][] directions = new int[][] { new int[] { 1, 0 }, new int[] { 0, 1 }, new int[] { -1, 0 }, new int[] { 0, -1 } };
    int m;
    int n;
    int maxMove;
    // DP | Memoization | Recursion
    // Time: O(m*n*k)
    // Space: O(m*n*k)
    public int FindPaths(int m, int n, int maxMove, int startRow, int startColumn)
    {
        this.m = m;
        this.n = n;
        this.maxMove = maxMove;
        var memo = new long[m][][];
        for (int i = 0; i < m; i++)
        {
            memo[i] = new long[n][];
            for (int j = 0; j < n; j++)
            {
                memo[i][j] = new long[maxMove + 1];
                Array.Fill(memo[i][j], -1);
            }
        }
        long ans = Helper(startRow, startColumn, 0, memo) % 1000000007;
        return (int)ans;
    }

    public long Helper(int row, int col, int currMove, long[][][] memo)
    {
        // base case
        if (currMove > maxMove)
            return 0;
        if (row < 0 || row >= m || col < 0 || col >= n)
            return 1;

        if (memo[row][col][currMove] != -1)
            return memo[row][col][currMove];
        // recursive case
        long ans = 0;
        foreach (var dir in directions)
        {
            int r = row + dir[0];
            int c = col + dir[1];
            ans += (Helper(r, c, currMove + 1, memo) % 1000000007) % 1000000007;
        }
        ans %= 1000000007;
        memo[row][col][currMove] = ans;
        return ans;
    }
}
