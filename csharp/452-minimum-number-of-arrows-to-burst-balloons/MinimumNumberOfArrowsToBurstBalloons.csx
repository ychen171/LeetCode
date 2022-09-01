public class Solution
{
    // Greedy | Sorting + Interval Scheduling
    // Time: O(n log n)
    // Space: O(n)
    public int FindMinArrowShots(int[][] points)
    {
        int n = points.Length;
        if (n == 1)
            return 1;
        // find the maximum non-overlapping intervals
        // sort by end
        Array.Sort(points, (a, b) =>
        {
            if (a[1] == b[1])
                return 0;
            if (a[1] < b[1])
                return -1;
            return 1;
        });
        // iterate and find overlapping
        var last = points[0];
        int count = 1;
        for (int i = 1; i < n; i++)
        {
            var curr = points[i];
            if (curr[0] > last[1]) // non-overlapping
            {
                count++;
                last = curr;
            }
        }

        return count;
    }
}

var sln = new Solution();
// [[-2147483646,-2147483645],[2147483646,2147483647]]
var points = new int[][] { new int[] { -2147483646, -2147483645 }, new int[] { 2147483646, 2147483647 } };
var result = sln.FindMinArrowShots(points);
Console.WriteLine(result);


