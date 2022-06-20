public class Solution
{
    // Trie + Reverse String + DFS
    // Time: O(n*m)
    // Space: O(n*m)
    // n is the number of words
    // m is the max length of word
    public int MinimumLengthEncoding(string[] words)
    {
        // reverse each word and add to trie
        var trie = new Trie();
        foreach (var word in words)
        {
            var reversedWord = new string(word.Reverse().ToArray());
            trie.Add(reversedWord);
        }

        // DFS to sum up every count at every leaf/end
        return DFS(trie.Root);
    }

    public int DFS(TrieNode node)
    {
        // base case
        if (node == null)
            return 0;
        if (node.Count == 0) // no child, curr node is the end/leaf
            return node.Word.Length + 1;

        // recursive case
        int ans = 0;
        foreach (var child in node.Children)
        {
            ans += DFS(child);
        }

        return ans;
    }
}


public class TrieNode
{
    public TrieNode[] Children { get; set; }
    public int Count { get; set; } // child count
    public string Word { get; set; }

    public TrieNode()
    {
        Children = new TrieNode[26];
        Count = 0;
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

    public void Add(string word)
    {
        var curr = Root;
        foreach (var c in word)
        {
            if (curr.Children[c - 'a'] == null)
            {
                curr.Children[c - 'a'] = new TrieNode();
                curr.Count++;
            }
            curr = curr.Children[c - 'a'];
        }
        curr.Word = word;
    }
}


var s = new Solution();
var words = new string[] { "time", "me", "bell" };
var result = s.MinimumLengthEncoding(words);
Console.WriteLine(result);
