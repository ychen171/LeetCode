public class Solution
{
    // BFS
    // Time: O(n)
    // Space: O(n)
    int diameter;
    Dictionary<int, List<int>> graph;
    Dictionary<int, int> indegree;
    public int TreeDiameter(int[][] edges)
    {
        // edge case
        if (edges.Length == 0)
            return 0;
        // build graph and indegree map
        graph = new Dictionary<int, List<int>>();
        indegree = new Dictionary<int, int>();
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
        // starting from random node, BFS to find the farthest node,
        // starting from the found node, BFS to find another farthest node
        // the level in second BFS is diameter
        var randomNode = indegree.Keys.First();
        var temp = BFS(randomNode);
        var root = temp[0];
        var result = BFS(root);
        return result[1] - 1;
    }

    private int[] BFS(int root)
    {
        var queue = new Queue<int>();
        var visited = new HashSet<int>();
        var curr = root;
        queue.Enqueue(curr);
        visited.Add(curr);
        int level = 0;
        while (queue.Count != 0)
        {
            int levelLen = queue.Count;
            for (int i = 0; i < levelLen; i++)
            {
                curr = queue.Dequeue();

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

        return new int[] { curr, level };
    }
}
