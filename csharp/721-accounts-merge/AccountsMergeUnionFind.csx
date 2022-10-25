public class Solution 
{
    // Union Find + Dictionary + Array
    // Time: O(N * K * log (N * K))
    // Space: O(N * K)
    public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts) 
    {
        // create email to index map, email to name map
        var emailToIndex = new Dictionary<string, int>();
        var emailToName = new Dictionary<string, string>();
        foreach (var list in accounts)
        {
            var name = list[0];
            for (int i = 1; i < list.Count; i++)
            {
                var email = list[i];
                if (emailToIndex.ContainsKey(email))
                    continue;
                emailToIndex[email] = emailToIndex.Count;
                emailToName[email] = name;
            }
        }
        // create email array | index to email map
        var emails = new string[emailToIndex.Count];
        foreach (var kv in emailToIndex)
            emails[kv.Value] = kv.Key;
        // create edge list
        var edges = new List<int[]>(); // edge: [index1, index2]
        foreach (var list in accounts)
        {
            int u = emailToIndex[list[1]];
            for (int i = 2; i < list.Count; i++)
            {
                int v = emailToIndex[list[i]];
                edges.Add(new int[]{u, v});
            }
        }
        // UF
        var uf = new UF(emailToIndex.Count);
        foreach (var edge in edges)
        {
            var u = edge[0];
            var v = edge[1];
            uf.Union(u, v);
        }
        // create dict of groups
        var groupDict = new Dictionary<int, List<string>>();
        foreach (var email in emails)
        {
            var root = uf.Find(emailToIndex[email]);
            groupDict[root] = groupDict.GetValueOrDefault(root, new List<string>());
            groupDict[root].Add(email);
        }
        // convert dict of groups to list of groups
        var result = new List<IList<string>>();
        foreach (var kv in groupDict)
        {
            var key = kv.Key;
            var value = kv.Value;
            value.Sort((a, b) => string.CompareOrdinal(a, b)); // sort emails
            var list = new List<string>{emailToName[emails[key]]};
            list.AddRange(value);
            result.Add(list);
        }
        return result;
    }
}

public class UF
{
    private int[] parent;
    public int Count {get; private set;}
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