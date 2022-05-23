public class Solution
{
    // Greedy
    // Time: O(n)
    // Space: O(n)
    public int[][] Insert(int[][] intervals, int[] newInterval)
    {
        // 1    3         6       9
        //    2      5
        int n = intervals.Length;
        if (n == 0)
            return new int[][] { newInterval };

        // iterate through intervals
        // foreach interval, compare it with new interval
        // if overlapping, merge and return
        var result = new List<int[]>();
        int newS = newInterval[0];
        int newE = newInterval[1];
        int i = 0;
        bool isInserted = false;
        while (i < n)
        {
            var currInterval = intervals[i];
            int currS = currInterval[0];
            int currE = currInterval[1];

            if (currE < newS) // not overlapped, curr before new
            {
                result.Add(currInterval);
                i++;
            }
            else if (newE < currS) // not overlapped, new before curr
            {
                result.Add(new int[] { newS, newE });
                result.Add(currInterval);
                isInserted = true;
                i++;
                break;
            }
            else // overlapped, merge and create new
            {
                newS = Math.Min(currS, newS);
                newE = Math.Max(currE, newE);
                i++;
            }
        }
        if (!isInserted)
        {
            result.Add(new int[] { newS, newE });
        }
        while (i < n)
        {
            result.Add(intervals[i]);
            i++;
        }

        return result.ToArray();
    }
}
