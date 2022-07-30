public class Solution
{
    // Dictionary | Reduce to Single Word in words2
    // Time: O(n)
    // Space: O(n)
    // n is the total number of input letters
    public IList<string> WordSubsets(string[] words1, string[] words2)
    {
        var targetDict = new Dictionary<char, int>();
        foreach (var word in words2)
        {
            var need = new Dictionary<char, int>();
            foreach (var c in word)
            {
                need[c] = need.GetValueOrDefault(c, 0) + 1;
            }

            foreach (var kv in need)
            {
                var c = kv.Key;
                var count = kv.Value;
                targetDict[c] = Math.Max(targetDict.GetValueOrDefault(c, 0), count);
            }
        }

        var result = new List<string>();
        foreach (var word in words1)
        {
            var copyDict = new Dictionary<char, int>(targetDict);
            foreach (var c in word)
            {
                if (copyDict.ContainsKey(c))
                {
                    copyDict[c]--;
                    if (copyDict[c] == 0)
                        copyDict.Remove(c);
                }
            }
            if (copyDict.Count == 0)
                result.Add(word);
        }

        return result;
    }

    // Array
    // Time: O(n)
    // Space: O(n)
    public IList<string> WordSubsets1(string[] words1, string[] words2)
    {
        var result = new List<string>();
        var targetArray = new int[26];
        foreach (var word in words2)
        {
            var countArray = CreateCountArray(word);
            for (int i = 0; i < 26; i++)
            {
                targetArray[i] = Math.Max(targetArray[i], countArray[i]);
            }
        }

        foreach (var word in words1)
        {
            var currArray = CreateCountArray(word);
            bool valid = true;
            for (int i = 0; i < 26; i++)
            {
                if (currArray[i] < targetArray[i])
                {
                    valid = false;
                    break;
                }
            }
            if (valid)
                result.Add(word);
        }

        return result;
    }

    public int[] CreateCountArray(string word)
    {
        var result = new int[26];
        foreach (var c in word)
            result[c - 'a']++;

        return result;
    }
}
