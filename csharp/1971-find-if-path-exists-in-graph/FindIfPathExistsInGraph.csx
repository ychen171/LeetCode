public class Solution
{
    public bool ValidPath(int n, int[][] edges, int source, int destination)
    {
        var uf = new UF(n);
        foreach (var edge in edges)
            uf.Union(edge[0], edge[1]);
        return uf.AreConnected(source, destination);
    }
}
// Union Find
// Time: O(V + E)
// Space: O(V)
public class UF 
{
    private int[] parent;
    public int Count {get; set;}
    
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
        // base case
        if (parent[x] == x)
            return x;
        // recursive case
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