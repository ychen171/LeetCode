public class Solution
{
    // Time: O(n^3)
    // Space: O(n)
    public IList<string> FindAllConcatenatedWordsInADict(string[] words)
    {
        var result = new List<string>();
        var memo = new Dictionary<string, List<List<string>>>();
        var wordSet = words.ToHashSet();
        foreach (var s in words)
        {
            Helper(s, wordSet, memo);
            if (memo[s].Count == 0)
                continue;
            foreach (var list in memo[s])
            {
                if (list.Count > 1)
                {
                    result.Add(s);
                    break;
                }
            }
        }
        return result;
    }

    public List<List<string>> Helper(string s, HashSet<string> wordSet, Dictionary<string, List<List<string>>> memo)
    {
        if (s.Length == 0)
        {
            var words = new List<string>();
            memo[s] = new List<List<string>> { words };
            return memo[s];
        }

        if (memo.ContainsKey(s))
            return memo[s];
        else
            memo[s] = new List<List<string>>();

        for (int i = 0; i < s.Length; i++)
        {
            var prefix = s.Substring(0, i + 1);
            if (!wordSet.Contains(prefix))
                continue;
            var subS = s.Substring(i + 1);
            var subResult = Helper(subS, wordSet, memo);
            foreach (var subList in subResult)
            {
                var list = new List<string>(subList);
                list.Add(prefix);
                memo[s].Add(list);
            }
        }

        return memo[s];
    }
}

var sln = new Solution();
var words = new string[] { "a", "b", "ab", "abc" };
var result = sln.FindAllConcatenatedWordsInADict(words);
Console.WriteLine(result);

