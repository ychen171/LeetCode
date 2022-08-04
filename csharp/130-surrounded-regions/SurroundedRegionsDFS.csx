public class Solution
{
    // Time: O(m*n)
    // Space: O(m*n)
    int[][] directions = new int[][] { new int[] { 1, 0 }, new int[] { 0, 1 }, new int[] { -1, 0 }, new int[] { 0, -1 } };
    public void Solve(char[][] board)
    {
        // DFS four edges and flip 'O' into '#'
        // flip 'O' into 'X'
        // Reverse '#' back to 'O'
        int m = board.Length;
        int n = board[0].Length;
        for (int row = 0; row < m; row++)
        {
            DFS(board, row, 0, 'O', '#');
            DFS(board, row, n - 1, 'O', '#');
        }
        for (int col = 0; col < n; col++)
        {
            DFS(board, 0, col, 'O', '#');
            DFS(board, m - 1, col, 'O', '#');
        }

        for (int row = 0; row < m; row++)
        {
            for (int col = 0; col < n; col++)
            {
                if (board[row][col] == 'O')
                    board[row][col] = 'X';

                if (board[row][col] == '#')
                    board[row][col] = 'O';
            }
        }
    }

    private void DFS(char[][] board, int row, int col, char from, char to)
    {
        int m = board.Length;
        int n = board[0].Length;
        // base case
        if (row < 0 || row >= m || col < 0 || col >= n)
            return;
        if (board[row][col] != from)
            return;

        // recursive case
        board[row][col] = to;
        foreach (var dir in directions)
        {
            int r = row + dir[0];
            int c = col + dir[1];
            DFS(board, r, c, from, to);
        }
    }
}
