public class Solution
{
    // Union Find
    // Time: O(V + E)
    // Space: O(V + E)
    public int NumberOfGoodPaths(int[] vals, int[][] edges)
    {
        /*
            create graph / adjacency list, to only store the nodes which are less than or equal to the curr node
            create map / sorted dictionary to store nodes with same value, key is ordered in ascending order
            union find to create groups
            count the number of good paths for each groups

            vals    1   3   2   1   3
            idxs    0   1   2   3   4
            edges   0,1     0,2     2,3     2,4
        */
        int ans = 0;

        var graph = new Dictionary<int, List<int>>();
        foreach (var edge in edges)
        {
            var u = edge[0]; // index
            var v = edge[1]; // index
            if (vals[u] >= vals[v])
            {
                if (!graph.ContainsKey(u))
                    graph[u] = new List<int>();
                graph[u].Add(v);
            }
            else
            {
                if (!graph.ContainsKey(v))
                    graph[v] = new List<int>();
                graph[v].Add(u);
            }
        }

        var valueToIndex = new SortedDictionary<int, List<int>>();
        int n = vals.Length;
        for (int i = 0; i < vals.Length; i++)
        {
            var val = vals[i];
            if (!valueToIndex.ContainsKey(val))
                valueToIndex[val] = new List<int>();
            valueToIndex[val].Add(i);
        }

        var uf = new UF(n);
        foreach (var kv in valueToIndex)
        {
            var value = kv.Key;
            var indexes = kv.Value;
            // for the target value, union the nodes whose value <= target value
            foreach (var u in indexes)
            {
                if (!graph.ContainsKey(u))
                    continue;
                foreach (var v in graph[u])
                    uf.Union(u, v);

            }
            // for the target value, after union,
            // for each union group, count the number of target value (Max) in each group
            var groupSize = new Dictionary<int, int>();
            foreach (var u in indexes)
            {
                var rootU = uf.Find(u);
                groupSize[rootU] = groupSize.GetValueOrDefault(rootU, 0) + 1;
            }

            // add single-node paths
            ans += indexes.Count;
            // add multi-node paths
            foreach (var size in groupSize.Values)
            {
                ans += size * (size - 1) / 2;
            }
        }

        return ans;
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
        var rootP = Find(p);
        var rootQ = Find(q);
        if (rootP == rootQ)
            return;
        parents[rootP] = rootQ;
        Count--;
    }

    public int Find(int x)
    {
        if (parents[x] != x)
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
