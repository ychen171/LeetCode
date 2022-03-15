public class Solution
{
    // Backtracking
    // Time: O(N!)
    // Space: O(N)
    public int TotalNQueens(int n)
    {
        return Backtrack(n, 0, new HashSet<int>(), new HashSet<int>(), new HashSet<int>());
    }

    private int Backtrack(int n, int row, HashSet<int> cols, HashSet<int> diagonals, HashSet<int> antiDiagonals)
    {
        // Base case -- N queens have been placed
        if (row == n)
            return 1;
        
        int count = 0;
        for (int col = 0; col < n; col++)
        {
            int currDiagonal = row - col;
            int currAntiDiagonal = row + col;
            // current position is not placeable
            if (cols.Contains(col) || diagonals.Contains(currDiagonal) || antiDiagonals.Contains(currAntiDiagonal))
                continue;
            // place queen 
            cols.Add(col);
            // update board state
            diagonals.Add(currDiagonal);
            antiDiagonals.Add(currAntiDiagonal);
            // move on to the next row with the updated state
            count += Backtrack(n, row + 1, cols, diagonals, antiDiagonals);
            // remove the queen and its state
            cols.Remove(col);
            diagonals.Remove(currDiagonal);
            antiDiagonals.Remove(currAntiDiagonal);
        }

        return count;
    }

}
