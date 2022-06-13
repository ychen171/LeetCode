public class Solution
{
    // DP | Tabulation
    // Time: O(n^2)
    // Space: O(n^2)
    public int MinimumTotal(IList<IList<int>> triangle)
    {
        int n = triangle.Count;

        // initialize the table with default values
        var table = new int[n][];
        for (int i = 0; i < n; i++)
        {
            table[i] = new int[n];
            for (int j = 0; j < n; j++)
                table[i][j] = int.MaxValue;
        }
        // seed the trivial answer into the table
        table[0][0] = triangle[0][0];
        for (int i = 1; i < n; i++)
        {
            table[i][0] = table[i - 1][0] + triangle[i][0];
        }
        // fill further positions based on current position
        for (int i = 1; i < n; i++)
        {
            for (int j = 1; j <= i; j++)
            {
                // recurrence relation
                if (i >= j)
                {
                    table[i][j] = Math.Min(table[i][j], table[i - 1][j - 1] + triangle[i][j]);
                }
                if (i > j)
                {
                    table[i][j] = Math.Min(table[i][j], table[i - 1][j] + triangle[i][j]);
                }

            }
        }

        return table.Last().Min();
    }

    // DP | In-place
    // Time: O(n^2)
    // Space: O(1)
    public int MinimumTotal1(IList<IList<int>> triangle)
    {
        int n = triangle.Count;
        for (int i = n - 2; i >= 0; i--)
        {
            for (int j = 0; j <= i; j++)
            {
                triangle[i][j] += Math.Min(triangle[i + 1][j], triangle[i + 1][j + 1]);
            }
        }

        return triangle[0][0];
    }
}

var s = new Solution();
var triangle = new List<IList<int>>() { new List<int>() { 2 }, new List<int>() { 3, 4 }, new List<int>() { 6, 5, 7 } };
var result = s.MinimumTotal(triangle);
Console.WriteLine(result);
