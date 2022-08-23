public class Solution
{
    // Two Pointers
    // Time: O(n * k)
    // Space: O(1)
    public int NumMatchingSubseq(string s, string[] words)
    {
        int count = 0;
        foreach (var word in words)
        {
            if (IsSubsequence(s, word))
                count++;
        }

        return count;
    }

    public bool IsSubsequence(string s, string word)
    {
        if (s.Length < word.Length)
            return false;

        int i = 0;
        int j = 0;
        while (i < s.Length && j < word.Length)
        {
            if (s[i] == word[j])
            {
                i++;
                j++;
            }
            else
            {
                i++;
            }
        }

        return j == word.Length;
    }
}
