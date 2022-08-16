public class Solution
{
    // Sorting
    // Time: O(N * log N)
    // Space: O(N)
    public int[][] Merge(int[][] intervals)
    {
        int n = intervals.Length;
        // edge case
        if (n <= 1)
            return intervals;

        Array.Sort(intervals, (a, b) => a[0] - b[0]);
        var mergedList = new List<int[]>();
        mergedList.Add(intervals[0]);
        for (int i = 1; i < n; i++)
        {
            var last = mergedList.Last();
            var curr = intervals[i];
            if (last[1] < curr[0]) // not overlapped
            {
                mergedList.Add(curr);
            }
            else
            {
                last[1] = Math.Max(last[1], curr[1]);
            }
        }

        return mergedList.ToArray();
    }
}
