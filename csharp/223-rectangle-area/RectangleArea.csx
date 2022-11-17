public class Solution
{
    public int ComputeArea(int ax1, int ay1, int ax2, int ay2, int bx1, int by1, int bx2, int by2)
    {
        int areaA = (ax2 - ax1) * (ay2 - ay1);
        int areaB = (bx2 - bx1) * (by2 - by1);
        // edge case
        if (areaA == 0) return areaB;
        if (areaB == 0) return areaA;
        // find overlapped
        int left = Math.Max(ax1, bx1);
        int right = Math.Min(ax2, bx2);
        int x = right - left;
        int bottom = Math.Max(ay1, by1);
        int top = Math.Min(ay2, by2);
        int y = top - bottom;
        int overlapped = 0;
        if (x > 0 && y > 0)
            overlapped = x * y;
        return areaA + areaB - overlapped;
    }
}
// Math
// Time: O(1)
// Space: O(1)
