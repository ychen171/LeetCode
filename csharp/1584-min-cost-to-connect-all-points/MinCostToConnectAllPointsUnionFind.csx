public class Solution
{
    // Kruskal's Algorithm | Sorting + Union Find
    // Time: O(n^2 * log n)
    // Space: O(n^2)
    // E = n^2
    public int MinCostConnectPoints(int[][] points)
    {
        int n = points.Length;
        // 1. build all weighted edges: all combinations of two points (direction doesn't matter)
        List<int[]> edgeList = new List<int[]>();
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                var a = points[i];
                var b = points[j];
                int weight = Math.Abs(a[0] - b[0]) + Math.Abs(a[1] - b[1]);
                // use input array index to represent each item/node/point
                int[] edge = new int[] { i, j, weight };
                edgeList.Add(edge);
            }
        }

        // sort edges by weight
        edgeList.Sort((a, b) => a[2] - b[2]);

        // 2. iterate through edges and perform union find on each edge to build Union graph
        var uf = new UnionFind(n);
        int mstCost = 0;
        int edgesUsed = 0;
        for (int i = 0; i < edgeList.Count && edgesUsed < n - 1; i++)
        {
            int p = edgeList[i][0];
            int q = edgeList[i][1];
            int weight = edgeList[i][2];

            if (uf.Connected(p, q))
                continue;
            uf.Union(p, q);
            mstCost += weight;
            edgesUsed++;
        }

        return mstCost;
    }

}
public class UnionFind
{
    private int[] parent;
    public int Count { get; private set; }

    public UnionFind(int size)
    {
        parent = new int[size];
        for (int i = 0; i < size; i++)
            parent[i] = i;
        Count = size;
    }

    public void Union(int p, int q)
    {
        int rootP = Find(p);
        int rootQ = Find(q);

        // p and q already belong to same group
        if (p == q)
            return;

        parent[rootP] = rootQ;
        Count--;
    }
    public int Find(int p)
    {
        // path compression
        if (parent[p] != p)
            parent[p] = Find(parent[p]);

        // return the root of the group, representing the group
        return parent[p];
    }

    public bool Connected(int p, int q)
    {
        int rootP = Find(p);
        int rootQ = Find(q);
        return rootP == rootQ;
    }
}
