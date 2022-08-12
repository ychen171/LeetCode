public class Solution
{
    // DFS 
    // Time: O(m * n)
    // Space: O(m * n)
    int[][] directions = new int[][] { new int[] { 1, 0 }, new int[] { 0, 1 }, new int[] { -1, 0 }, new int[] { 0, -1 } };
    public int CountSubIslands(int[][] grid1, int[][] grid2)
    {
        int m = grid1.Length;
        int n = grid1[0].Length;
        // DFS to flood fill the groups in grid2 which are not sub-islands (grid1[r][c] == 0 && grid2[r][c] == 1)
        for (int row = 0; row < m; row++)
        {
            for (int col = 0; col < n; col++)
            {
                if (grid2[row][col] == 1 && grid1[row][col] == 0)
                    DFS(grid2, row, col);
            }
        }
        // DFS to flood fill all in grid2 and count
        int count = 0;
        for (int row = 0; row < m; row++)
        {
            for (int col = 0; col < n; col++)
            {
                if (grid2[row][col] == 1)
                {
                    count++;
                    DFS(grid2, row, col);
                }
            }
        }

        return count;
    }

    // flood fill
    public void DFS(int[][] grid, int row, int col)
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

        foreach (var dir in directions)
        {
            var nr = row + dir[0];
            var nc = col + dir[1];
            DFS(grid, nr, nc);
        }
    }
}
