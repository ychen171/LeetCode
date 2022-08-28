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


