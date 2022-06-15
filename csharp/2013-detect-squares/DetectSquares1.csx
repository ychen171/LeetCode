public class DetectSquares
{
    // Space: O(N)
    // N is the total number of calls
    int[,] countArray;
    List<int[]> pointList = new List<int[]>();
    public DetectSquares()
    {
        countArray = new int[1001, 1001];
        pointList = new List<int[]>();
    }

    // Time: O(1)
    public void Add(int[] point)
    {
        int x = point[0];
        int y = point[1];
        countArray[x, y]++;
        pointList.Add(point);
    }

    // Time: O(N)
    // N is the total number of calls
    public int Count(int[] point)
    {
        int x1 = point[0];
        int y1 = point[1];
        int res = 0;

        foreach (int[] p3 in pointList)
        {
            int x3 = p3[0];
            int y3 = p3[1];
            // skip empty square or invalid square
            if (x1 == x3 || y1 == y3 || Math.Abs(x1 - x3) != Math.Abs(y1 - y3))
                continue;

            res += countArray[x1, y3] * countArray[x3, y1];
        }

        return res;
    }
}

/**
 * Your DetectSquares object will be instantiated and called as such:
 * DetectSquares obj = new DetectSquares();
 * obj.Add(point);
 * int param_2 = obj.Count(point);
 */