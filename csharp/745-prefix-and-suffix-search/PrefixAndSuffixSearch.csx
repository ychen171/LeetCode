// Trie + HashSet
// Time: O(N*K + Q*(N + K))   -- TLE
// Space: O(N*K)
// N is the number of words
// K is the maximum length of a word
// Q is the number of queries
public class WordFilter
{
    private Trie prefixTree;
    private Trie suffixTree;
    public WordFilter(string[] words)
    {
        prefixTree = new Trie();
        suffixTree = new Trie();
        for (int i = 0; i < words.Length; i++)
        {
            var word = words[i];
            prefixTree.AddWord(word, i);
            suffixTree.AddWord(new string(word.Reverse().ToArray()), i);
        }
    }

    public int F(string prefix, string suffix)
    {
        var currNode = prefixTree.Root;
        bool found = true;
        foreach (var c in prefix)
        {
            if (currNode.Children[c - 'a'] == null)
            {
                found = false;
                break;
            }
            currNode = currNode.Children[c - 'a'];
        }

        if (!found)
            return -1;
        HashSet<int> prefixIndexSet = currNode.IndexSet;

        currNode = suffixTree.Root;
        found = true;
        suffix = new string(suffix.Reverse().ToArray());
        foreach (var c in suffix)
        {
            if (currNode.Children[c - 'a'] == null)
            {
                found = false;
                break;
            }
            currNode = currNode.Children[c - 'a'];
        }

        if (!found)
            return -1;
        HashSet<int> suffixIndexSet = currNode.IndexSet;

        HashSet<int> commonIndexSet = new HashSet<int>();
        foreach (var index in prefixIndexSet)
        {
            if (suffixIndexSet.Contains(index))
                commonIndexSet.Add(index);
        }

        return commonIndexSet.Count == 0 ? -1 : commonIndexSet.Max();
    }
}

public class TrieNode
{
    public TrieNode[] Children { get; set; }
    public string Word { get; set; }
    public HashSet<int> IndexSet { get; set; }

    public TrieNode()
    {
        Children = new TrieNode[26];
        Word = null;
        IndexSet = new HashSet<int>();
    }
}

public class Trie
{
    public TrieNode Root { get; set; }
    public Trie()
    {
        Root = new TrieNode();
    }

    public void AddWord(string word, int index)
    {
        var currNode = Root;
        foreach (var c in word)
        {
            if (currNode.Children[c - 'a'] == null)
                currNode.Children[c - 'a'] = new TrieNode();

            currNode = currNode.Children[c - 'a'];
            currNode.IndexSet.Add(index);
        }
        currNode.Word = word;
    }
}

/**
 * Your WordFilter object will be instantiated and called as such:
 * WordFilter obj = new WordFilter(words);
 * int param_1 = obj.F(prefix,suffix);
 */

var words = new string[] { "apple" };
var wf = new WordFilter(words);
var result = wf.F("a", "e");
Console.WriteLine(result);
