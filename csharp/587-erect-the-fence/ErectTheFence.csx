public class Solution
{
    public int[][] OuterTrees(int[][] trees)
    {
        Array.Sort(trees, (p, q) => q[0] == p[0] ? q[1] - p[1] : q[0] - p[0]);
        var hull = new Stack<int[]>();
        int n = trees.Length;
        for (int i = 0; i < n; i++)
        {
            while (hull.Count >= 2)
            {
                int[] q = hull.Pop();
                int[] p = hull.Peek();
                if (Orientation(p, q, trees[i]) <= 0)
                {
                    hull.Push(q);
                    break;
                }
            }
            hull.Push(trees[i]);
        }
        hull.Pop();
        for (int i = n - 1; i >= 0; i--)
        {
            while (hull.Count >= 2)
            {
                int[] q = hull.Pop();
                int[] p = hull.Peek();
                if (Orientation(p, q, trees[i]) <= 0)
                {
                    hull.Push(q);
                    break;
                }
            }
            hull.Push(trees[i]);
        }
        // remove redundant elements from the stack
        var result = new HashSet<int[]>(hull);
        return result.ToArray();
    }

    public int Orientation(int[] p, int[] q, int[] r)
    {
        return (q[1] - p[1]) * (r[0] - q[0]) - (q[0] - p[0]) * (r[1] - q[1]);
    }
}
// Monotone Chain
// Time: O(n log n)
// Space: O(n)