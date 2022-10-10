public class Solution
{
    // Greedy 
    // Time: O(n)
    // Space: O(n)
    public string BreakPalindrome(string palindrome)
    {
        int n = palindrome.Length;
        // edge case
        if (n == 1) return string.Empty;

        var cs = palindrome.ToCharArray();
        for (int i = 0; i < n / 2; i++)
        {
            if (cs[i] != 'a')
            {
                cs[i] = 'a';
                return new string(cs);
            }
        }
        cs[n - 1] = 'b';
        return new string(cs);
    }
}
