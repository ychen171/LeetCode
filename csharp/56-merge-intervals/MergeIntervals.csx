public class Solution
{
    // sort and compare
    // Time: O(N * log N)
    // Space: O(N)
    public int[][] Merge(int[][] intervals)
    {
        int[][] sortedIntervals = intervals.OrderBy(x => x[0]).ToArray();
        List<int[]> mergedIntervals = new List<int[]>();
        mergedIntervals.Add(sortedIntervals[0]);
        for (int i = 1; i < sortedIntervals.Length; i++)
        {
            var lastInterval = mergedIntervals.Last();
            var currInterval = sortedIntervals[i];
            if (currInterval[0] <= lastInterval[1])
            {
                if (currInterval[1] > lastInterval[1])
                    lastInterval[1] = currInterval[1];
            }
            else
            {
                mergedIntervals.Add(currInterval);
            }
        }

        return mergedIntervals.ToArray();
    }
}
