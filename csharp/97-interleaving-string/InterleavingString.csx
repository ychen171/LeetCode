public class Solution
{
    // DP | Tabulation | Iteration
    // Time: O(m*n)
    // Space: O(m*n)
    public bool IsInterleave(string s1, string s2, string s3)
    {
        /*
            aabcc  dbbca       aadbbcbcac
            aa   bcc    dbbca
            aad  bcc    bbca
            aadb  cc    b
        */
        int len1 = s1.Length;
        int len2 = s2.Length;
        int len3 = s3.Length;
        // edge case
        if (len1 + len2 != len3)
            return false;

        var dp = new bool[len1 + 1, len2 + 1];
        dp[0, 0] = true;
        for (int i = 1; i < len1 + 1; i++)
            dp[i, 0] = dp[i - 1, 0] && s1[i - 1] == s3[i - 1];
        for (int j = 1; j < len2 + 1; j++)
            dp[0, j] = dp[0, j - 1] && s2[j - 1] == s3[j - 1];
        for (int i = 1; i < len1 + 1; i++)
        {
            for (int j = 1; j < len2 + 1; j++)
            {
                dp[i, j] = (dp[i - 1, j] && s1[i - 1] == s3[i + j - 1]) || (dp[i, j - 1] && s2[j - 1] == s3[i + j - 1]);
            }
        }

        return dp[len1, len2];
    }

    // DP | Top-down | Memoization | Recursion
    // Time: O(m*n)
    // Space: O(m*n)
    public bool IsInterleave1(string s1, string s2, string s3)
    {
        int len1 = s1.Length;
        int len2 = s2.Length;
        int len3 = s3.Length;
        if (len1 + len2 != len3)
            return false;

        var memo = new int[len1 + 1, len2 + 1];
        return Helper(s1, s2, s3, 0, 0, memo);
    }

    public bool Helper(string s1, string s2, string s3, int i, int j, int[,] memo)
    {
        int len1 = s1.Length;
        int len2 = s2.Length;
        int len3 = s3.Length;
        // base case
        if (i == len1 && j == len2)
            return true;

        if (memo[i, j] != 0)
            return memo[i, j] == 1;

        // recursive case
        bool currI = false;
        bool currJ = false;
        if (i < len1 && s1[i] == s3[i + j])
            currI = Helper(s1, s2, s3, i + 1, j, memo);
        if (j < len2 && s2[j] == s3[i + j])
            currJ = Helper(s1, s2, s3, i, j + 1, memo);

        bool result = currI || currJ;
        memo[i, j] = result ? 1 : -1;
        return result;
    }
}

var s = new Solution();
var s1 = "a";
var s2 = "";
var s3 = "a";
var result = s.IsInterleave(s1, s2, s3);
Console.WriteLine(result);
