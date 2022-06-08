public class Solution
{
    // Two Pointers
    // Time: O(n)
    // Space: O(1)
    public int RemovePalindromeSub(string s)
    {
        // ans = 0 or 1 or 2
        // ababa
        // bb      1
        // ""      2

        // abb
        // bb      1
        // ""      2

        // baabb
        // bbb     1
        // ""      2

        // edge case
        int n = s.Length;
        if (n == 1)
            return 1;

        // if the whole string is palindrome, return 1
        // 2

        int left = 0;
        int right = s.Length - 1;
        while (left < right)
        {
            if (s[left] == s[right])
            {
                left++;
                right--;
            }
            else
            {
                break;
            }
        }

        if (left < right) // s is not palindrome
            return 2;
        else
            return 1; 
    }
}
