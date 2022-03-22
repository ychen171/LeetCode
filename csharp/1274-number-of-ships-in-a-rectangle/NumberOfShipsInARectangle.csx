
// This is Sea's API interface.
// You should not implement it, or speculate about its implementation
class Sea
{
    public bool HasShips(int[] topRight, int[] bottomLeft)
    {
        // TODO
        return false;
    }
}


class Solution
{
    // Divide and Conquer
    // Time: O(log2 Max(m, n) - log4 S)
    // Space: O(log2 Max(m, n))
    public int CountShips(Sea sea, int[] topRight, int[] bottomLeft)
    {
        // base case
        var isShip = sea.HasShips(topRight, bottomLeft);
        if (!isShip)
            return 0;
        if (bottomLeft[0] == topRight[0] && bottomLeft[1] == topRight[1])
            return 1;
        // divide: split into 4 area
        int xStart = bottomLeft[0];
        int xEnd = topRight[0];
        int yStart = bottomLeft[1];
        int yEnd = topRight[1];
        int xMid = xStart + (xEnd - xStart) / 2;
        int yMid = yStart + (yEnd - yStart) / 2;
        // conquer: define topRight and bottomLeft for each area and start recursion
        var bl = CountShips(sea, new int[] { xMid, yMid }, bottomLeft);
        var br = CountShips(sea, new int[] { xEnd, yMid }, new int[] { xMid + 1, yStart });
        var tl = CountShips(sea, new int[] { xMid, yEnd }, new int[] { xStart, yMid + 1 });
        var tr = CountShips(sea, topRight, new int[] { xMid + 1, yMid + 1 });
        // combine: sum up counts of 4 area
        return bl + br + tl + tr;
    }
}
