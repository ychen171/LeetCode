public class Solution
{
    // Modulo
    // Time: O(m*n)
    // Space: O(m*n)
    public IList<IList<int>> ShiftGrid(int[][] grid, int k)
    {
        // shift to right by k
        // enter next row if reaches the end of column
        int m = grid.Length;
        int n = grid[0].Length;
        IList<IList<int>> result = new List<IList<int>>();
        for (int i = 0; i < m; i++)
        {
            result.Add(new List<int>());
            for (int j = 0; j < n; j++)
                result[i].Add(0);
        }
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                int row = (i + (j + k) / n) % m;
                int col = (j + k) % n;
                // Console.WriteLine($"row:{row}, col:{col}");
                result[row][col] = grid[i][j];
            }
        }

        return result;
    }
}