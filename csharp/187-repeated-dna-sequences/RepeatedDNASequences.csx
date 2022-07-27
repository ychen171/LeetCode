public class Solution
{
    // Sliding Window
    // Time: O(n)
    // Space: O(n)
    public IList<string> FindRepeatedDnaSequences(string s)
    {
        int n = s.Length;
        var result = new List<string>();
        if (n < 10)
            return result;

        var sb = new StringBuilder();
        var dict = new Dictionary<string, int>();
        int left = 0;
        int right = 0;
        // [left, right)
        while (right < n)
        {
            char c = s[right];
            right++;
            // update data in window
            sb.Append(c);

            if (sb.Length == 10)
            {
                // update dict
                var candidate = sb.ToString();
                dict[candidate] = dict.GetValueOrDefault(candidate, 0) + 1;

                char d = s[left];
                left++;
                // update data in window
                sb.Remove(0, 1);
            }
        }

        foreach (var key in dict.Keys)
        {
            if (dict[key] > 1)
                result.Add(key);
        }

        return result;
    }

    // Rabin Karp | Rolling Hash
    // Time: O(n - 10)
    // Space: O(n - 10)
    public IList<string> FindRepeatedDnaSequences1(string s)
    {
        int n = s.Length;
        if (n < 10)
            return new List<string>();
        
        var charToInt = new Dictionary<char, int>()
        {
            ['A'] = 0, ['C'] = 1, ['G'] = 2, ['T'] = 3,
        };
        var nums = new int[n];
        for (int i = 0; i < n; i++)
            nums[i] = charToInt[s[i]];

        int bse = 4;
        int len = 10;
        var seen = new HashSet<int>();
        var result = new HashSet<string>();
        int left = 0, right = 0;
        int windowHash = 0;
        while (right < n)
        {
            windowHash = bse * windowHash + nums[right];
            right++;

            if (right - left == len)
            {
                if (!seen.Add(windowHash))
                    result.Add(s.Substring(left, len));
                
                windowHash -= (int)Math.Pow(bse, len - 1) * nums[left];
                left++;
            }
        }

        return result.ToList();
    }
}
