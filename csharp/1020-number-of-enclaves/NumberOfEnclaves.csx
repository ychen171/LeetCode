public class Solution
{
    // DFS
    // Time: O(m * n)
    // Space: O(m * n)
    public int NumEnclaves(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        // edge case
        if (m <= 2 || n <= 2)
            return 0;
        // mark the groups which connect to boundaries as sea
        for (int row = 0; row < m; row++)
        {
            DFS(grid, row, 0);
            DFS(grid, row, n - 1);
        }
        for (int col = 0; col < n; col++)
        {
            DFS(grid, 0, col);
            DFS(grid, m - 1, col);
        }
        // DFS
        int ans = 0;
        for (int row = 1; row < m - 1; row++)
        {
            for (int col = 1; col < n - 1; col++)
            {
                if (grid[row][col] == 1)
                {
                    count = 0;
                    DFS(grid, row, col);
                    ans += count;
                }
            }
        }

        return ans;
    }
    int[][] directions = new int[][] { new int[] { 1, 0 }, new int[] { 0, 1 }, new int[] { -1, 0 }, new int[] { 0, -1 } };
    int count = 0;
    private void DFS(int[][] grid, int row, int col)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        // base case
        if (row < 0 || row >= m || col < 0 || col >= n) // invalid
            return;
        if (grid[row][col] == 0) // sea / visited
            return;

        // recursive case
        grid[row][col] = 0; // mark as visited
        count++;
        foreach (var dir in directions)
        {
            var nr = row + dir[0];
            var nc = col + dir[1];
            DFS(grid, nr, nc);
        }
    }
}
