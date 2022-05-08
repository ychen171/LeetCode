public class Solution
{
    public string Tictactoe(int[][] moves)
    {
        // fill the grid
        int[,] grid = new int[3, 3];
        for (int i = 0; i < moves.Length; i++)
        {
            int r = moves[i][0];
            int c = moves[i][1];
            if (i % 2 == 0) // A move
            {
                grid[r, c] = 1;
            }
            else // B move
            {
                grid[r, c] = -1;
            }
        }

        // check every row
        for (int r = 0; r < 3; r++)
        {
            if (grid[r, 0] == 0)
                continue;
            if (grid[r, 0] == grid[r, 1] && grid[r, 1] == grid[r, 2])
            {
                return grid[r, 0] == 1 ? "A" : "B";
            }
        }

        // check every col
        for (int c = 0; c < 3; c++)
        {
            if (grid[0, c] == 0)
                continue;
            if (grid[0, c] == grid[1, c] && grid[1, c] == grid[2, c])
            {
                return grid[0, c] == 1 ? "A" : "B";
            }
        }

        // check every diagonal
        if ((grid[0, 0] == grid[1, 1] && grid[1, 1] == grid[2, 2]) || (grid[0, 2] == grid[1, 1] && grid[1, 1] == grid[2, 0]))
        {
            if (grid[1, 1] == 1)
                return "A";
            if (grid[1, 1] == -1)
                return "B";
        }

        foreach (int cell in grid)
        {
            if (cell == 0)
                return "Pending";
        }

        return "Draw";
    }
}

