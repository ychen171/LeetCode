public class Solution
{
    // TLE
    // Backtracking | Brute force
    // Time: O(n * k * 2^n)
    // Space: O(n + k)
    int ans = 0;
    public int NumMatchingSubseq(string s, string[] words)
    {
        var wordDict = new Dictionary<string, int>();
        foreach (var word in words)
            wordDict[word] = wordDict.GetValueOrDefault(word, 0) + 1;
        var sb = new StringBuilder(s);
        Backtrack(sb, wordDict);
        return ans;
    }

    public void Backtrack(StringBuilder sb, Dictionary<string, int> wordDict)
    {
        // base case
        if (sb.Length == 0)
            return;
        if (wordDict.Count == 0)
            return;

        string currWord = sb.ToString();
        foreach (var word in wordDict.Keys)
        {
            if (currWord == word)
            {
                ans += wordDict[word];
                wordDict.Remove(word);
            }
        }

        // recursive case
        int n = currWord.Length;
        for (int i = 0; i < n; i++)
        {
            char c = sb[i];
            sb.Remove(i, 1);
            Backtrack(sb, wordDict);
            sb.Insert(i, c);
        }
    }
}

var sln = new Solution();
var s = "qlhxagxdqh";
var words = new string[] { "qlhxagxdq", "qlhxagxdq", "lhyiftwtut", "yfzwraahab" };
/*
"qlhxagxdqh"
["qlhxagxdq","qlhxagxdq","lhyiftwtut","yfzwraahab"]
*/
var result = sln.NumMatchingSubseq(s, words);
Console.WriteLine(result);
