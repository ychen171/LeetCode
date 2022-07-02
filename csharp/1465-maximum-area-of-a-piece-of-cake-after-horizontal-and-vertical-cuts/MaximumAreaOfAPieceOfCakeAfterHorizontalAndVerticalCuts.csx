public class Solution
{
    // Greedy | Sorting
    // Time: O(m log m + n log n)
    // Space: O(m + n)
    public int MaxArea(int h, int w, int[] horizontalCuts, int[] verticalCuts)
    {
        // sort horizontal cuts and vertical cuts
        Array.Sort(horizontalCuts);
        Array.Sort(verticalCuts);

        int m = horizontalCuts.Length;
        long height = horizontalCuts[0];
        for (int i = 1; i < m; i++)
            height = Math.Max(height, horizontalCuts[i] - horizontalCuts[i - 1]);
        height = Math.Max(height, h - horizontalCuts[m - 1]);

        int n = verticalCuts.Length;
        long width = verticalCuts[0];
        for (int i = 1; i < n; i++)
            width = Math.Max(width, verticalCuts[i] - verticalCuts[i - 1]);
        width = Math.Max(width, w - verticalCuts[n - 1]);

        return (int)(height * width % 1000000007);
    }
}
