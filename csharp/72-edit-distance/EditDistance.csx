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
        return Helper(word1, 0, word2, 0);
    }

    public int Helper(string s1, int i, string s2, int j)
    {
        // for s1[i...] and s2[j...], min distance is the return value
        int m = s1.Length;
        int n = s2.Length;
        // base case
        if (i == m)
            return n - j;
        if (j == n)
            return m - i;

        if (memo[i][j] != 1001)
            return memo[i][j];

        // recursive case
        int ans = 1001;
        if (s1[i] == s2[j]) // matched
            ans = Helper(s1, i + 1, s2, j + 1);
        else // not matched
        {
            ans = Math.Min(ans, Helper(s1, i, s2, j + 1) + 1);      // insert
            ans = Math.Min(ans, Helper(s1, i + 1, s2, j) + 1);      // delete
            ans = Math.Min(ans, Helper(s1, i + 1, s2, j + 1) + 1);  // replace
        }
        memo[i][j] = ans;
        return ans;
    }
}
