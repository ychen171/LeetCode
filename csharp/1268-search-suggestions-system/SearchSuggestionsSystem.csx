public class Solution
{
    // Trie + Sorting
    // Time: O(n log n + n * m + k) -> O(n log n + n * m)
    // n is the total number of products
    // m is the max length of product
    // k is the length of searchWord
    // Space: O(n + n * m) -> O(n * m)
    public IList<IList<string>> SuggestedProducts(string[] products, string searchWord)
    {

        var trie = new Trie();
        // sort
        Array.Sort(products);
        // add to Trie
        int n = products.Length;
        for (int i = 0; i < n; i++)
        {
            trie.AddWord(products[i], i);
        }
        // search word
        var result = new List<IList<string>>();
        var curr = trie.Root;
        int k = searchWord.Length;
        int j = 0;
        for (j = 0; j < k; j++)
        {
            char c = searchWord[j];
            if (curr.Children[c - 'a'] == null)
                break;

            var productList = new List<string>();
            curr = curr.Children[c - 'a'];
            var indexList = curr.IndexList;

            for (int i = 0; i < indexList.Count && i < 3; i++)
            {
                productList.Add(products[indexList[i]]);
            }
            result.Add(productList);
        }

        while (j < k)
        {
            result.Add(new List<string>());
            j++;
        }

        return result;
    }
}


public class TrieNode
{
    public TrieNode[] Children { get; set; }
    public string Word { get; set; }
    public List<int> IndexList { get; set; }

    public TrieNode()
    {
        Children = new TrieNode[26];
        Word = null;
        IndexList = new List<int>();
    }
}

public class Trie
{
    public TrieNode Root { get; private set; }
    public Trie()
    {
        Root = new TrieNode();
    }

    public void AddWord(string word, int index)
    {
        TrieNode curr = Root;
        foreach (var c in word)
        {
            if (curr.Children[c - 'a'] == null)
                curr.Children[c - 'a'] = new TrieNode();

            curr = curr.Children[c - 'a'];
            curr.IndexList.Add(index);
        }
        curr.Word = word;
    }
}
