public class Solution
{
    // DP | Tabulation
    // Time: O(n^2)
    // Space: O(n^2)
    public int LongestPalindromeSubseq(string s)
    {
        /*
            states: dp[i][j], i: the start index [0, n-1], j: the end index [i, n-1]
            goal: dp[0][n-1]

            dp[i][j] = dp[i+1][j-1] + 2, if s[i] == s[j]
            dp[i][j] = Math.Max(dp[i+1][j], dp[i][j-1]), if s[i] != s[j]

            base case:
            dp[i][i] = 1
        */

        var n = s.Length;
        var dp = new int[n][];
        for (int i = 0; i < n; i++)
        {
            dp[i] = new int[n];
            dp[i][i] = 1;
        }

        for (int i = n - 1; i >= 0; i--)
        {
            for (int j = i + 1; j < n; j++)
            {
                if (s[i] == s[j])
                {
                    dp[i][j] = dp[i + 1][j - 1] + 2;
                }
                else
                {
                    dp[i][j] = Math.Max(dp[i + 1][j], dp[i][j - 1]);
                }
            }
        }

        return dp[0][n - 1];
    }
}
