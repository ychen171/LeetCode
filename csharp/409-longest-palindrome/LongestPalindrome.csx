public class Solution
{
    // Dictionary
    // Time: O(n)
    // Space: O(1)
    public int LongestPalindrome(string s)
    {
        int n = s.Length;
        if (n == 1)
            return 1;

        var letterCount = new Dictionary<char, int>();
        foreach (var c in s)
        {
            letterCount[c] = letterCount.GetValueOrDefault(c, 0) + 1;
        }

        int ans = 0;
        bool hasOdd = false;
        foreach (var kv in letterCount)
        {
            char c = kv.Key;
            int count = kv.Value;
            if (count % 2 == 0) // even
            {
                ans += count;
            }
            else // odd
            {
                hasOdd = true;
                ans += count - 1;
            }
        }
        if (hasOdd)
        {
            ans++;
        }

        return ans;
    }
}
