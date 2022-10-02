public class Solution
{
    // 2d prefix sum
    // Time: O(m*n)
    // Space: O(m*n)
    public int MaxSum(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        var preSum = new int[m + 1][];
        for (int i = 0; i < m + 1; i++)
            preSum[i] = new int[n + 1];

        for (int i = 1; i < m + 1; i++)
        {
            for (int j = 1; j < n + 1; j++)
            {
                preSum[i][j] = preSum[i - 1][j] + preSum[i][j - 1] - preSum[i - 1][j - 1] + grid[i - 1][j - 1];
            }
        }

        int ans = int.MinValue;

        // 0,0 -> 2,2: 3 by 3
        for (int i = 0; i <= m - 3; i++)
        {
            for (int j = 0; j <= n - 3; j++)
            {
                // get sum of 3 by 3 area
                int sum = preSum[i + 3][j + 3] - preSum[i + 3][j] - preSum[i][j + 3] + preSum[i][j];
                // remove two cells
                int curr = sum - grid[i + 1][j] - grid[i + 1][j + 2];
                ans = Math.Max(ans, curr);
            }
        }

        return ans;
    }
}
