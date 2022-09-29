public class Solution 
{
    // Priority Queue | Max Heap
    // Time: O(n log k + k log k)
    // Space: O(k)
    public IList<int> FindClosestElements(int[] arr, int k, int x) 
    {
        // max heap
        var pq = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => 
         {
             var diffA = Math.Abs(a - x);
             var diffB = Math.Abs(b - x);
             if (diffA == diffB)
                 return b - a;
             return diffB - diffA;
         }));
        
        foreach (var num in arr)
        {
            pq.Enqueue(num, num);
            if (pq.Count > k)
                pq.Dequeue();
        }
        
        var result = new List<int>();
        while (pq.Count != 0)
        {
            result.Add(pq.Dequeue());
        }
        result.Sort();
        return result;
    }
}
