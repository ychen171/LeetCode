public class Solution
{
    // Brute force
    // Time: O(n^2)
    // Space: O(n)
    public string ShortestPalindrome(string s)
    {
        // find the longest palindrome substring in s, starting at 0 index
        // len = the length of the longest palindrome
        // Reverse the remaining substring and add it to the beginning
        int n = s.Length;
        if (n == 0) return s;
        int len = n;

        while (len >= 0)
        {
            if (IsPalindrome(s, len))
                 break;
            len--;
        }


        string toReverse = s.Substring(len);
        string toAdd = new string(toReverse.Reverse().ToArray());
        return toAdd + s;
    }

    private bool IsPalindrome(string s, int len)
    {
        int left = 0;
        int right = len - 1;
        while (left < right)
        {
            if (s[left] != s[right])
                return false;
            left++;
            right--;
        }

        return true;
    }
}
