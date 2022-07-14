public class Solution
{
    int size;
    IList<IList<string>> solutions = new List<IList<string>>();
    public IList<IList<string>> SolveNQueens(int n)
    {
        if (n == 1)
            return new List<IList<string>> { new List<string> { "Q" } };
        size = n;

        // col set, diagnal set, antidiagonal set
        var colSet = new HashSet<int>();        // [0,...,n-1]
        var diagSet = new HashSet<int>();       // [-(n-1),...,0,...,n-1]
        var antiDiagSet = new HashSet<int>();   // [0,...,2 * (n-1)]
        // empty board
        var board = new char[n][];
        for (int i = 0; i < n; i++)
        {
            board[i] = new char[n];
            for (int j = 0; j < n; j++)
            {
                board[i][j] = '.';
            }
        }

        Backtrack(board, 0, colSet, diagSet, antiDiagSet);

        return solutions;
    }

    // Time: O(n * n!)
    // Space: O(n^2)
    private void Backtrack(char[][] board, int row, HashSet<int> colSet, HashSet<int> diagSet, HashSet<int> antiDiagSet)
    {
        // base case
        if (row == size)
        {
            solutions.Add(GenerateSolution(board));
            return;
        }
        // recursive case
        for (int col = 0; col < size; col++)
        {
            // invalid
            if (colSet.Contains(col) || diagSet.Contains(col - row) || antiDiagSet.Contains(col + row))
                continue;

            // add
            colSet.Add(col);
            diagSet.Add(col - row);
            antiDiagSet.Add(col + row);
            board[row][col] = 'Q';
            // backtrack
            Backtrack(board, row + 1, colSet, diagSet, antiDiagSet);
            // remove
            colSet.Remove(col);
            diagSet.Remove(col - row);
            antiDiagSet.Remove(col + row);
            board[row][col] = '.';

        }
    }

    private IList<string> GenerateSolution(char[][] placement)
    {
        var result = new List<string>();
        for (int i = 0; i < size; i++)
        {
            result.Add(new string(placement[i]));
        }

        return result;
    }
}

