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
}
