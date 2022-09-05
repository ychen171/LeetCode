public class Solution
{
    public int MostBooked(int n, int[][] meetings)
    {
        Array.Sort(meetings, (a, b) => a[0] - b[0]);

        var pq = new PriorityQueue<int[], int>(); // [end, room], end
        var availRoomPQ = new PriorityQueue<int, int>(); // room, room
        for (int i = 0; i < n; i++)
            availRoomPQ.Enqueue(i, i);
        var countArray = new int[n];
        int m = meetings.Length;

        foreach (var intv in meetings)
        {
            int delay = 0;
            while (pq.Count != 0 && pq.Peek()[0] <= intv[0])
            {
                var last = pq.Dequeue();
                availRoomPQ.Enqueue(last[1], last[1]);
            }
            if (availRoomPQ.Count == 0) // there is no available room
            {
                var last = pq.Dequeue(); // last[0] > intv[0]
                availRoomPQ.Enqueue(last[1], last[1]);

                delay = Math.Max(0, last[0] - intv[0]);

                while (pq.Count != 0 && pq.Peek()[0] == intv[1])
                {
                    availRoomPQ.Enqueue(pq.Peek()[1], pq.Peek()[1]);
                    pq.Dequeue();
                }
            }

            var room = availRoomPQ.Dequeue();
            var element = new int[] { intv[1] + delay, room };
            pq.Enqueue(element, element[0]);
            countArray[room] += 1;
        }

        int result = 0;
        int count = 0;
        for (int i = 0; i < n; i++)
        {
            if (countArray[i] > count)
            {
                result = i;
                count = countArray[i];
            }
        }

        return result;
    }
}


var sln = new Solution();
var n = 4;
var meetings = new int[][] { new int[] { 19, 20 }, new int[] { 14, 15 }, new int[] { 13, 14 }, new int[] { 11, 20 } };
var result = sln.MostBooked(n, meetings);
Console.WriteLine(result);

