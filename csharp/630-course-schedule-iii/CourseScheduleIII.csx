public class Solution
{
    // Sorting + Priority Queue
    // Time: O(n log n)
    // Space: O(n)
    public int ScheduleCourse(int[][] courses)
    {
        // edge case
        int n = courses.Length;
        if (n <= 1)
            return n;
        // sort [duration, end] by end
        Array.Sort(courses, (a, b) => a[1] - b[1]);
        var pq = new PriorityQueue<int[], int>(); // <[duration, end], -duration>
        int totalDays = 0;

        for (int i = 0; i < n; i++)
        {
            var curr = courses[i];
            int duration = curr[0];
            int end = curr[1];
            int start = end - duration;
            if (totalDays + duration <= end) // can take curr course
            {
                pq.Enqueue(curr, -duration);
                totalDays += duration;
            }
            else // cannot take curr course
            {
                if (pq.Count == 0) // no previous course was taken
                    continue;
                
                // find the course we have taken with max duration
                // compare it with the duration of current course
                // if curr course duration is smaller, replace prev with curr
                if (pq.Peek()[0] > duration)
                {
                    var courseToReplace = pq.Dequeue();
                    totalDays -= courseToReplace[0];
                    pq.Enqueue(curr, -duration);
                    totalDays += duration;
                }
            }
        }

        return pq.Count;
    }
}

var s = new Solution();
// var courses = new int[][] { new int[] { 100, 200 }, new int[] { 200, 1300 }, new int[] { 1000, 1250 }, new int[] { 2000, 3200 } };
// var courses = new int[][] { new int[] { 1, 2 }, new int[] { 2, 3 } };
var courses = new int[][] { new int[] { 5, 15 }, new int[] { 3, 19 }, new int[] { 6, 7 }, new int[] { 2, 10 }, new int[] { 5, 16 }, new int[] { 8, 14 }, new int[] { 10, 11 }, new int[] { 2, 19 } };
var result = s.ScheduleCourse(courses);
Console.WriteLine(result);
