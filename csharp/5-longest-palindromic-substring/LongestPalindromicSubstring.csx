public class Solution
{
    // Two pointers
    // Time: O(n^2)
    // Space: O(1)
    public string LongestPalindrome(string s)
    {
        if (s == null || s.Length <= 1) return s;
        int targetLen = 0;
        int left = 0;
        int right = 0;

        for (int i = 0; i < s.Length; i++)
        {
            for (int j = i + targetLen; j < s.Length; j++)
            {
                var currLen = j - i + 1;
                if (currLen > targetLen && IsPalindrome(s, i, j))
                {
                    targetLen = currLen;
                    left = i;
                    right = j;
                }
            }
        }

        return s.Substring(left, targetLen);
    }

    public bool IsPalindrome(string s, int left, int right)
    {
        if (s == null || s.Length <= 1) return true;
        var mid = left + (right - left) / 2;
        while (right > mid)
        {
            if (s[left] != s[right])
                return false;
            left++;
            right--;
        }
        return true;
    }

    // Expand Around Center
    // Time: O(n^2)
    // Space: O(1)
    public string LongestPalindrome1(string s)
    {
        // babad
        // b            odd = 1,    even = 0        currMaxLen = 1
        // a    bab     odd = 3,    even = 0        currMaxLen = 3
        // b    aba     odd = 3,    even = 0        currMaxLen = 3
        // a            odd = 1                     currMaxLen = 1
        // d            odd = 1                     currMaxLen = 1
        // cbbd
        // c            odd = 1,    even = 0        currMaxLen = 1
        // b            odd = 1, bb even = 2        currMaxLen = 2
        // b            odd = 1,    even = 0        currMaxLen = 1
        // ccc
        // c            odd = 1,    cc      even = 2
        // c    ccc     odd = 3     cc      even = 2
        int start = 0;
        int len = 0;
        for (int i = 0; i < s.Length; i++)
        {
            int oddLen = FindLongestPalindrome(s, i, i);
            if (oddLen > len)
            {
                start = i - oddLen / 2;
                len = oddLen;
            }

            int evenLen = FindLongestPalindrome(s, i, i + 1);
            if (evenLen > len)
            {
                start = i - evenLen / 2 + 1;
                len = evenLen;
            }
        }

        return s.Substring(start, len);
    }

    private int FindLongestPalindrome(string s, int left, int right)
    {
        while (left >= 0 && right < s.Length)
        {
            if (s[left] == s[right])
            {
                left--;
                right++;
            }
            else
            {
                break;
            }

        }

        return right - left - 1;
    }
}

