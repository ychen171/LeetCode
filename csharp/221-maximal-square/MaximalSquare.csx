public class Solution
{
    // DP | Bottom-up | Tabulation | Iteration
    // Time: O(m*n)
    // Space: O(m*n)
    public int MaximalSquare(char[][] matrix)
    {
        var m = matrix.Length;
        var n = matrix[0].Length;
        // initialize table with default values
        int[,] table = new int[m + 1, n + 1]; // has addtional row 0, col 0
        int max = 0;
        // seed the trivial answer into the table
        // table[0,] and table[,0] all have 0 value
        // fill further positions with current position
        // table[1,1] matches matrix[0][0]
        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (matrix[i - 1][j - 1] == '1')
                {
                    table[i, j] = Math.Min(Math.Min(table[i, j - 1], table[i - 1, j]), table[i - 1, j - 1]) + 1;
                    max = Math.Max(max, table[i, j]);
                }
            }
        }

        return max * max;
    }
}

var s = new Solution();
Console.WriteLine(s.MaximalSquare(new char[][] { new char[] { '0', '1' }, new char[] { '1', '0' } }));

