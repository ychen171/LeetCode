public class Solution
{
    // DP | Tabulation
    // Time: O(m * n)
    // Space: O(m * n)
    public int UniquePaths(int m, int n)
    {
        // initialize the table with default value
        var table = new int[m, n];
        // seed the trivial answer into the table
        for (int i = 0; i < m; i++)
            table[i, 0] = 1;
        for (int j = 0; j < n; j++)
            table[0, j] = 1;

        // fill further positions based on current position
        for (int i = 1; i < m; i++)
        {
            for (int j = 1; j < n; j++)
            {
                table[i, j] = table[i - 1, j] + table[i, j - 1];
            }
        }

        return table[m - 1, n - 1];
    }
    
    // DP | Memoization Recursion
    // Time: O(m * n)
    // Space: O(m * n)
    int m;
    int n;
    int[][] memo;
    public int UniquePathsMemo(int m, int n) 
    {
        this.m = m;
        this.n = n;
        memo = new int[m][];
        for (int r = 0; r < m; r++)
            memo[r] = new int[n];
        
        return Helper(m - 1, n - 1);
    }
    
    private int Helper(int r, int c)
    {
        // base case
        if (r == 0 && c == 0)
            return 1;
        if (r < 0 || c < 0)
            return 0;
        if (memo[r][c] != 0)
            return memo[r][c];
        
        // recursive case
        var result = Helper(r - 1, c) + Helper(r, c - 1);
        memo[r][c] = result;
        return result;
    }
}
