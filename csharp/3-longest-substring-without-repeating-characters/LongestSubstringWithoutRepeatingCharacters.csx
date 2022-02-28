public class Solution
{
    // Brute force with HashSet
    // Time: O(n^2)
    // Space: O(n)
    public int LengthOfLongestSubstring(string s)
    {
        if (s.Length < 2) return s.Length;
        int longest = 0;
        int start = 0;
        int end = 0;
        for (start = 0; start < s.Length; start++)
        {
            var set = new HashSet<char>();
            for (end = start; end < s.Length; end++)
            {
                if (set.Contains(s[end]))
                {
                    longest = Math.Max(end - start, longest);
                    break;
                }
                set.Add(s[end]);
                longest = Math.Max(end - start + 1, longest);
            }

        }

        return longest;
    }

    // HashTable/Dictionary | Sliding Window
    // Time: O(n)
    // Space: O(n)
    public int LengthOfLongestSubstring1(string s)
    {
        if (s.Length < 2) return s.Length;
        int longest = 0;
        int start = 0;
        int end = 0;
        var startIndexMap = new Dictionary<char, int>();

        for (end = start; end < s.Length; end++)
        {
            if (startIndexMap.ContainsKey(s[end]))
                start = Math.Max(startIndexMap[s[end]], start);
            
            startIndexMap[s[end]] = end + 1;
            longest = Math.Max(end - start + 1, longest);
        }

        return longest;
    }
}

var s = new Solution();
Console.WriteLine(s.LengthOfLongestSubstring1("au"));
Console.WriteLine(s.LengthOfLongestSubstring1("aab"));



