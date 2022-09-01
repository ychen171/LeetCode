public class Solution
{
    // Greedy | Sorting + Interval Scheduling
    // Time: O(n log n)
    // Space: O(n)
    public int EraseOverlapIntervals(int[][] intervals)
    {
        int n = intervals.Length;
        if (n == 1)
            return 0;
        // find the max non-overlapped intervals
        // sort by end
        Array.Sort(intervals, (a, b) => a[1] - b[1]);
        // iterate and compare start
        var last = intervals[0];
        int ans = 0; ;
        for (int i = 1; i < n; i++)
        {
            var curr = intervals[i];
            if (curr[0] >= last[1]) // non overlapped
            {
                last = curr;
            }
            else // overlapped
            {
                ans++;
            }
        }

        return ans;
    }
}
