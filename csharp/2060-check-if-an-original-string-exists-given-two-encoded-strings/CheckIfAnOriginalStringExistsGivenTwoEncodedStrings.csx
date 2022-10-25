public class Solution
{
    // DP | Memoization Recursion
    // Time: O(m * n * (m + n))
    // Space: O(m * n * (m + n))
    Dictionary<string, bool> memo;
    public bool PossiblyEquals(string s1, string s2)
    {
        int m = s1.Length;
        int n = s2.Length;
        memo = new Dictionary<string, bool>();
        return Helper(s1, s2, 0, 0, 0);
    }

    private bool Helper(string s1, string s2, int i, int j, int diff)
    {
        int m = s1.Length;
        int n = s2.Length;
        // base case
        if (i == m && j == n)
            return diff == 0;
        var key = $"{i},{j},{diff}";
        if (memo.ContainsKey(key))
            return memo[key];
        // recursive case
        bool result = false;
        // match on s1[i] and s2[j]
        if (i < m && j < n && diff == 0 && s1[i] == s2[j] && Helper(s1, s2, i + 1, j + 1, 0))
        {
            result = true;
        }
        // match on s1[i]
        else if (i < m && char.IsLetter(s1[i]) && diff > 0 && Helper(s1, s2, i + 1, j, diff - 1))
        {
            result = true;
        }
        // match on s2[j]
        else if (j < n && char.IsLetter(s2[j]) && diff < 0 && Helper(s1, s2, i, j + 1, diff + 1))
        {
            result = true;
        }
        // wildcard match on s1[i]
        if (result == false)
        {
            for (int k = i, val = 0; k < m && char.IsDigit(s1[k]); k++)
            {
                val = val * 10 + (s1[k] - '0');
                if (Helper(s1, s2, k + 1, j, diff - val))
                {
                    result = true;
                    break;
                }
            }
        }
        // wildcard match on s2[j]
        if (result == false)
        {
            for (int k = j, val = 0; k < n && char.IsDigit(s2[k]); k++)
            {
                val = val * 10 + (s2[k] - '0');
                if (Helper(s1, s2, i, k + 1, diff + val))
                {
                    result = true;
                    break;
                }
            }
        }
        memo[key] = result;
        return result;
    }
}
