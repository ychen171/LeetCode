public class Solution
{
    // Dictionary
    // Time: O(m*n)
    // Space: O(n)
    public IList<string> FindAndReplacePattern(string[] words, string pattern)
    {
        int n = pattern.Length;
        var result = new List<string>();
        foreach (var word in words)
        {
            if (word.Length != n)
                continue;

            var dict1 = new Dictionary<char, char>(); // a -> b
            var dict2 = new Dictionary<char, char>(); // b -> a
            // 1 to 1 mapping
            int i = 0;
            while (i < n)
            {
                var a = word[i];
                var b = pattern[i];
                if (dict1.ContainsKey(a) && dict2.ContainsKey(b))
                {
                    if (!(dict1[a] == b && dict2[b] == a))
                        break;
                }
                else if (!dict1.ContainsKey(a) && !dict2.ContainsKey(b))
                {
                    dict1[a] = b;
                    dict2[b] = a;
                }
                else
                {
                    break;
                }
                i++;
            }
            if (i == n)
                result.Add(word);
        }

        return result;
    }
}
