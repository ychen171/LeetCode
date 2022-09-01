public class Solution
{
    // Priority Queue
    // Time: O(n log n)
    // Space: O(n)
    public int MinMeetingRooms(int[][] intervals)
    {
        if (intervals.Length == 0) return 0;

        // sort the meetings by start time
        var sorted = intervals.OrderBy(i => i[0]).ToArray();
        // Array.Sort(intervals, (a, b) => a[0] - b[0]);
        // Min heap
        var allocator = new PriorityQueue<int[], int>();
        // add first meeting interval, ordered by end time
        allocator.Enqueue(sorted[0], sorted[0][1]);
        // Iterate through the remaining sorted intervals
        for (int i = 1; i < sorted.Length; i++)
        {
            // if the earliest meeting is ended before the new meeting is started, remove the earliest meeting 
            if (sorted[i][0] >= allocator.Peek()[1])
                allocator.Dequeue();
            // add the new meeting
            allocator.Enqueue(sorted[i], sorted[i][1]);
        }
        // return the size of Priority Queue
        return allocator.Count;
    }

    // Sorting + Two Pointers
    // Time: O(n log n)
    // Space: O(n)
    public int MinMeetingRooms1(int[][] intervals)
    {
        int n = intervals.Length;
        if (n == 1)
            return 1;

        var starts = new int[n];
        var ends = new int[n];
        for (int i = 0; i < n; i++)
        {
            var intv = intervals[i];
            starts[i] = intv[0];
            ends[i] = intv[1];
        }
        // sort by start
        Array.Sort(starts);
        // sort by end
        Array.Sort(ends);
        // scan and find overlapping
        int p = 0, q = 0;
        int count = 0;
        int ans = 0;
        while (p < n && q < n)
        {
            if (starts[p] < ends[q]) // overlapping
            {
                count++;
                p++;
            }
            else
            {
                count--;
                q++;
            }
            ans = Math.Max(ans, count);
        }

        return ans;
    }
}

var s = new Solution();
Console.WriteLine(s.MinMeetingRooms(new int[][] { new int[] { 0, 30 }, new int[] { 5, 10 }, new int[] { 15, 20 } }));
Console.WriteLine(s.MinMeetingRooms(new int[][] { new int[] { 7, 10 }, new int[] { 2, 4 } }));
Console.WriteLine(s.MinMeetingRooms(new int[][] { new int[] { 1, 10 }, new int[] { 2, 5 }, new int[] { 3, 4 } }));

