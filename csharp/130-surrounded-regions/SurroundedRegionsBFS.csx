public class Solution
{
    // Time: O(m*n)
    // Space: O(m*n)
    int[][] directions = new int[][] { new int[] { 1, 0 }, new int[] { 0, 1 }, new int[] { -1, 0 }, new int[] { 0, -1 } };
    public void Solve(char[][] board)
    {
        // BFS four edges and flip 'O' into '#'
        // flip 'O' into 'X'
        // Reverse '#' back to 'O'
        int m = board.Length;
        int n = board[0].Length;
        for (int row = 0; row < m; row++)
        {
            if (board[row][0] == 'O')
                BFS(board, row, 0);
            if (board[row][n - 1] == 'O')
                BFS(board, row, n - 1);
        }
        for (int col = 0; col < n; col++)
        {
            if (board[0][col] == 'O')
                BFS(board, 0, col);
            if (board[m - 1][col] == 'O')
                BFS(board, m - 1, col);
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

    public void BFS(char[][] board, int row, int col)
    {
        if (board[row][col] != 'O')
            return;
        int m = board.Length;
        int n = board[0].Length;
        var queue = new Queue<int>();
        int curr = row * n + col;
        board[row][col] = '#';
        queue.Enqueue(curr);
        while (queue.Count != 0)
        {
            curr = queue.Dequeue();
            int r = curr / n;
            int c = curr % n;
            foreach (var dir in directions)
            {
                int nr = r + dir[0];
                int nc = c + dir[1];
                if (nr < 0 || nr >= m || nc < 0 || nc >= n)
                    continue;
                if (board[nr][nc] != 'O')
                    continue;

                board[nr][nc] = '#';
                queue.Enqueue(nr * n + nc);
            }
        }
    }
}
