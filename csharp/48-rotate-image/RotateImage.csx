public class Solution
{
    // two for loops
    // Time: O(n^2)
    // Space: O(1)
    public void Rotate(int[][] matrix)
    {
        var n = matrix.Length;
        for (int i = 0; i < n / 2; i++)
        {
            for (int j = 0; j < n / 2 + n % 2; j++)
            {
                var temp = matrix[n - 1 - j][i];
                matrix[n - 1 - j][i] = matrix[n - 1 - i][n - 1 - j];
                matrix[n - 1 - i][n - 1 - j] = matrix[j][n - 1 - i];
                matrix[j][n - 1 - i] = matrix[i][j];
                matrix[i][j] = temp;
            }
        }

        return;
    }

    // reverse on diagonal then reverse left to right
    // Transpose + Reflect
    // Time: O(n^2)
    // Space: O(1)
    public void Rotate12(int[][] matrix)
    {
        Transpose(matrix);
        Reflect(matrix);
    }

    private void Transpose(int[][] matrix)
    {
        var n = matrix.Length;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                if (i == j) continue;
                var temp = matrix[i][j];
                matrix[i][j] = matrix[j][i];
                matrix[j][i] = temp;
            }
        }
    }
    private void Reflect(int[][] matrix)
    {
        var n = matrix.Length;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n / 2; j++)
            {
                var temp = matrix[i][j];
                matrix[i][j] = matrix[i][n - 1 - j];
                matrix[i][n - 1 - j] = temp;
            }
        }
    }
}
