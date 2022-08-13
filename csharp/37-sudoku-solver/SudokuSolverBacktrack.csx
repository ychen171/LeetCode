// Brute force
// Time: 9^81
// Space: fixed

// Backtracking
// Time: (9!)^9
// Space: fixed

public class Solution
{
    Dictionary<int, HashSet<int>> rows;
    Dictionary<int, HashSet<int>> cols;
    Dictionary<int, HashSet<int>> boxes;
    char[][] board;
    bool solved;
    public void SolveSudoku(char[][] board)
    {
        this.rows = new Dictionary<int, HashSet<int>>();
        this.cols = new Dictionary<int, HashSet<int>>();
        this.boxes = new Dictionary<int, HashSet<int>>();
        this.board = board;
        // init rows, cols, and boxes
        for (int row = 0; row < 9; row++)
        {
            for (int col = 0; col < 9; col++)
            {
                var idx = row / 3 * 3 + col / 3;
                if (!rows.ContainsKey(row))
                    rows[row] = new HashSet<int>();
                if (!cols.ContainsKey(col))
                    cols[col] = new HashSet<int>();
                if (!boxes.ContainsKey(idx))
                    boxes[idx] = new HashSet<int>();

                char c = board[row][col];
                if (c != '.')
                {
                    int d = ((int)char.GetNumericValue(c));
                    rows[row].Add(d);
                    cols[col].Add(d);
                    boxes[idx].Add(d);
                }
            }
        }
        // backtracking
        solved = false;
        Backtrack(0, 0);
    }

    public void Backtrack(int row, int col)
    {
        // base case
        if (row == 9)
        {
            solved = true;
            return;
        }
        // recursive case
        if (col == 9)
        {
            Backtrack(row + 1, 0);
            return;
        }

        if (board[row][col] != '.')
        {
            Backtrack(row, col + 1);
            return;
        }

        for (int d = 1; d <= 9; d++)
        {
            var idx = row / 3 * 3 + col / 3;
            if (rows[row].Contains(d) || cols[col].Contains(d) || boxes[idx].Contains(d))
                continue;

            rows[row].Add(d);
            cols[col].Add(d);
            boxes[idx].Add(d);
            board[row][col] = (char)('0' + d);
            Backtrack(row, col + 1);
            if (solved)
                return;
            board[row][col] = '.';
            rows[row].Remove(d);
            cols[col].Remove(d);
            boxes[idx].Remove(d);
        }

        return;
    }
}
