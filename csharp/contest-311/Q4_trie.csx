public class Solution
{
    // Trie
    public int[] SumPrefixScores(string[] words)
    {
        int n = words.Length;
        var result = new int[n];
        var trie = new Trie();
        for (int i = 0; i < n; i++)
        {
            var word = words[i];
            trie.AddWord(word);
        }
        for (int i = 0; i < n; i++)
        {
            var word = words[i];
            var sum = trie.SumOfScores(word);
            result[i] = sum;
        }

        return result;
    }
}

public class TrieNode
{
    public int Score { get; set; }
    public TrieNode[] Children { get; set; }
    public string Word { get; set; }
    public TrieNode()
    {
        Score = 0;
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
            {
                curr.Children[c - 'a'] = new TrieNode();
            }
            curr = curr.Children[c - 'a'];
            curr.Score++;
        }
        curr.Word = word;
    }

    public int SumOfScores(string word)
    {
        int sum = 0;
        var curr = Root;
        foreach (var c in word)
        {
            curr = curr.Children[c - 'a'];
            sum += curr.Score;
        }

        return sum;
    }
}
