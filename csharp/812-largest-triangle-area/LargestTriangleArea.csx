public class Solution
{
    // Geometry | Math
    // Time: O(n^3)
    // Space: O(1)
    public double LargestTriangleArea(int[][] points)
    {
        double result = 0;
        int n = points.Length;
        int[] a, b, c;
        for (int i = 0; i < n - 2; i++)
        {
            a = points[i];
            for (int j = i + 1; j < n - 1; j++)
            {
                b = points[j];
                for (int k = j + 1; k < n; k++)
                {
                    c = points[k];
                    var area = 0.5 * Math.Abs(a[0] * b[1] + b[0] * c[1] + c[0] * a[1] - a[0] * c[1] - c[0] * b[1] - b[0] * a[1]);
                    result = Math.Max(result, area);
                }
            }
        }
        return result;
    }
    // return perimeter, which is wrong. need to return area
    // Time: O(n^2 log n)
    // Space: O(n^2)
    public double LargestTriangleArea1(int[][] points)
    {
        // compute length of each two points
        var lens = new List<double>();
        int n = points.Length;
        for (int i = 0; i < n; i++)
        {
            int xi = points[i][0];
            int yi = points[i][1];
            for (int j = i + 1; j < n; j++)
            {
                int xj = points[j][0];
                int yj = points[j][1];
                var len = Math.Sqrt(Math.Pow(xi - xj, 2) + Math.Pow(yi - yj, 2));
                lens.Add(len);
            }
        }
        // sort length list
        lens.Sort();
        // greedy to the largest triangle
        double x, y, z;
        for (int i = lens.Count - 1; i >= 2; i--)
        {
            // lens[i-2] <= lens[i-1] <= lens[i]
            x = lens[i - 2];
            y = lens[i - 1];
            z = lens[i];
            if (x + y > z)
                return x + y + z;
        }
        return 0;
    }
}
