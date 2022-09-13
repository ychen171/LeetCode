public class Solution
{
    public int MinGroups(int[][] intervals)
    {
        int n = intervals.Length;
        if (n == 1)
            return 1;

        Array.Sort(intervals, (a, b) =>
        {
            if (a[0] == b[0])
                return a[1] - b[1];
            return a[0] - b[0];
        });

        var pq = new PriorityQueue<int, int>(); // min heap  <end, end>
        foreach (var intv in intervals)
        {
            if (pq.Count != 0 && pq.Peek() < intv[0]) // not overlapped
            {
                pq.Dequeue();
            }
            pq.Enqueue(intv[1], intv[1]);
        }

        return pq.Count;
    }
}
