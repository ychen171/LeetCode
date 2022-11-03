public class Solution
{
    // BFS
    public int MinMutation(string startGene, string endGene, string[] bank)
    {
        if (bank.Length == 0) return -1;
        // create bankSet
        var bankSet = bank.ToHashSet();
        bankSet.Add(startGene);
        var bankList = bankSet.ToList();
        // build graph
        var graph = new Dictionary<string, List<string>>();
        int n = bankList.Count;
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                var u = bankList[i];
                var v = bankList[j];
                if (!DiffByOne(u, v))
                    continue;
                if (!graph.ContainsKey(u))
                    graph[u] = new List<string>();
                if (!graph.ContainsKey(v))
                    graph[v] = new List<string>();
                graph[u].Add(v);
                graph[v].Add(u);
            }
        }
        // BFS
        // var choices = new char[] { 'A', 'C', 'G', 'T' };
        var queue = new Queue<string>();
        var visited = new HashSet<string>();
        queue.Enqueue(startGene);
        visited.Add(startGene);
        int level = 0;
        while (queue.Count != 0)
        {
            int levelLen = queue.Count;
            for (int i = 0; i < levelLen; i++)
            {
                var curr = queue.Dequeue();
                if (curr == endGene)
                    return level;
                if (!graph.ContainsKey(curr))
                    continue;
                foreach (var nei in graph[curr])
                {
                    if (visited.Contains(nei))
                        continue;
                    queue.Enqueue(nei);
                    visited.Add(nei);
                }
            }
            level++;
        }
        return -1;
    }

    private bool DiffByOne(string u, string v)
    {
        int n = u.Length;
        int diffCount = 0;
        for (int i = 0; i < n; i++)
        {
            if (u[i] != v[i])
                diffCount++;
            if (diffCount > 1)
                return false;
        }
        return diffCount == 1;
    }
}
