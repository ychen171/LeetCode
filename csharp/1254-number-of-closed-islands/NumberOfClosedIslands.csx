public class Solution
{
    // DFS
    // Time: O(m*n)
    // Space: O(m*n)
    int[][] directions = new int[][] { new int[] { 1, 0 }, new int[] { 0, 1 }, new int[] { -1, 0 }, new int[] { 0, -1 } };
    public int ClosedIsland(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        // edge case
        if (m <= 2 || n <= 2)
            return 0;

        int count = 0;
        // flood 4 edges
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

        for (int row = 1; row < m - 1; row++)
        {
            for (int col = 1; col < n - 1; col++)
            {
                if (grid[row][col] == 0)
                {
                    count++;
                    DFS(grid, row, col);
                }
            }
        }

        return count;
    }


    private void DFS(int[][] grid, int row, int col)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        // base case
        if (row < 0 || row >= m || col < 0 || col >= n) // invalid
            return;
        if (grid[row][col] == 1) // visited / water
            return;

        // recursive case
        grid[row][col] = 1;
        foreach (var dir in directions)
        {
            var r = row + dir[0];
            var c = col + dir[1];
            DFS(grid, r, c);
        }

    }

    bool isClosed;
    public int ClosedIsland1(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        // edge case
        if (m <= 2 || n <= 2)
            return 0;

        int count = 0;
        for (int row = 1; row < m - 1; row++)
        {
            for (int col = 1; col < n - 1; col++)
            {
                if (grid[row][col] == 0)
                {
                    isClosed = true;
                    DFS1(grid, row, col);
                    if (isClosed) count++;
                }
            }
        }

        return count;
    }

    public void DFS1(int[][] grid, int row, int col)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        // base case
        if (row == 0 || row == m - 1 || col == 0 || col == n - 1) // edge
        {
            if (grid[row][col] == 0) // open island
                isClosed = false;

            return;
        }
        if (!isClosed)
            return;
        if (grid[row][col] == 1) // water
            return;

        // recursive case
        grid[row][col] = 1;
        foreach (var dir in directions)
        {
            var nr = row + dir[0];
            var nc = col + dir[1];
            DFS1(grid, nr, nc);
        }
    }
}

var s = new Solution();
// [[1,1,1,1,1,1,1,0],[1,0,0,0,0,1,1,0],[1,0,1,0,1,1,1,0],[1,0,0,0,0,1,0,1],[1,1,1,1,1,1,1,0]]
var grid = new int[][] { new int[] { 1, 1, 1, 1, 1, 1, 1, 0 }, new int[] { 1, 0, 0, 0, 0, 1, 1, 0 }, new int[] { 1, 0, 1, 0, 1, 1, 1, 0 }, new int[] { 1, 0, 0, 0, 0, 1, 0, 1 }, new int[] { 1, 1, 1, 1, 1, 1, 1, 0 } };
var result = s.ClosedIsland(grid);
Console.WriteLine(result);

