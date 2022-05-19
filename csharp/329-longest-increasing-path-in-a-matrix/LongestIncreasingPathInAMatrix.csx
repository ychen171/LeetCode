public class Solution
{
    // DFS | Memoization Recursion
    // Time: O(m*n)
    // Space: O(m*n)
    int[][] directions = new int[][] { new int[] { 1, 0 }, new int[] { 0, 1 }, new int[] { -1, 0 }, new int[] { 0, -1 } };
    public int LongestIncreasingPath(int[][] matrix)
    {
        int m = matrix.Length;
        int n = matrix[0].Length;
        int[][] result = new int[m][];
        int[][] memo = new int[m][];
        for (int i = 0; i < m; i++)
        {
            result[i] = new int[n];
            memo[i] = new int[n];
            for (int j = 0; j < n; j++)
            {
                result[i][j] = 1;
            }
        }

        int ans = 1;
        for (int row = 0; row < m; row++)
        {
            for (int col = 0; col < n; col++)
            {
                ans = Math.Max(ans, DFS(matrix, row, col, memo));
            }
        }
        return ans;
    }

    private int DFS(int[][] matrix, int row, int col, int[][] memo)
    {
        if (memo[row][col] != 0)
            return memo[row][col];
        // default value is 1
        int ans = 1;
        int m = matrix.Length;
        int n = matrix[0].Length;
        foreach (var dir in directions)
        {
            int r = row + dir[0];
            int c = col + dir[1];
            if (r < 0 || r >= m || c < 0 || c >= n) // invalid
                continue;
            // it is increasing. Will never visit the same cell twice 
            if (matrix[r][c] > matrix[row][col])
            {
                ans = Math.Max(ans, DFS(matrix, r, c, memo) + 1);
            }
        }

        memo[row][col] = ans;
        return ans;
    }
}
