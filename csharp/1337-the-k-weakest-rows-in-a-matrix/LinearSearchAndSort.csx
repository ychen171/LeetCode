public class Solution
{
    // Linear Search + Sorting with custom comparer
    // Time: O(m*n + m log m)
    // Space: O(m)
    public int[] KWeakestRows(int[][] mat, int k)
    {
        int m = mat.Length;
        int n = mat[0].Length;

        // count 1s by row
        var indexCountDict = new Dictionary<int, int[]>(); // <row index, [row index, count]>
        for (int i = 0; i < m; i++)
        {
            int[] row = mat[i];
            int count = 0;
            for (int j = 0; j < n; j++)
            {
                if (row[j] == 1)
                    count++;
            }
            indexCountDict[i] = new int[] { i, count };
        }

        // sort [row index, count] by 1) count of 1s and 2) row index
        var items = indexCountDict.Values.ToArray();
        Array.Sort(items, new RowComparer());
        var ans = new int[k];
        for (int i = 0; i < k; i++)
            ans[i] = items[i][0];

        return ans;
    }
}

public class RowComparer : IComparer<int[]>
{
    public int Compare(int[] a, int[] b)
    {
        return a[1] == b[1] ? a[0] - b[0] : a[1] - b[1];
    }
}
