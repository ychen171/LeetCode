public class Solution
{
    // Minimum Spanning Tree | Union Find
    // Time: O(E log E)
    // Space: O(V)
    public int MinimumCost(int n, int[][] connections)
    {
        // minimum spanning tree
        // undirected, weighted graph

        // sort edges by weight
        Array.Sort(connections, (a, b) => a[2] - b[2]);
        // union find  [1, n]
        var uf = new UnionFind(n + 1);
        int mst = 0;
        foreach (var connection in connections)
        {
            int a = connection[0];
            int b = connection[1];
            int weight = connection[2];
            if (uf.Connected(a, b))
                continue;
            uf.Union(a, b);
            mst += weight;
        }

        if (uf.Count != 2) return -1;
        return mst;
    }

}

public class UnionFind
{
    private int[] parent;
    public int Count { get; private set; }
    public UnionFind(int n)
    {
        parent = new int[n];
        for (int i = 0; i < n; i++)
            parent[i] = i;
        Count = n;
    }

    public void Union(int p, int q)
    {
        int rootP = Find(p);
        int rootQ = Find(q);
        if (rootP == rootQ)
            return;
        parent[rootP] = rootQ;
        Count--;
    }

    public int Find(int p)
    {
        if (parent[p] != p)
            parent[p] = Find(parent[p]);
        return parent[p];
    }

    public bool Connected(int p, int q)
    {
        int rootP = Find(p);
        int rootQ = Find(q);
        return rootP == rootQ;
    }
}