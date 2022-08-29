public class Solution
{
    // Backtracking
    // Time: O(2^n)
    // Space: O(2^n)
    // n == s.Length
    public IList<string> WordBreak(string s, IList<string> wordDict)
    {
        var wordSet = wordDict.ToHashSet();
        var sb = new StringBuilder();
        var result = new List<string>();
        Backtrack(s, wordSet, sb, result);
        for (int i = 0; i < result.Count; i++)
        {
            var str = result[i];
            result[i] = str.Substring(0, str.Length - 1);
        }

        return result;
    }

    public void Backtrack(string s, HashSet<string> wordSet, StringBuilder sb, IList<string> result)
    {
        // base case
        if (s.Length == 0)
        {
            result.Add(sb.ToString());
            return;
        }

        // recursive case
        foreach (var word in wordSet)
        {
            if (s.StartsWith(word))
            {
                sb.Append(word).Append(' ');
                Backtrack(s.Substring(word.Length), wordSet, sb, result);
                sb.Remove(sb.Length - word.Length - 1, word.Length + 1);
            }
        }
    }

    // DP | Top-down | Memoization | Recursion
    // Time: O(n^3)
    // Space: O(n)
    // n == s.Length
    public IList<string> WordBreak1(string s, IList<string> wordDict)
    {
        var wordSet = wordDict.ToHashSet();
        var memo = new Dictionary<string, List<List<string>>>();
        Helper(s, wordSet, memo);
        // create result strings
        var result = new List<string>();
        foreach (var list in memo[s])
        {
            list.Reverse();
            var sb = new StringBuilder();
            foreach (var word in list)
                sb.Append(word).Append(' ');
            sb.Remove(sb.Length - 1, 1);
            result.Add(sb.ToString());
        }

        return result;
    }

    private List<List<string>> Helper(string s, HashSet<string> wordSet, Dictionary<string, List<List<string>>> memo)
    {
        if (s.Length == 0)
        {
            var words = new List<string>();
            memo[""] = new List<List<string>> { words };
            return memo[""];
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
                list.Add(prefix); // list of words in reversed order
                memo[s].Add(list);
            }
        }
        return memo[s];
    }
}

var sln = new Solution();
/*
"catsanddog"
["cat","cats","and","sand","dog"]
*/
var s = "catsanddog";
var wordDict = new List<string> { "cat", "cats", "and", "sand", "dog" };
var result = sln.WordBreak(s, wordDict);
Console.WriteLine(result);


