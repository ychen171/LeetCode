public class Solution
{
    // Union Find
    // Time: O(E)
    // Space: O(V)
    public int CountComponents(int n, int[][] edges)
    {
        var uf = new UnionFind(n);
        foreach (var edge in edges)
        {
            int p = edge[0];
            int q = edge[1];
            uf.Union(p, q);
        }

        return uf.Count;
    }
}

public class UnionFind
{
    // Space: O(n)
    private int[] parent;
    public int Count { get; private set; }
    // Time: O(n)
    public UnionFind(int n)
    {
        Count = n;
        parent = new int[n];
        for (int i = 0; i < n; i++)
            parent[i] = i;
    }

    // Time: O(1)
    public void Union(int p, int q)
    {
        var rootP = Find(p);
        var rootQ = Find(q);
        if (rootP == rootQ)
            return;

        parent[rootP] = rootQ;
        Count--;
    }

    // Time: O(1)
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
