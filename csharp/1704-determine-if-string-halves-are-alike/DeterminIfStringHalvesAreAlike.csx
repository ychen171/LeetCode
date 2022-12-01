public class Solution
{
    public bool HalvesAreAlike(string s)
    {
        int n = s.Length;
        return CountVowel(s, 0, n / 2) == CountVowel(s, n / 2, n);
    }

    // [lo, hi)
    private int CountVowel(string s, int lo, int hi)
    {
        string vowels = "aeiouAEIOU";
        int count = 0;
        for (int i = lo; i < hi; i++)
        {
            if (vowels.IndexOf(s[i]) != -1)
                count++;
        }
        return count;
    }
}
// string
// Time: O(n)
// Space: O(1)
