public class Solution
{
    // Brute force
    // Time: O((m * n)
    // Space: O(1)
    public int StrStr(string haystack, string needle)
    {
        if (string.IsNullOrEmpty(needle)) return 0;
        int n = needle.Length;

        for (int i = 0; i <= haystack.Length - n; i++)
        {
            var subStr = haystack.Substring(i, n);
            if (subStr == needle)
                return i;
        }

        return -1;
    }
}
