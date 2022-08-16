public class Solution
{
    // Sorting
    // Time: O(n log n)
    // Space: O(n)
    public int RemoveCoveredIntervals(int[][] intervals)
    {
        int n = intervals.Length;
        // edge case
        if (n <= 1)
            return n;

        Array.Sort(intervals, (a, b) =>
        {
            if (a[0] == b[0])
                return b[1] - a[1];
            return a[0] - b[0];
        }); // ascending order on start, descending order on end

        int count = 1;
        var prev = intervals[0];
        for (int i = 1; i < n; i++)
        {
            var curr = intervals[i];
            if (prev[1] < curr[1])
            {
                count++;
                prev = curr;
            }
        }

        return count;
    }
}
