public class Solution
{
    int m;
    int n;
    public int[] FindBall(int[][] grid)
    {
        this.m = grid.Length;
        this.n = grid[0].Length;
        var result = new int[n];
        for (int i = 0; i < n; i++)
            result[i] = Helper(grid, 0, i);
        return result;
    }

    private int Helper(int[][] grid, int r, int c)
    {
        // base case
        if (r == m) // go through
            return c;
        if (grid[r][c] == 1 && (c == n - 1 || grid[r][c + 1] == -1)) // get stuck
            return -1;
        if (grid[r][c] == -1 && (c == 0 || grid[r][c - 1] == 1)) // get stuck
            return -1;

        // recursive case
        return Helper(grid, r + 1, c + grid[r][c]);
    }
}
// DFS
// Time: O(m * n)
// Space: O(m)
