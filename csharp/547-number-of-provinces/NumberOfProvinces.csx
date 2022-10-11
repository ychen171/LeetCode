public class Solution
{
    public int FindCircleNum(int[][] isConnected)
    {
        int n = isConnected.Length;
        var edges = new List<int[]>();
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (isConnected[i][j] == 1)
                {
                    edges.Add(new int[] { i, j });
                }
            }
        }

        var uf = new UF(n);
        foreach (var edge in edges)
        {
            var i = edge[0];
            var j = edge[1];
            uf.Union(i, j);
        }
        return uf.Count;
    }
}

public class UF
{
    int[] parents;
    public int Count { get; private set; }
    public UF(int n)
    {
        parents = new int[n];
        for (int i = 0; i < n; i++)
            parents[i] = i;
        Count = n;
    }

    public void Union(int p, int q)
    {
        if (AreConnected(p, q))
            return;
        var rootP = Find(p);
        var rootQ = Find(q);
        parents[rootP] = parents[rootQ];
        Count--;
    }

    public int Find(int x)
    {
        if (parents[x] == x)
            return x;
        parents[x] = Find(parents[x]);
        return parents[x];
    }

    public bool AreConnected(int p, int q)
    {
        var rootP = Find(p);
        var rootQ = Find(q);
        return rootP == rootQ;
    }
}