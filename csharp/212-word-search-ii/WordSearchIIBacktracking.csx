public class Solution 
{
    // Backtracking
    // Time: O(m * n * 3^(L - 1))
    // Space: O(L)
    int[][] directions = new int[][]{new int[]{1, 0}, new int[]{0, 1}, new int[]{-1, 0}, new int[]{0, -1}};
    int maxLen;
    int m;
    int n;
    public IList<string> FindWords(char[][] board, string[] words) 
    {
        this.m = board.Length;
        this.n = board[0].Length;
        var wordSet = new HashSet<string>();
        foreach (var word in words)
        {
            wordSet.Add(word);
            maxLen = Math.Max(maxLen, word.Length);
        }
        var result = new List<string>();
        for (int r = 0; r < m && wordSet.Count != 0; r++)
        {
            for (int c = 0; c < n && wordSet.Count != 0; c++)
            {
                Backtrack(board, wordSet, new HashSet<int>(), new StringBuilder(), r, c, result);
            }
        }
        return result;
    }
    
    private void Backtrack(char[][] board, HashSet<string> wordSet, HashSet<int> visited, StringBuilder onPath, int r, int c, IList<string> result)
    {
        // base case
        if (r < 0 || r >= m || c < 0 || c >= n) // invalid
            return;
        if (onPath.Length == maxLen)
            return;
        var key = r * n + c;
        if (visited.Contains(key)) // visited
            return;
        
        // recursive case
        visited.Add(key);
        onPath.Append(board[r][c]);
        var currWord = onPath.ToString();
        if (wordSet.Contains(currWord))
        {
            wordSet.Remove(currWord);
            result.Add(currWord);
        }
        foreach (var dir in directions)
        {
            int nr = r + dir[0];
            int nc = c + dir[1];
            Backtrack(board, wordSet, visited, onPath, nr, nc, result);
        }
        visited.Remove(key);
        onPath.Remove(onPath.Length - 1, 1);
    }
}