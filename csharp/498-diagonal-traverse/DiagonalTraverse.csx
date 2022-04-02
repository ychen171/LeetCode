public class Solution
{
    // Brute force | diagonal iteration
    // Time: O(m * n)
    // Space: O(m * n)
    public int[] FindDiagonalOrder(int[][] mat)
    {
        int m = mat.Length;
        int n = mat[0].Length;
        var ans = new List<int>();
        int row = 0, col = 0;
        bool isUp = true;
        int level = 0;

        for (int i = 0; i < m; i++)
        {
            if (isUp)
            {
                for (int j = 0; j < n; j++)
                {
                    col = j;
                    row = level - j;
                    if (col < 0 || col >= n || row < 0 || row >= m)
                        continue;
                    Console.WriteLine($"{row},{col}");
                    ans.Add(mat[row][col]);
                }
            }
            else
            {
                for (int j = 0; j < m; j++)
                {
                    row = j;
                    col = level - j;
                    if (row < 0 || row >= m || col < 0 || col >= n)
                        continue;
                    Console.WriteLine($"{row},{col}");
                    ans.Add(mat[row][col]);
                }
            }
            level++;
            isUp = isUp ? false : true;
        }

        for (int i = m + 1; i < m + n; i++)
        {
            if (isUp)
            {
                for (int j = m - 1; j >= 0; j--)
                {
                    row = j;
                    col = level - j;
                    if (row < 0 || row >= m || col < 0 || col >= n)
                        continue;
                    Console.WriteLine($"{row},{col}");
                    ans.Add(mat[row][col]);
                }
            }
            else
            {
                for (int j = n - 1; j >= 0; j--)
                {
                    col = j;
                    row = level - j;
                    if (col < 0 || col >= n || row < 0 || row >= m)
                        continue;
                    Console.WriteLine($"{row},{col}");
                    ans.Add(mat[row][col]);
                }
            }
            level++;
            isUp = isUp ? false : true;
        }

        return ans.ToArray();
    }
}
