public class Solution
{
    // Vertical Iteration
    // Time: O(m*n)
    // Space: O(1)
    public int[] KWeakestRows(int[][] mat, int k)
    {
        int m = mat.Length;
        int n = mat[0].Length;

        var ans = new int[k];
        int index = 0;

        // foreach column, iterate through cell
        // find the first 0 position in each row
        for (int j = 0; j < n && index < k; j++)
        {
            for (int i = 0; i < m && index < k; i++)
            {
                if (mat[i][j] == 0 && (j == 0 || mat[i][j - 1] == 1))
                {
                    ans[index] = i;
                    index++;
                }
            }
        }

        // if the ans array has not been filled up, some rows are entirely 1s
        // need to include the 1s with the lowest indexes until the ans array is filled up
        for (int i = 0; i < m && index < k; i++)
        {
            if (mat[i][n - 1] == 1)
            {
                ans[index] = i;
                index++;
            }
        }

        return ans;
    }
}
