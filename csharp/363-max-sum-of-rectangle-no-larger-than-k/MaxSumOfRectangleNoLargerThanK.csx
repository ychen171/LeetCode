public class Solution
{
    // Time: O(m^2 * n^2)
    // Space: O(n)
    int result = int.MinValue;
    public int MaxSumSubmatrix(int[][] matrix, int k)
    {
        int m = matrix.Length;
        int n = matrix[0].Length;
        // stores the 1d representation of the matrix
        for (int i = 0; i < m; i++)
        {
            var rowSum = new int[n];
            for (int r = i; r < m; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    rowSum[c] += matrix[r][c];
                }
                UpdateResult(rowSum, k);
                if (result == k)
                    return result;
            }
        }

        return result;
    }

    public void UpdateResult(int[] nums, int k)
    {
        int sum = 0;
        var sortedSum = new SortedSet<int>();

        sortedSum.Add(0);
        foreach (var num in nums)
        {
            sum += num;
            int x = -1;
            // find x where sum - x <= k
            // sum - k <= x
            foreach (var element in sortedSum)
            {
                if (element >= sum - k)
                {
                    x = element;
                    break;
                }
            }

            if (x != -1)
                result = Math.Max(result, sum - x);

            sortedSum.Add(sum);
        }
    }
}
