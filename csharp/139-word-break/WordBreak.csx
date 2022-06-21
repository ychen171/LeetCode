public class Solution
{
    // Recursion + Memoization
    // Time: O(n^3)
    // Space: O(n)
    public bool WordBreak(string s, IList<string> wordDict)
    {
        HashSet<string> wordSet = wordDict.ToHashSet<string>();
        int[] memo = new int[s.Length + 1];
        return Helper(s, wordSet, 0, memo);
    }

    private bool Helper(string s, HashSet<string> wordSet, int start, int[] memo)
    {
        if (memo[start] != 0)
            return memo[start] == 1;
        int n = s.Length;
        if (start == n) // reach the end
            return true;

        bool result = false;
        for (int end = start; end < n; end++)
        {
            if (!wordSet.Contains(s.Substring(start, end - start + 1)))
                continue;
            if (Helper(s, wordSet, end + 1, memo))
            {
                result = true;
                break;
            }
        }
        memo[start] = result ? 1 : -1;
        return result;
    }
}

public class Trie
{
    public TrieNode root;
    public Trie()
    {
        root = new TrieNode();
    }

    public void AddWord(string word)
    {
        TrieNode curr = root;
        foreach (var c in word)
        {
            if (curr.children[c - 'a'] == null)
            {
                curr.children[c - 'a'] = new TrieNode();
            }
            curr = curr.children[c - 'a'];
        }
        curr.word = word;
    }
}

public class TrieNode
{
    public TrieNode[] children;
    public string word;
    public TrieNode()
    {
        children = new TrieNode[26];
        word = null;
    }
}

/*
"aaaaaaa"
["aaaa","aaa"]
*/

var s = new Solution();
var result = s.WordBreak("aaaaaaa", new List<string>() { "aaaa", "aaa" });
Console.WriteLine(result);