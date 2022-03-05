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
}

