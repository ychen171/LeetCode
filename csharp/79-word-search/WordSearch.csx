public class Solution
{
    // Recursion | DFS | Backtracking
    // Time: O(M * N * 3^L)
    // Space: O(L)
    public bool Exist(char[][] board, string word)
    {
        var m = board.Length;
        var n = board[0].Length;

        for (int row = 0; row < m; row++)
        {
            for (int col = 0; col < n; col++)
            {
                if (Helper(board, row, col, word, 0))
                    return true;
            }
        }
        return false;
    }

    private bool Helper(char[][] board, int row, int col, string word, int index)
    {
        var m = board.Length;
        var n = board[0].Length;
        // base case
        if (index >= word.Length)
            return true;
        if (row < 0 || col < 0 || row >= m || col >= n || board[row][col] != word[index])
            return false;

        // recursive case
        bool result = false;
        board[row][col] = '#';
        result = Helper(board, row - 1, col, word, index + 1);
        if (result)
        {
            board[row][col] = word[index];
            return result;
        }
        result = Helper(board, row + 1, col, word, index + 1);
        if (result)
        {
            board[row][col] = word[index];
            return result;
        }
        result = Helper(board, row, col - 1, word, index + 1);
        if (result)
        {
            board[row][col] = word[index];
            return result;
        }
        result = Helper(board, row, col + 1, word, index + 1);
        if (result)
        {
            board[row][col] = word[index];
            return result;
        }
        board[row][col] = word[index];
        return result;
    }
}
