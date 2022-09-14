public class Solution
{
    // 2D Prefix Sum
    // Time: O(m * n)
    // Space: O(m * n)
    public int[][] MatrixBlockSum(int[][] mat, int k)
    {
        // create 2D prefix sum
        int m = mat.Length;
        int n = mat[0].Length;
        var preSum = new int[m + 1][];
        preSum[0] = new int[n + 1];
        for (int i = 1; i < m + 1; i++)
        {
            preSum[i] = new int[n + 1];
            for (int j = 1; j < n + 1; j++)
            {
                preSum[i][j] = preSum[i - 1][j] + preSum[i][j - 1] + mat[i - 1][j - 1] - preSum[i - 1][j - 1];
            }
        }

        for (int r = 0; r < m; r++)
        {
            for (int c = 0; c < n; c++)
            {
                int r1 = Math.Max(0, r - k);
                int c1 = Math.Max(0, c - k);
                int r2 = Math.Min(m - 1, r + k);
                int c2 = Math.Min(n - 1, c + k);
                var sum = preSum[r2 + 1][c2 + 1] - preSum[r1][c2 + 1] - preSum[r2 + 1][c1] + preSum[r1][c1];
                mat[r][c] = sum;
            }
        }

        return mat;
    }
}
