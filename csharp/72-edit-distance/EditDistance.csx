public class Solution
{
    // DP | Memoization | Recursion
    // Time: O(m * n)
    // Space: O(m * n)
    int[][] memo;
    public int MinDistance(string word1, string word2)
    {
        int m = word1.Length;
        int n = word2.Length;
        memo = new int[m][];
        for (int i = 0; i < m; i++)
        {
            memo[i] = new int[n];
            for (int j = 0; j < n; j++)
                memo[i][j] = 1001; // 500 * 2 + 1
        }
        return Helper(word1, m - 1, word2, n - 1);
    }

    public int Helper(string s1, int i, string s2, int j)
    {
        // for s1[0, i] and s2[0, j], min distance is the return value
        int m = s1.Length;
        int n = s2.Length;
        // base case
        if (i == -1)
            return j + 1;
        if (j == -1)
            return i + 1;

        if (memo[i][j] != 1001)
            return memo[i][j];

        // recursive case
        int ans = 1001;
        if (s1[i] == s2[j]) // matched
            ans = Helper(s1, i - 1, s2, j - 1);
        else // not matched
        {
            ans = Math.Min(ans, Helper(s1, i, s2, j - 1) + 1);      // insert
            ans = Math.Min(ans, Helper(s1, i - 1, s2, j) + 1);      // delete
            ans = Math.Min(ans, Helper(s1, i - 1, s2, j - 1) + 1);  // replace
        }
        memo[i][j] = ans;
        return ans;
    }

    // DP Tabulation Iteration
    // Time: O(m * n)
    // Space: O(m * n)
    public int MinDistance1(string word1, string word2)
    {
        /*
            states: dp[i][j]: the min distance for s1[0, i] and s2[0, j]
                    i: last index of curr substr, [0, m-1], 
                    j: last index of curr substr, [0, n-1]
            options: skip, insert, delete, replace
            goal: dp[m-1][n-1]

            dp[i][j] = Math.Min(dp[i][j], dp[i-1][j-1])     // skip
            dp[i][j] = Math.Min(dp[i][j], dp[i][j-1] + 1)  // insert
            dp[i][j] = Math.Min(dp[i][j], dp[i-1][j] + 1)  // delete
            dp[i][j] = Math.Min(dp[i][j], dp[i-1][j-1] + 1)  // replace

            base case:
            dp[-1][j] = j + 1
            dp[i][-1] = i + 1
        */
        int m = word1.Length;
        int n = word2.Length;
        var dp = new int[m + 1][];
        for (int i = 0; i < m + 1; i++)
        {
            dp[i] = new int[n + 1];
            for (int j = 0; j < n + 1; j++)
                dp[i][j] = 1001;
        }
        for (int i = 0; i < m + 1; i++)
            dp[i][0] = i;
        for (int j = 0; j < n + 1; j++)
            dp[0][j] = j;

        for (int i = 1; i < m + 1; i++)
        {
            for (int j = 1; j < n + 1; j++)
            {
                if (word1[i - 1] == word2[j - 1])
                    dp[i][j] = Math.Min(dp[i][j], dp[i - 1][j - 1]);
                else
                {
                    dp[i][j] = Math.Min(dp[i][j], dp[i][j - 1] + 1);  // insert
                    dp[i][j] = Math.Min(dp[i][j], dp[i - 1][j] + 1);  // delete
                    dp[i][j] = Math.Min(dp[i][j], dp[i - 1][j - 1] + 1);  // replace
                }
            }
        }

        return dp[m][n];
    }
}
