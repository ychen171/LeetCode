public class Solution
{
    // Dictionary | Array | TLE
    // Time: O(m * n^2)
    // Space: O(m)
    public int UniqueLetterString(string s)
    {
        int n = s.Length;
        int ans = 0;
        // [i, j]
        for (int i = 0; i < n; i++)
        {
            for (int j = i; j < n; j++)
            {
                var count = CountUniqueChars(s, i, j);
                ans += count;
            }
        }
        return ans;
    }

    // Time: O(n)
    // Space: O(26) => O(1)
    public int CountUniqueChars(string s, int l, int r)
    {
        int ans = 0;
        var countArray = new int[26];
        for (int i = l; i <= r; i++)
        {
            var c = s[i];
            countArray[c - 'A']++;
        }
        foreach (var count in countArray)
        {
            if (count == 1)
                ans++;
        }
        return ans;
    }

    // DP 
    // Time: O(n)
    // Space: O(26) => O(1)
    public int UniqueLetterString1(string s)
    {
        /*
            n = s.Length
            states: dp[i], 
            i: last index of current substring, [0, n-1]
            dp[i]: the unique count of all substrings in [0, i]

            goals: dp[n-1]

            dp[i] = dp[i-1] - count[s[i]] + (i - lastIndex[s[i]])

            base case:
            dp[-1] = 0;
            dp[0] = 0 - 0 + (0 - (-1)) = 1

        */

        if (s == null || s.Length == 0)
            return 0;
        int ans = 0;
        var lastIndex = new int[26];
        for (int i = 0; i < 26; i++)
            lastIndex[i] = -1;
        var count = new int[26];
        int dpi = 0;
        for (int i = 0; i < s.Length; i++)
        {
            var c = s[i];
            dpi -= count[c - 'A'];
            count[c - 'A'] = (i - lastIndex[c - 'A']);
            dpi += count[c - 'A'];
            lastIndex[c - 'A'] = i;
            ans += dpi;
        }

        return ans;
    }

    // all unique substrings
    // Time: O(n)
    // Space: O(n)
    public int UniqueLetterString2(string s)
    {
        int n = s.Length;
        var lastIndex = new int[26][];
        for (int k = 0; k < 26; k++)
        {
            lastIndex[k] = new int[2] { -1, -1 };
        }

        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            var c = s[i];
            int leftLimit = lastIndex[c - 'A'][0];
            int mid = lastIndex[c - 'A'][1];
            int leftRange = mid - leftLimit;
            int rightRange = i - mid;
            int count = leftRange * rightRange;
            ans += count;

            // update lastIndex
            lastIndex[c - 'A'][0] = lastIndex[c - 'A'][1];
            lastIndex[c - 'A'][1] = i;
        }

        for (int i = 0; i < 26; i++)
        {
            int leftRange = lastIndex[i][1] - lastIndex[i][0];
            int rightRange = n - lastIndex[i][1];
            int count = leftRange * rightRange;
            ans += count;
        }

        return ans;
    }
}
