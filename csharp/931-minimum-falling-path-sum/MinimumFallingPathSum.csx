public class Solution
{
    int[][] memo;
    public int MinFallingPathSum(int[][] matrix)
    {
        int m = matrix.Length;
        int n = matrix[0].Length;
        memo = new int[m][];
        for (int r = 0; r < m; r++)
        {
            memo[r] = new int[n];
            for (int c = 0; c < n; c++)
            {
                memo[r][c] = int.MaxValue;
            }
        }
        int result = int.MaxValue;
        for (int c = 0; c < n; c++)
        {
            result = Math.Min(result, DFS(matrix, 0, c));
        }
        return result;
    }

    private int DFS(int[][] matrix, int r, int c)
    {
        // base case
        int m = matrix.Length;
        int n = matrix[0].Length;
        if (r < 0 || r >= m || c < 0 || c >= n)
            return int.MaxValue;
        if (memo[r][c] != int.MaxValue)
            return memo[r][c];
        // recursive case
        int sub = int.MaxValue;
        sub = Math.Min(sub, DFS(matrix, r + 1, c - 1));
        sub = Math.Min(sub, DFS(matrix, r + 1, c));
        sub = Math.Min(sub, DFS(matrix, r + 1, c + 1));
        int result = matrix[r][c] + (sub == int.MaxValue ? 0 : sub);
        memo[r][c] = result;
        return result;
    }
}
