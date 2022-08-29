public class Solution
{
    // TLE
    Dictionary<string, bool> memo;
    public IList<string> FindAllConcatenatedWordsInADict(string[] words)
    {
        var result = new List<string>();
        memo = new Dictionary<string, bool>();
        foreach (var s in words)
        {
            var wordSet = words.ToHashSet();
            wordSet.Remove(s);
            var selectedWords = new List<string>();
            if (Helper(s, wordSet, selectedWords))
                result.Add(s);
        }
        return result;
    }

    public bool Helper(string s, HashSet<string> wordSet, List<string> usedWords)
    {
        if (memo.ContainsKey(s))
            return memo[s];
        // base case
        if (s.Length == 0)
        {
            if (usedWords.Count > 1)
                return true;
            else
                return false;
        }

        // recursive case
        bool ans = false;
        foreach (var word in wordSet)
        {
            if (s.StartsWith(word))
            {
                usedWords.Add(word);
                var newS = s.Substring(word.Length);
                if (wordSet.Contains(newS) || Helper(s.Substring(word.Length), wordSet, usedWords))
                {
                    ans = true;
                    break;
                }
                usedWords.RemoveAt(usedWords.Count - 1);
            }
        }
        memo[s] = ans;
        return ans;
    }
}
