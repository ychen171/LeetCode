public class Solution
{
    long ans = 0;
    public int NumberOfPaths(int[][] grid, int k)
    {
        Backtrack(grid, k, 0, 0, 0);
        return (int)(ans % 1000000007);
    }

    public void Backtrack(int[][] grid, int k, long currSum, int r, int c)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        // base case
        if (r == m || c == n)
            return;
        currSum += grid[r][c];
        if (r == m - 1 && c == n - 1)
        {
            if (currSum % k == 0)
                ans++;
            return;
        }

        // recursive case
        Backtrack(grid, k, currSum, r + 1, c);
        Backtrack(grid, k, currSum, r, c + 1);
        currSum -= grid[r][c];
    }
}
