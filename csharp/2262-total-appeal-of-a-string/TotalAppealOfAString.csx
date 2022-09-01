public class Solution
{
    // all substrings
    // Time: O(n)
    // Space: O(26) => O(1)
    public long AppealSum(string s)
    {
        int n = s.Length;
        var lastIndex = new int[26];
        for (int i = 0; i < 26; i++)
            lastIndex[i] = -1;

        long ans = 0;
        for (int i = 0; i < n; i++)
        {
            var c = s[i];
            int leftLimit = lastIndex[c - 'a'];
            int rightLimit = n;
            int leftRange = i - leftLimit;
            int rightRange = n - i;
            long count = leftRange * rightRange;
            ans += count;

            lastIndex[c - 'a'] = i;
        }

        return ans;
    }
}
