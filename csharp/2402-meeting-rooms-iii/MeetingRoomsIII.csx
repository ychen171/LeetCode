public class Solution
{
    public int MostBooked(int n, int[][] meetings)
    {
        Array.Sort(meetings, (a, b) => a[0] - b[0]);

        var pq = new PriorityQueue<KeyValuePair<long, long>, KeyValuePair<long, long>>(new RoomComparer()); // [end, room], end
        var availRoomPQ = new PriorityQueue<long, long>(); // room, room
        for (long i = 0; i < n; i++)
            availRoomPQ.Enqueue(i, i);
        var countArray = new long[n];
        var m = meetings.Length;

        foreach (var intv in meetings)
        {
            while (pq.Count != 0 && pq.Peek().Key <= intv[0])
            {
                var last = pq.Dequeue();
                availRoomPQ.Enqueue(last.Value, last.Value);
            }

            if (availRoomPQ.Count == 0) // there is no available room
            {
                var last = pq.Dequeue(); // last[0] > intv[0]
                var len = intv[1] - intv[0];
                var room = last.Value;
                var element = new KeyValuePair<long, long>(last.Key + len, room);
                pq.Enqueue(element, element);
                countArray[room]++;
            }
            else // there are available rooms
            {
                var room = availRoomPQ.Dequeue();
                var element = new KeyValuePair<long, long>(intv[1], room);
                pq.Enqueue(element, element);
                countArray[room]++;
            }
        }

        int result = 0;
        long count = 0;
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

public class RoomComparer : IComparer<KeyValuePair<long, long>>
{
    public int Compare(KeyValuePair<long, long> a, KeyValuePair<long, long> b)
    {
        if (a.Key == b.Key)
        {
            if (a.Value == b.Value)
                return 0;
            else if (a.Value < b.Value)
                return -1;
            else
                return 1;
        }
        else
        {
            if (a.Key == b.Key)
                return 0;
            else if (a.Key < b.Key)
                return -1;
            else
                return 1;
        }
    }
}


var sln = new Solution();
var n = 4;
var meetings = new int[][] { new int[] { 19, 20 }, new int[] { 14, 15 }, new int[] { 13, 14 }, new int[] { 11, 20 } };
var result = sln.MostBooked(n, meetings);
Console.WriteLine(result);

