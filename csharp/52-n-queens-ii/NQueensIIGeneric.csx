public class Solution
{
    int count = 0;
    public int TotalNQueens(int n)
    {
        Backtrack(n, 0, new HashSet<int>(), new HashSet<int>(), new HashSet<int>());
        return count;
    }

    // Permutation
    // Time: O(n!)
    // Space: O(n)
    private void Backtrack(int n, int row, HashSet<int> colSet, HashSet<int> diagSet, HashSet<int> antiDiagSet)
    {
        // base case
        if (row == n)
        {
            count++;
            return;
        }

        // recursive case
        for (int col = 0; col < n; col++)
        {
            // invalid or visited
            if (colSet.Contains(col) || diagSet.Contains(col - row) || antiDiagSet.Contains(col + row))
                continue;
            // add
            colSet.Add(col);
            diagSet.Add(col - row);
            antiDiagSet.Add(col + row);
            // backtrack
            Backtrack(n, row + 1, colSet, diagSet, antiDiagSet);
            // remove
            colSet.Remove(col);
            diagSet.Remove(col - row);
            antiDiagSet.Remove(col + row);
        }
    }
}
