public class Solution
{
    // DP | Memoization Recursion
    // Time: O(n * k^2)
    // Space: O(n * k^2)
    Dictionary<int, int> memo;
    HashSet<int> add;
    public int GetLengthOfOptimalCompression(string s, int k)
    {
        /*
            states: dp[i][r], i: index, [i, n-1], r: remaining chacters to delete, [0, k]
            goal: dp[..][0]
        */
        memo = new Dictionary<int, int>();
        add = new HashSet<int>() { 1, 9, 99 };
        return Helper(s, 0, (char)('a' + 26), 0, k);
    }

    private int Helper(string s, int index, char lastChar, int lastCharCount, int k)
    {
        int n = s.Length;
        // base case
        if (k < 0)
            return int.MaxValue / 2;
        if (index == n)
            return 0;

        // recursive case
        int key = index * 101 * 27 * 101 + (lastChar - 'a') * 101 * 101 + lastCharCount * 101 + k;
        if (memo.ContainsKey(key))
            return memo[key];

        int keepChar;
        int deleteChar = Helper(s, index + 1, lastChar, lastCharCount, k - 1);
        if (s[index] == lastChar)
        {
            keepChar = Helper(s, index + 1, lastChar, lastCharCount + 1, k) + (add.Contains(lastCharCount) ? 1 : 0);
        }
        else
        {
            keepChar = Helper(s, index + 1, s[index], 1, k) + 1;
        }
        int result = Math.Min(keepChar, deleteChar);
        memo[key] = result;
        return result;
    }
}