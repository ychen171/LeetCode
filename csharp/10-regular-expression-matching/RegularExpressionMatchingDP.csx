public class Solution
{
    // DP | Memoization | Recursion
    // Time: O(m * n)
    // Space: O(m * n)
    int[][] memo;
    public bool IsMatch(string s, string p)
    {
        int m = s.Length;
        int n = p.Length;
        memo = new int[m][];
        for (int i = 0; i < m; i++)
            memo[i] = new int[n];
        return Helper(s, 0, p, 0);
    }

    public bool Helper(string s, int i, string p, int j)
    {
        // s[i...] matches p[j...]
        int m = s.Length;
        int n = p.Length;
        // base case
        if (j == n)
        {
            return i == m;
        }
        if (i == m)
        {
            if ((n - j) % 2 == 1)
                return false;
            for (; j + 1 < n; j += 2)
            {
                if (p[j + 1] != '*')
                    return false;
            }
            return true;
        }

        if (memo[i][j] != 0)
            return memo[i][j] == 1;

        // recursive case
        bool result = false;
        if (s[i] == p[j] || p[j] == '.')
        {
            if (j + 1 < n && p[j + 1] == '*')   // abc vs a**bc || aabc vs a*bc
                result = Helper(s, i, p, j + 2) || Helper(s, i + 1, p, j);
            else                                // abc vs *bc
                result = Helper(s, i + 1, p, j + 1);
        }
        else
        {
            if (j + 1 < n && p[j + 1] == '*')  // abc vs **a
                result = Helper(s, i, p, j + 2);
            else
                result = false;
        }
        memo[i][j] = result ? 1 : -1;
        return result;
    }
}
