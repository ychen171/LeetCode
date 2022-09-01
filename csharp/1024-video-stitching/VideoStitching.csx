public class Solution
{
    // Greedy + Sorting
    // Time: O(n log n)
    // Space: O(n)
    public int VideoStitching(int[][] clips, int time)
    {
        int n = clips.Length;
        // Sorting by start in ascending order and end in descending order
        Array.Sort(clips, (a, b) =>
        {
            if (a[0] == b[0])
                return b[1] - a[1];
            return a[0] - b[0];
        });

        // iterate and merge
        if (clips[0][0] != 0)
            return -1;
        int currEnd = clips[0][1];
        int count = 1;
        int i = 1;
        while (i < n && currEnd < time)
        {
            // in all intvs which are overlapped with curr intv (clips[i][0] <= currEnd)
            // find the intv with max end
            // update currEnd
            int nextEnd = currEnd;
            while (i < n && clips[i][0] <= currEnd)
            {
                nextEnd = Math.Max(nextEnd, clips[i][1]);
                i++;
            }
            if (nextEnd == currEnd)
                break;
            count++;
            currEnd = nextEnd;
        }

        if (currEnd < time)
            return -1;
        return count;
    }
}

var sln = new Solution();
/*
[[0,2],[4,6],[8,10],[1,9],[1,5],[5,9]]
10
*/
var clips = new int[][] { new int[] { 0, 2 }, new int[] { 4, 8 } };
var time = 5;
var result = sln.VideoStitching(clips, time);
Console.WriteLine(result);

