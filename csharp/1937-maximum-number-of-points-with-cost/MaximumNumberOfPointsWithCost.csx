public class Solution
{
    // DP | Tabulation
    // Time: O(m * n)
    // Space: O(m * n)
    public long MaxPoints(int[][] points)
    {
        var m = points.Length;
        var n = points[0].Length;
        // initialize table with default value
        List<List<long>> table = new List<List<long>>();
        // seed the trivial answer into the table
        table.Add(new List<long>());
        for (int j = 0; j < n; j++)
        {
            table[0].Add(points[0][j]);
        }
        // fill further positions based on the current position
        // points[i-1][k] + points[i][j] - abs(j - k)
        // k <= j, points[i-1][k] + k + points[i][j] - j
        // k >= j, points[i-1][k] - k + points[i][j] + j

        for (int i = 1; i < m; i++)
        {
            table.Add(new List<long>());
            int k = 0;
            // check left paths
            long[] leftTable = new long[n];
            Array.Fill(leftTable, long.MinValue);
            leftTable[k] = table[i - 1][k] + k;
            for (k = 1; k < n; k++)
            {
                leftTable[k] = Math.Max(leftTable[k - 1], table[i - 1][k] + k);
            }
            // check right paths
            long[] rightTable = new long[n];
            Array.Fill(rightTable, long.MinValue);
            k = n - 1;
            rightTable[k] = table[i - 1][k] - k;
            for (k = n - 2; k >= 0; k--)
            {
                rightTable[k] = Math.Max(rightTable[k + 1], table[i - 1][k] - k);
            }

            for (int j = 0; j < n; j++)
            {
                table[i].Add(Math.Max(leftTable[j] - j, rightTable[j] + j) + points[i][j]);
            }
        }

        return table[m - 1].Max();
    }
}

var s = new Solution();
Console.WriteLine(s.MaxPoints(new int[][] { new int[] { 1, 2, 3 }, new int[] { 1, 5, 1 }, new int[] { 3, 1, 1 } }));
