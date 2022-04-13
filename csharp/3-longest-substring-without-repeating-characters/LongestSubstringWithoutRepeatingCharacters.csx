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
        // Sliding Window
        // a    b   c   a   b   c   b   b
        // ij
        // i    j
        // i        j
        // i            j
        //      i       j
        
        // a    b   b   a
        // ij                   1
        // i    j               2
        // i        j
        //          ij          1
        //          i   j       2
        
        var charFirstIndexDict = new Dictionary<char, int>();
        int i = 0;
        int j = 0;
        int n = s.Length;
        int ans = 0;
        while (j < n)
        {
            char curr = s[j];
            if (charFirstIndexDict.ContainsKey(curr) && charFirstIndexDict[curr] >= i)
            {
                i = charFirstIndexDict[curr] + 1;
            }
            charFirstIndexDict[curr] = j;
            // Console.WriteLine($"{i}, {j}");
            ans = Math.Max(ans, j - i + 1);
            
            j++;
        }
        
        return ans;
    }
}

var s = new Solution();
Console.WriteLine(s.LengthOfLongestSubstring1("au"));
Console.WriteLine(s.LengthOfLongestSubstring1("aab"));



