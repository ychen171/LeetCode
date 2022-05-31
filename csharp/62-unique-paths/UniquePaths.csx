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
}
