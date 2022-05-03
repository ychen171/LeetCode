public class Solution
{
    // Backtracking | DFS
    int[][] directions = new int[][] { new int[] { 1, 0 }, new int[] { 0, 1 }, new int[] { -1, 0 }, new int[] { 0, -1 } };
    public IList<string> FindWords(char[][] board, string[] words)
    {
        // build the Trie
        var trie = new Trie();
        foreach (string word in words)
        {
            trie.AddWord(word);
        }

        // foreach cell, start backtracking
        var result = new List<string>();
        int m = board.Length;
        int n = board[0].Length;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                var visited = new bool[m,n];
                Backtrack(board, trie.Root, i, j, visited, result);
            }
        }

        return result;
    }

    private void Backtrack(char[][] board, TrieNode parent, int row, int col, bool[,] visited, IList<string> result)
    {
        int m = board.Length;
        int n = board[0].Length;
        // base case
        if (parent.Word != null)
        {
            result.Add(new string(parent.Word));
            parent.Word = null;
            // Don't return here. cotinue the recursion
        }
        if (row < 0 || row >= m || col < 0 || col >= n)
            return;
        char letter = board[row][col];
        if (parent.Children[letter - 'a'] == null)
            return;
        if (visited[row, col])
            return;
        
        var currNode = parent.Children[letter - 'a'];

        // recursive case
        visited[row, col] = true;

        foreach (int[] dir in directions)
        {
            int r = row + dir[0];
            int c = col + dir[1];
            Backtrack(board, currNode, r, c, visited, result);
        }

        visited[row, col] = false;
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
            int index = c - 'a';
            if (curr.Children[index] == null)
            {
                curr.Children[index] = new TrieNode();
            }
            curr = curr.Children[index];
        }
        curr.Word = word;
    }
}

public class TrieNode
{
    public TrieNode[] Children;
    public string Word { get; set; }

    public TrieNode()
    {
        Children = new TrieNode[26];
        Word = null;
    }
}


var s = new Solution();
var board = new char[][] { new char[] { 'o', 'a', 'a', 'n' }, new char[] { 'e', 't', 'a', 'e' }, new char[] { 'i', 'h', 'k', 'r' }, new char[] { 'i', 'f', 'l', 'v' } };
var words = new string[] { "oath", "pea", "eat", "rain", "oathi", "oathk", "oathf", "oate", "oathii", "oathfi", "oathfii" };

var result = s.FindWords(board, words);
Console.WriteLine(result);


// TLE
public class Solution1
{
    int[][] directions = new int[][] { new int[] { 1, 0 }, new int[] { 0, 1 }, new int[] { -1, 0 }, new int[] { 0, -1 } };
    public IList<string> FindWords1(char[][] board, string[] words)
    {
        var result = new List<string>();
        int m = board.Length;
        int n = board[0].Length;
        foreach (var word in words)
        {
            bool found = false;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (board[i][j] != word[0])
                        continue;
                    if (DFS(board, word, i, j, 0))
                    {
                        result.Add(word);
                        found = true;
                        break;
                    }
                }
                if (found)
                    break;
            }
        }

        return result;
    }

    private bool DFS(char[][] board, string word, int row, int col, int nextStart)
    {
        // base case
        if (nextStart == word.Length)
            return true;
        int m = board.Length;
        int n = board[0].Length;
        if (row < 0 || row >= m || col < 0 || col >= n || board[row][col] != word[nextStart])
            return false;

        // recursive case
        board[row][col] = '#';
        int count = 0;
        foreach (int[] dir in directions)
        {
            int r = row + dir[0];
            int c = col + dir[1];
            if (DFS(board, word, r, c, nextStart + 1))
                count++;
        }
        board[row][col] = word[nextStart];
        return count > 0;
    }
}