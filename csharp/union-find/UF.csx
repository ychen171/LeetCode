public class UF
{
    int[] parent;
    public int Count { get; private set; }
    public UF(int n)
    {
        parent = new int[n];
        for (int i = 0; i < n; i++)
            parent[i] = i;
        Count = n;
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