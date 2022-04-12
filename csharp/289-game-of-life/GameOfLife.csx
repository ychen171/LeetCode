public class Solution
{
    // Copy board and iterate through cells
    // We don't use DFS because every cell needs to be visited multiple times
    int[][] directions = new int[][]
    {
        new int[]{1, 0},    // down
        new int[]{1, 1},    // down right
        new int[]{0, 1},    // right
        new int[]{-1, 1},   // up right
        new int[]{-1, 0},   // up
        new int[]{-1, -1},  // up left
        new int[]{0, -1},   // left
        new int[]{1, -1},   // down left
    };

    // Time: O(m * n)
    // Space: O(m * n)
    public void GameOfLife(int[][] board)
    {
        int m = board.Length;
        int n = board[0].Length;
        int[][] original = new int[m][];
        for (int i = 0; i < m; i++)
        {
            original[i] = new int[n];
            for (int j = 0; j < n; j++)
            {
                original[i][j] = board[i][j];
            }
        }

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                int count = CountNeighbors(original, i, j);
                // neighbors < 2,  0
                // neighbors == 2, unchanged
                // neighbors == 3, 1
                // neighbors > 3, 0
                if (count < 2)
                {
                    board[i][j] = 0;
                }
                else if (count == 2)
                {
                    board[i][j] = original[i][j];
                }
                else if (count == 3)
                {
                    board[i][j] = 1;
                }
                else
                {
                    board[i][j] = 0;
                }
            }
        }
    }

    private int CountNeighbors(int[][] board, int row, int col)
    {
        int m = board.Length;
        int n = board[0].Length;

        int count = 0;
        foreach (var dir in directions)
        {
            int r = row + dir[0];
            int c = col + dir[1];
            if (r < 0 || r >= m || c < 0 || c >= n)
                continue;
            if (board[r][c] == 1)
                count++;
        }

        return count;
    }

    // In-place
    // Time: O(m * n)
    // Space: O(1)
    public void GameOfLife1(int[][] board)
    {
        int m = board.Length;
        int n = board[0].Length;

        // iterate through cells and mark status
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                // neighbors < 2,  0
                // neighbors == 2, unchanged
                // neighbors == 3, 1
                // neighbors > 3, 0

                // live cell, neighbors < 2, live -> dead, -1
                // dead cell, neighbors < 2, unchanged
                // neighboars == 2, unchanged
                // dead cell, neighbors == 3, dead -> live, 2
                // live cell, neighbors == 3, unchanged
                // dead cell, neighbors > 3, unchanged
                // live cell, neighbors > 3, live -> dead, -1
                int count = CountNeighbors1(board, i, j);
                if (board[i][j] == 1)
                {
                    if (count < 2 || count > 3) // changed, live -> dead
                        board[i][j] = -1;
                }
                else
                {
                    if (count == 3) // changed, dead -> live
                        board[i][j] = 2;
                }
            }
        }

        // update final status
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (board[i][j] == -1)
                    board[i][j] = 0;
                else if (board[i][j] == 2)
                    board[i][j] = 1;
            }
        }
    }

    private int CountNeighbors1(int[][] board, int row, int col)
    {
        int m = board.Length;
        int n = board[0].Length;
        int count = 0;
        foreach (var dir in directions)
        {
            int r = row + dir[0];
            int c = col + dir[1];
            if (r < 0 || r >=m || c < 0 || c >= n)
                continue;
            if (Math.Abs(board[r][c]) == 1)
                count++;
        }

        return count;
    }
}
