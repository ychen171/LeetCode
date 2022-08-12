public class Solution
{
    // DFS
    // Time: O(m*n)
    // Space: O(m*n)
    int[][] directions = new int[][] { new int[] { 1, 0 }, new int[] { 0, 1 }, new int[] { -1, 0 }, new int[] { 0, -1 } };
    public int NumDistinctIslands(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        var distinctSet = new HashSet<string>();
        int count = 0;
        for (int row = 0; row < m; row++)
        {
            for (int col = 0; col < n; col++)
            {
                if (grid[row][col] == 1)
                {
                    var keyBuilder = new StringBuilder();
                    DFS(grid, row, col, row, col, keyBuilder);
                    var key = keyBuilder.ToString();
                    if (distinctSet.Add(key))
                        count++;
                }
            }
        }

        return count;
    }

    public void DFS(int[][] grid, int row, int col, int startRow, int startCol, StringBuilder keyBuilder)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        // base case
        if (row < 0 || row >= m || col < 0 || col >= n) // invalid
            return;
        if (grid[row][col] == 0) // visited
            return;
        // recursive case
        grid[row][col] = 0; // mark as visited

        keyBuilder.Append(row - startRow).Append(',');
        keyBuilder.Append(col - startCol).Append(',');

        foreach (var dir in directions)
        {
            var nr = row + dir[0];
            var nc = col + dir[1];
            DFS(grid, nr, nc, startRow, startCol, keyBuilder);
        }
    }
}
