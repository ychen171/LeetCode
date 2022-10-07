public class Solution
{
    // Topological Sort | BFS
    // Time: O(V + E)
    // Space: O(V + E)
    public IList<int> FindMinHeightTrees(int n, int[][] edges)
    {
        // edge case
        if (n < 2)
        {
            return new List<int>() { 0 };
        }
        // build the graph
        var graph = new Dictionary<int, IList<int>>();
        foreach (var edge in edges)
        {
            int a = edge[0];
            int b = edge[1];
            if (!graph.ContainsKey(a))
                graph[a] = new List<int>();
            if (!graph.ContainsKey(b))
                graph[b] = new List<int>();

            graph[a].Add(b);
            graph[b].Add(a);
        }

        // topological sort using BFS
        var queue = new Queue<int>();

        // build the leaf set
        // add the leaves into Queue
        var leafList = new List<int>();
        for (int node = 0; node < n; node++)
        {
            if (!graph.ContainsKey(node))
                continue;
            if (graph[node].Count == 1)
            {
                leafList.Add(node);
                queue.Enqueue(node);
            }
        }
        int remainingCount = n;
        while (remainingCount > 2)
        {
            var levelLen = queue.Count;
            leafList = new List<int>();
            for (int i = 0; i < levelLen; i++)
            {
                var leaf = queue.Dequeue();
                var nei = graph[leaf][0];
                graph.Remove(leaf);
                graph[nei].Remove(leaf);

                if (graph[nei].Count == 1)
                {
                    leafList.Add(nei);
                    queue.Enqueue(nei);
                }
            }
            remainingCount -= levelLen;
        }

        return leafList;
    }

    // BFS | Topological Sort | Adjacency List + Indegree Map
    // Time: O(V + E)
    // Space: O(V + E)
    public IList<int> FindMinHeightTrees1(int n, int[][] edges)
    {
        // edge case
        if (n < 2)
            return new List<int>() { 0 };
        // build graph using adjacency list and indegree map
        var graph = new Dictionary<int, IList<int>>();
        var indegree = new Dictionary<int, int>();
        foreach (var edge in edges)
        {
            var a = edge[0];
            var b = edge[1];
            if (!graph.ContainsKey(a))
                graph[a] = new List<int>();
            graph[a].Add(b);
            if (!graph.ContainsKey(b))
                graph[b] = new List<int>();
            graph[b].Add(a);

            indegree[a] = indegree.GetValueOrDefault(a, 0) + 1;
            indegree[b] = indegree.GetValueOrDefault(b, 0) + 1;
        }
        // BFS Topological Sort
        // starting from indegree[node] == 1
        var queue = new Queue<int>();
        foreach (var node in indegree.Keys)
        {
            if (indegree[node] == 1)
            {
                queue.Enqueue(node);
            }
        }
        // stop when remainingCount <= 2
        var remainingCount = n;
        while (queue.Count != 0 && remainingCount > 2)
        {
            var levelLen = queue.Count;
            for (int i = 0; i < levelLen; i++)
            {
                var curr = queue.Dequeue();
                foreach (var nei in graph[curr])
                {
                    indegree[nei]--;
                    if (indegree[nei] == 1)
                    {
                        queue.Enqueue(nei);
                    }
                }
            }
            remainingCount -= levelLen;
        }
        return queue.ToList();
    }
}
