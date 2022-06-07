public class Solution
{
    // Math | Think backward
    // Time: O(m*n)
    // Space: O(1)
    public bool RemoveOnes(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        // given row[0], for row[1], row[2], ... row[m-1], 
        // it is either the same as row[0] or completely flipped from row[0]
        var row0 = grid[0];
        for (int i = 1; i < m; i++)
        {
            var rowI = grid[i];
            if (!AreEqualOrFlipped(row0, rowI))
                return false;
        }

        return true;
    }

    private bool AreEqualOrFlipped(int[] row1, int[] row2)
    {
        bool flipped = row1[0] != row2[0];
        int n = row1.Length;
        for (int i = 1; i < n; i++)
        {
            if (flipped && row1[i] == row2[i])
                return false;
            if (!flipped && row1[i] != row2[i])
                return false;
        }

        return true;
    }
}
