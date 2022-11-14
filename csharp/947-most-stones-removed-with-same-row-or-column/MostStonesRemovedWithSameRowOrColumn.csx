public class Solution
{
    public int RemoveStones(int[][] stones)
    {
        // create edges
        var edges = new List<int[]>();
        int n = stones.Length;
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                int[] p = stones[i];
                int[] q = stones[j];
                if (p[0] == q[0] || p[1] == q[1])
                {
                    edges.Add(new int[] { i, j });
                }
            }
        }
        // iterate through edges and union find
        var uf = new UF(n);
        foreach (var edge in edges)
        {
            int p = edge[0];
            int q = edge[1];
            uf.Union(p, q);
        }
        return n - uf.Count;
    }
}

public class UF
{
    public int Count { get; private set; }
    public int[] parent;

    public UF(int n)
    {
        Count = n;
        parent = new int[n];
        for (int i = 0; i < n; i++)
            parent[i] = i;
    }

    public void Union(int p, int q)
    {
        if (AreConnected(p, q))
            return;
        var rootP = Find(p);
        var rootQ = Find(q);
        parent[rootP] = rootQ;
        Count--;
    }

    public int Find(int x)
    {
        if (parent[x] == x)
            return x;
        parent[x] = Find(parent[x]);
        return parent[x];
    }

    public bool AreConnected(int p, int q)
    {
        var rootP = Find(p);
        var rootQ = Find(q);
        return rootP == rootQ;
    }
}