public class Solution
{
    // Binary Search + Priority Queue with custom comparer
    // Time: O(m log n + m log k)
    // Space: O(k)
    public int[] KWeakestRows(int[][] mat, int k)
    {
        int m = mat.Length;
        int n = mat[0].Length;

        // binary search on each row
        // priority queue to keep the k smallest items
        var pq = new PriorityQueue<int[], int[]>(new RowComparer()); // max heap
        for (int i = 0; i < m; i++)
        {
            int[] row = mat[i];
            int count = BinarySearch(row);
            int[] item = new int[] { i, count };
            pq.Enqueue(item, item);
            if (pq.Count > k)
            {
                pq.Dequeue();
            }
        }

        var ans = new int[k];
        for (int i = k - 1; i >= 0; i--)
        {
            var item = pq.Dequeue();
            ans[i] = item[0];
        }

        return ans;
    }

    public int BinarySearch(int[] row)
    {
        // find the left most index for 0
        int n = row.Length;
        int left = 0;
        int right = n - 1;

        while (left < right)
        {
            int mid = left + (right - left) / 2;
            // [..., mid][mid+1, ...]
            if (row[mid] == 1)
            {
                left = mid + 1;
            }
            else
            {
                right = mid;
            }
        }

        return row[left] == 0 ? left : n;
    }
}

public class RowComparer : IComparer<int[]>
{
    public int Compare(int[] a, int[] b)
    {
        return -(a[1] == b[1] ? a[0] - b[0] : a[1] - b[1]);
    }
}


var s = new Solution();
var mat = new int[][] { new int[] { 1, 1, 1, 1, 1 }, new int[] { 1, 0, 0, 0, 0 }, new int[] { 1, 1, 0, 0, 0 }, new int[] { 1, 1, 1, 1, 0 }, new int[] { 1, 1, 1, 1, 1 } };
var k = 3;
var result = s.KWeakestRows(mat, k);
foreach (var index in result)
{
    Console.WriteLine(index);
}
