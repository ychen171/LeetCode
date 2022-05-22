public class Solution
{
    // Recursion | DFS | Backtracking
    // Time: O(M * N * 3^L)
    // Space: O(L)
    int[][] directions = new int[][] { new int[] { 1, 0 }, new int[] { 0, 1 }, new int[] { -1, 0 }, new int[] { 0, -1 } };
    public bool Exist(char[][] board, string word)
    {
        var m = board.Length;
        var n = board[0].Length;

        for (int row = 0; row < m; row++)
        {
            for (int col = 0; col < n; col++)
            {
                if (Backtrack(board, row, col, word, 0))
                    return true;
            }
        }
        return false;
    }

    private bool Backtrack(char[][] board, int row, int col, string word, int index)
    {
        var m = board.Length;
        var n = board[0].Length;
        // base case
        if (index == word.Length)
            return true;
        if (row < 0 || col < 0 || row >= m || col >= n || board[row][col] != word[index])
            return false;

        // recursive case
        board[row][col] = '#'; // mark as visited
        bool result = false;
        foreach (var dir in directions)
        {
            int r = row + dir[0];
            int c = col + dir[1];
            if (Backtrack(board, r, c, word, index + 1))
            {
                result = true;
                break;
            }
        }

        board[row][col] = word[index];
        return result;
    }
}
