public class Solution
{
    // calcalute the area and points
    // Time: O(n)
    // Space: O(n)
    public bool IsRectangleCover(int[][] rectangles)
    {
        int X1 = int.MaxValue, Y1 = int.MaxValue;
        int X2 = int.MinValue, Y2 = int.MinValue;
        var points = new HashSet<string>();
        int actualArea = 0;
        foreach (var item in rectangles)
        {
            int x1 = item[0];
            int y1 = item[1];
            int x2 = item[2];
            int y2 = item[3];
            // calcluate the coordinates for the perfect rectangle
            X1 = Math.Min(X1, x1);
            Y1 = Math.Min(Y1, y1);
            X2 = Math.Max(X2, x2);
            Y2 = Math.Max(Y2, y2);
            // calculate the actual area
            actualArea += (x2 - x1) * (y2 - y1);
            // record the points for the actual shape
            var p1 = $"{x1},{y1}";
            var p2 = $"{x1},{y2}";
            var p3 = $"{x2},{y1}";
            var p4 = $"{x2},{y2}";
            foreach (var p in new string[] { p1, p2, p3, p4 })
            {
                if (points.Contains(p))
                    points.Remove(p);
                else
                    points.Add(p);
            }
        }

        // check if the areas match
        var expectedArea = (X2 - X1) * (Y2 - Y1);
        if (actualArea != expectedArea)
            return false;
        // check if only 4 points left in the actual shape
        if (points.Count != 4)
            return false;
        // check if the 4 points in the actual shape match the 4 points in the expected shape / perfect rectangle
        var P1 = $"{X1},{Y1}";
        var P2 = $"{X1},{Y2}";
        var P3 = $"{X2},{Y1}";
        var P4 = $"{X2},{Y2}";
        foreach (var P in new string[] { P1, P2, P3, P4 })
        {
            if (!points.Contains(P))
                return false;
        }

        return true;
    }
}
