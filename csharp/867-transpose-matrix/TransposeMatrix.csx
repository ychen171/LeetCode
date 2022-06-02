public class Solution
{
    public int[][] Transpose(int[][] matrix)
    {
        int m = matrix.Length;
        int n = matrix[0].Length;

        var ans = new int[n][];
        for (int col = 0; col < n; col++)
        {
            ans[col] = new int[m];
            for (int row = 0; row < m; row++)
            {
                ans[col][row] = matrix[row][col];
            }
        }

        return ans;
    }
}
