public class Solution
{
    // Sliding Window
    // Time: O(n*a*b)
    // Space: O(a+b)
    // n as the length of s, a as the length of words, b as the length of each word
    int wordLen;
    int wordCount;
    int totalLen;
    public IList<int> FindSubstring(string s, string[] words)
    {
        int n = s.Length;
        wordCount = words.Length;
        wordLen = words[0].Length;
        totalLen = wordCount * wordLen;
        // edge case
        var result = new List<int>();

        if (totalLen > n)
            return result;

        var need = new Dictionary<string, int>();
        foreach (var word in words)
            need[word] = need.GetValueOrDefault(word, 0) + 1;
        var window = new StringBuilder();
        int left = 0, right = 0;
        // [left, right)
        while (right < n)
        {
            char c = s[right];
            right++;
            // update window
            window.Append(c);

            if (right - left == totalLen)
            {
                // check if window contains all words
                if (AreConcatenated(window.ToString(), new Dictionary<string, int>(need)))
                    result.Add(left);

                char d = s[left];
                left++;
                // update window
                window.Remove(0, 1);
            }
        }

        return result;
    }

    private bool AreConcatenated(string s, Dictionary<string, int> need)
    {
        for (int i = 0; i < totalLen; i += wordLen)
        {
            var word = s.Substring(i, wordLen);
            if (need.ContainsKey(word))
            {
                need[word]--;
                if (need[word] == 0)
                    need.Remove(word);
            }
        }

        return need.Count == 0;
    }
}

var sln = new Solution();
var s = "barfoothefoobarman";
var words = new string[] { "foo", "bar" };
var result = sln.FindSubstring(s, words);
Console.WriteLine(result);

