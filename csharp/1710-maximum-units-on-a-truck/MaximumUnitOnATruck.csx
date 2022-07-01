public class Solution
{
    // Sorting
    // Time: O(n log n)
    // Space: O(n)
    public int MaximumUnits(int[][] boxTypes, int truckSize)
    {
        int n = boxTypes.Length;
        // sort boxTypes by numberOfUnitsPerBox in descending order
        Array.Sort(boxTypes, (a, b) => b[1] - a[1]);
        int maxUnits = 0;
        int k = 0;
        for (int i = 0; i < n && k < truckSize; i++)
        {
            int[] box = boxTypes[i];
            int boxCount = box[0];
            int boxUnit = box[1];
            int numToAdd = k + boxCount <= truckSize ? boxCount : truckSize - k;
            maxUnits += numToAdd * boxUnit;
            k += numToAdd;
        }

        return maxUnits;
    }

    // Priority Queue
    // Time: O(n log n)
    // Space: O(n)
    public int MaximumUnits1(int[][] boxTypes, int truckSize)
    {
        var pq = new PriorityQueue<int[], int>();
        // sort boxTypes by numberOfUnitsPerBox in descending order
        foreach (var boxType in boxTypes)
            pq.Enqueue(boxType, -boxType[1]);

        int maxUnits = 0;
        while (pq.Count != 0)
        {
            int[] box = pq.Dequeue();
            int boxCount = box[0];
            int boxUnit = box[1];
            int countToAdd = Math.Min(truckSize, boxCount);
            maxUnits += countToAdd * boxUnit;
            truckSize -= countToAdd;
            if (truckSize == 0)
                break;
        }

        return maxUnits;
    }
}

