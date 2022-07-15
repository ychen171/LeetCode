public class Solution
{
    // DFS | Recursion
    // Time: O(m * n)
    // Space: O(m * n)
    int[][] directions = new int[][] { new int[] { 1, 0 }, new int[] { 0, 1 }, new int[] { -1, 0 }, new int[] { 0, -1 } };
    public int MaxAreaOfIsland(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        int ans = 0;
        for (int row = 0; row < m; row++)
        {
            for (int col = 0; col < n; col++)
            {
                if (grid[row][col] == 1)
                {
                    int area = Helper(grid, row, col);
                    ans = Math.Max(ans, area);
                }
            }
        }

        return ans;
    }

    public int Helper(int[][] grid, int row, int col)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        // base case
        if (grid[row][col] == 0)
            return 0;

        grid[row][col] = -1; // mark visited
        int area = 1;
        // recursive case
        foreach (var dir in directions)
        {
            int r = row + dir[0];
            int c = col + dir[1];
            if (r < 0 || r >= m || c < 0 || c >= n) // invalid
                continue;
            if (grid[r][c] == -1) // visited
                continue;

            area += Helper(grid, r, c);
        }

        return area;
    }

    // DFS | Iteration
    // Time: O(m * n)
    // Space: O(m * n)
    public int MaxAreaOfIsland1(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;

        int ans = 0;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] == 1)
                {
                    int area = 0;
                    var stack = new Stack<int[]>();
                    stack.Push(new int[] { i, j });
                    grid[i][j] = -1;
                    while (stack.Count != 0)
                    {
                        var item = stack.Pop();
                        int row = item[0];
                        int col = item[1];
                        area++;
                        foreach (var dir in directions)
                        {
                            int r = row + dir[0];
                            int c = col + dir[1];
                            if (r < 0 || r >= m || c < 0 || c >= n || grid[r][c] == 0) // invalid
                                continue;
                            if (grid[r][c] == -1) // visited
                                continue;
                            stack.Push(new int[] { r, c });
                            grid[r][c] = -1;
                        }
                    }
                    ans = Math.Max(ans, area);
                }
            }
        }

        return ans;
    }
}
