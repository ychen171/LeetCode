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
    bool sudokuSolved = false;
    public void SolveSudoku(char[][] board)
    {
        this.rows = new Dictionary<int, HashSet<int>>();
        this.cols = new Dictionary<int, HashSet<int>>();
        this.boxes = new Dictionary<int, HashSet<int>>();
        this.board = board;
        // init rows, cols, and boxes
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                char c = board[i][j];
                if (c != '.')
                {
                    int d = ((int)char.GetNumericValue(c));
                    PlaceNumber(d, i, j);
                }
            }
        }

        Backtrack(0, 0);
    }
    public bool CanPlace(int d, int row, int col)
    {
        if (!rows.ContainsKey(row))
            rows[row] = new HashSet<int>();
        if (!cols.ContainsKey(col))
            cols[col] = new HashSet<int>();
        var idx = row / 3 * 3 + col / 3;
        if (!boxes.ContainsKey(idx))
            boxes[idx] = new HashSet<int>();
        return !rows[row].Contains(d) && !cols[col].Contains(d) && !boxes[idx].Contains(d);
    }
    public void PlaceNumber(int d, int row, int col)
    {
        if (!rows.ContainsKey(row))
            rows[row] = new HashSet<int>();
        if (!cols.ContainsKey(col))
            cols[col] = new HashSet<int>();
        var idx = row / 3 * 3 + col / 3;
        if (!boxes.ContainsKey(idx))
            boxes[idx] = new HashSet<int>();
        rows[row].Add(d);
        cols[col].Add(d);
        boxes[idx].Add(d);
        board[row][col] = (char)(d + '0');
    }
    public void RemoveNumber(int d, int row, int col)
    {
        int idx = row / 3 * 3 + col / 3;
        rows[row].Remove(d);
        cols[col].Remove(d);
        boxes[idx].Remove(d);
        board[row][col] = '.';
    }
    public void PlaceNextNumbers(int row, int col)
    {
        if (col == 8 && row == 8)
            sudokuSolved = true;
        else
        {
            if (col == 8)
                Backtrack(row + 1, 0);
            else
                Backtrack(row, col + 1);
        }
    }
    public void Backtrack(int row, int col)
    {
        if (board[row][col] == '.')
        {
            for (int d = 1; d <= 9; d++)
            {
                if (CanPlace(d, row, col))
                {
                    PlaceNumber(d, row, col);
                    PlaceNextNumbers(row, col);
                    if (!sudokuSolved)
                        RemoveNumber(d, row, col);
                }
            }
        }
        else
        {
            PlaceNextNumbers(row, col);
        }
    }
}
