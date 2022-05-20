public class Solution
{
    // DP | Tabulation
    // Time: O(m*n)
    // Space: O(1)
    public int UniquePathsWithObstacles(int[][] obstacleGrid)
    {
        // start with obstacle, early return
        if (obstacleGrid[0][0] == 1)
            return 0;
        // 1 path at the staring cell
        obstacleGrid[0][0] = 1;
        int m = obstacleGrid.Length;
        int n = obstacleGrid[0].Length;
        // fill the values for first row and first column
        for (int i = 1; i < m; i++)
        {
            if (obstacleGrid[i][0] == 1)
                obstacleGrid[i][0] = 0;
            else
                obstacleGrid[i][0] = obstacleGrid[i - 1][0];
        }
        for (int j = 1; j < n; j++)
        {
            if (obstacleGrid[0][j] == 1)
                obstacleGrid[0][j] = 0;
            else
                obstacleGrid[0][j] = obstacleGrid[0][j - 1];
        }

        // fill further positions based on current positions
        for (int i = 1; i < m; i++)
        {
            for (int j = 1; j < n; j++)
            {
                if (obstacleGrid[i][j] == 1) // it is obstacle, cannot be the path, reset ans to 0
                {
                    obstacleGrid[i][j] = 0;
                }
                else
                {
                    if (i - 1 >= 0)
                    {
                        obstacleGrid[i][j] += obstacleGrid[i - 1][j];
                    }
                    if (j - 1 >= 0)
                    {
                        obstacleGrid[i][j] += obstacleGrid[i][j - 1];
                    }
                }
            }
        }

        return obstacleGrid[m - 1][n - 1];
    }
}
