public class Solution
{
    // Trie + String Comparison
    // Time: O(M)
    // Space: O(M)
    // M is the sum of the length of words
    public string LongestWord(string[] words)
    {
        // // sort
        // Array.Sort(words);
        // add words to Trie
        var trie = new Trie();
        foreach (var word in words)
        {
            trie.AddWord(word);
        }
        string ans = string.Empty;
        foreach (var word in words)
        {
            if (trie.CanBuild(word))
            {
                if (word.Length > ans.Length)
                    ans = word;
                else if (word.Length == ans.Length && string.CompareOrdinal(word, ans) < 0)
                    ans = word;
            }
        }

        return ans;
    }
}

public class TrieNode
{
    public TrieNode[] Children { get; set; }
    public string Word { get; set; }

    public TrieNode()
    {
        Children = new TrieNode[26];
        Word = null;
    }
}

public class Trie
{
    public TrieNode Root { get; set; }

    public Trie()
    {
        Root = new TrieNode();
    }

    public void AddWord(string word)
    {
        var curr = Root;
        foreach (var c in word)
        {
            if (curr.Children[c - 'a'] == null)
                curr.Children[c - 'a'] = new TrieNode();
            curr = curr.Children[c - 'a'];
        }
        curr.Word = word;
    }

    public bool CanBuild(string word)
    {
        var curr = Root;
        foreach (var c in word)
        {
            if (curr.Children[c - 'a'] == null)
                return false;
            curr = curr.Children[c - 'a'];
            if (curr.Word == null)
                return false;
        }

        return true;
    }
}


var s = new Solution();
/*
["w","wo","wor","worl","world"]
["a","banana","app","appl","ap","apply","apple"]
*/
var words = new string[] { "a", "banana", "app", "appl", "ap", "apply", "apple" };
var result = s.LongestWord(words);
Console.WriteLine(result);
