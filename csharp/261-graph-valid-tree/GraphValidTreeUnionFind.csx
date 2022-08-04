public class Solution
{
    // Union Find
    // Time: O(V + E)
    // Space: O(V)
    public bool ValidTree(int n, int[][] edges)
    {
        var uf = new UnionFind(n);
        foreach (var edge in edges)
        {
            int a = edge[0];
            int b = edge[1];
            if (uf.Connected(a, b))
                return false;

            uf.Union(a, b);
        }

        return uf.Count == 1;
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
