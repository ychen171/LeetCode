public class Solution
{
    // DP | Top-down Memoization Recursion
    // Time: O(m * n)
    // Space: O(m * n)
    public int MinDistance(string word1, string word2)
    {
        int m = word1.Length;
        int n = word2.Length;

        var memo = new int[m, n];
        var lcs = Helper(word1, word2, 0, 0, memo);
        return m + n - 2 * lcs;
    }

    // longest common subsequence
    private int Helper(string word1, string word2, int i, int j, int[,] memo)
    {
        int m = word1.Length;
        int n = word2.Length;
        // base case
        if (i > m - 1 || j > n - 1)
            return 0;
        if (memo[i, j] != 0)
            return memo[i, j];
        int result = 0;
        // recursive case
        if (word1[i] == word2[j])
            result = 1 + Helper(word1, word2, i + 1, j + 1, memo);
        else
            result = Math.Max(Helper(word1, word2, i + 1, j, memo), Helper(word1, word2, i, j + 1, memo));

        memo[i, j] = result;
        return result;
    }

    // DP | Bottom-up Tabulation Iteration
    // Time: O(m * n)
    // Space: O(m * n)
    public int MinDistance1(string word1, string word2)
    {
        // initialize the table with default values
        int m = word1.Length;
        int n = word2.Length;
        var table = new int[m + 1][];
        for (int i = 0; i < m + 1; i++)
        {
            table[i] = new int[n + 1];
        }
        // seed the trivial answer into the table
        // fill further positions based on current position
        for (int i = m - 1; i >= 0; i--)
        {
            for (int j = n - 1; j >= 0; j--)
            {
                if (word1[i] == word2[j]) // current chars at i and j are equal
                {
                    table[i][j] = Math.Max(table[i][j], table[i + 1][j + 1] + 1);
                }
                else // chars at i and j are different
                {
                    int temp = Math.Max(table[i][j + 1], table[i + 1][j]);
                    table[i][j] = Math.Max(table[i][j], temp);
                }
            }
        }
        var lcs = table[0][0];
        return m + n - 2 * lcs;
    }
}
