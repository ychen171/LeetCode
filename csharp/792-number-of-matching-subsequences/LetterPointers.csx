public class Solution
{
    // Time: O(n + k)
    // Space: O(n)
    public int NumMatchingSubseq(string s, string[] words)
    {
        /*
            dcaog,       dog, cat, cop
            c: cat, cop    d: dog        dcaog
            c: cat, cop    o: og         caog
            a: at,         o: op, og     aog
            t: t,          o: op, og     og
            t: t  p: p  g: g             g

            
        */

        int ans = 0;
        var heads = new List<Node>[26];
        for (int i = 0; i < 26; i++)
            heads[i] = new List<Node>();

        foreach (var word in words)
            heads[word[0] - 'a'].Add(new Node(word, 0));

        foreach (var c in s)
        {
            var oldBucket = heads[c - 'a'];
            foreach (var node in oldBucket.ToList())
            {
                node.Index++;
                if (node.Index == node.Word.Length)
                    ans++;
                else
                    heads[node.Word[node.Index] - 'a'].Add(node);
            }
        }
        return ans;
    }
}

public class Node
{
    public string Word { get; set; }
    public int Index { get; set; }
    public Node(string word, int index)
    {
        Word = word;
        Index = index;
    }
}

var sln = new Solution();
var result = sln.NumMatchingSubseq("dcaog", new string[] { "cat", "cop", "dog" });
Console.WriteLine(result);
