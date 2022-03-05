public class Solution
{
    // Sort with Custom Comparer
    // Time: O(n log n)
    // Space: O(n)
    public int[][] KClosestSort(int[][] points, int k)
    {
        if (points.Length <= 1) return points;
        Array.Sort(points, (a, b) => (a[0] * a[0] + a[1] * a[1]) - (b[0] * b[0] + b[1] * b[1]));
        var result = new List<int[]>();
        for (int i = 0; i < k; i++)
            result.Add(points[i]);
        return result.ToArray();
    }


    // Priority Queue | Max Heap
    // Time: O(n log k)
    // Space: O(k)
    public int[][] KClosest(int[][] points, int k)
    {
        if (points.Length <= 1) return points;
        var pq = new PriorityQueue<int[], int>();
        foreach (var pair in points)
        {
            var x = pair[0];
            var y = pair[1];
            var dSquare = x * x + y * y;
            pq.Enqueue(pair, -dSquare);
            if (pq.Count > k)
                pq.Dequeue();
        }

        var result = new List<int[]>();
        foreach (var item in pq.UnorderedItems)
        {
            result.Add(item.Element);
        }
        return result.ToArray();
    }
}

var s = new Solution();
var result = s.KClosest(new int[][]{new int[]{1,3}, new int[]{-2,2}}, 1);
Console.WriteLine(result);


