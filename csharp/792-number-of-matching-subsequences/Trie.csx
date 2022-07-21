public class Solution
{
    public int NumMatchingSubseq(string s, string[] words)
    {
        int n = s.Length;
        int k = words.Length;
        var trie = new Trie();
        foreach (var word in words)
            trie.Add(word);

        return trie.Search(s);
    }
}

public class TrieNode
{
    public Dictionary<char, TrieNode> Children { get; set; }
    public string Word { get; set; }
    public int WordCount { get; set; }
    public int Index { get; set; }
    public TrieNode()
    {
        Children = new Dictionary<char, TrieNode>();
    }
}

public class Trie
{
    public TrieNode Root { get; set; }
    public Trie()
    {
        Root = new TrieNode();
    }

    public void Add(string word)
    {
        TrieNode curr = Root;
        foreach (var c in word)
        {
            if (!curr.Children.ContainsKey(c))
                curr.Children[c] = new TrieNode();

            curr = curr.Children[c];
        }
        if (curr.Word == null)
            curr.Word = word;
        curr.WordCount++;
    }

    public int Search(string s)
    {
        int ans = 0;
        TrieNode curr = Root;
        foreach (var c in s)
        {
            if (!curr.Children.ContainsKey(c))
                continue;

            curr = curr.Children[c];
            if (curr.Word != null)
                ans += curr.WordCount;
        }

        return ans;
    }
}

var sln = new Solution();
var s = "abcde";
var words = new string[] { "a", "bb", "acd", "ace" };
/*
"qlhxagxdqh"
["qlhxagxdq","qlhxagxdq","lhyiftwtut","yfzwraahab"]
*/
var result = sln.NumMatchingSubseq(s, words);
Console.WriteLine(result);
