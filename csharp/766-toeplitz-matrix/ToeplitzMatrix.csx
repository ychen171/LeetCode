public class Solution
{
    // Matrix
    // Time: O(m * n)
    // Space: O(1)
    public bool IsToeplitzMatrix(int[][] matrix)
    {
        int m = matrix.Length;
        int n = matrix[0].Length;
        if (m == 1 || n == 1) return true;
        for (int i = 0; i < m; i++)
        {
            var val = matrix[i][0];
            int r = i + 1, c = 1;
            while (r < m && c < n)
            {
                if (matrix[r][c] != val)
                    return false;
                r++;
                c++;
            }
        }
        for (int j = 0; j < n; j++)
        {
            var val = matrix[0][j];
            int r = 1, c = j + 1;
            while (r < m && c < n)
            {
                if (matrix[r][c] != val)
                    return false;
                r++;
                c++;
            }
        }
        return true;
    }
}
