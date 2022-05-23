public class Trie
{
    TrieNode root;
    public Trie()
    {
        root = new TrieNode();
    }

    // Time: O(m)
    // Space: O(m)
    public void Insert(string word)
    {
        TrieNode curr = root;
        foreach (var c in word)
        {
            if (curr.Children[c - 'a'] == null)
                curr.Children[c - 'a'] = new TrieNode();
            curr = curr.Children[c - 'a'];
        }
        curr.Word = word;
    }

    // Time: O(m)
    // Space: O(1)
    public bool Search(string word)
    {
        TrieNode curr = root;
        foreach (var c in word)
        {
            if (curr.Children[c - 'a'] == null)
                return false;

            curr = curr.Children[c - 'a'];
        }
        return curr.Word != null;
    }

    // Time: O(m)
    // Space: O(1)
    public bool StartsWith(string prefix)
    {
        TrieNode curr = root;
        foreach (var c in prefix)
        {
            if (curr.Children[c - 'a'] == null)
                return false;

            curr = curr.Children[c - 'a'];
        }

        return true;
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

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */
