public class Solution
{
    // Merge Interval
    // Time: O(n1 + n2)
    // Space: O(n1 + n2)
    public int[][] IntervalIntersection(int[][] firstList, int[][] secondList)
    {
        // edge case
        int n1 = firstList.Length;
        int n2 = secondList.Length;
        if (n1 == 0 || n2 == 0)
            return new int[][] { };

        var mergedList = new List<int[]>();
        int i = 0, j = 0;
        while (i < n1 && j < n2)
        {
            var first = firstList[i];
            var second = secondList[j];
            // overlapped
            if (!(first[1] < second[0] || first[0] > second[1]))
            {
                mergedList.Add(new int[] { Math.Max(first[0], second[0]), Math.Min(first[1], second[1]) });
            }
            // move pointer forward
            if (first[1] < second[1])
                i++;
            else
                j++;
        }

        return mergedList.ToArray();
    }
}
