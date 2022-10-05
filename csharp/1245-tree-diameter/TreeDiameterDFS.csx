public class Solution
{
    int diameter;
    Dictionary<int, List<int>> graph;
    Dictionary<int, int> indegree;
    public int TreeDiameter(int[][] edges)
    {
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
        // starting from each node a, find the farthest node b, 
        // then starting from node b, find the farthest node c,
        // the len between b and c is diamter
        // find the max diameter
        foreach (var node in indegree.Keys)
        {
            if (indegree[node] == 1) // unused leaf node
            {
                var visited = new HashSet<int>();
                var onPath = new HashSet<int>();
                DFS(node, visited, onPath);
            }
        }
        return diameter;
    }

    private void DFS(int node, HashSet<int> visited, HashSet<int> onPath)
    {
        // base case
        if (visited.Contains(node))
        {
            return;
        }
        // recursive case
        visited.Add(node);
        onPath.Add(node);
        foreach (var nei in graph[node])
        {
            DFS(nei, visited, onPath);
        }
        if (indegree[node] == 1)
        {
            diameter = Math.Max(diameter, onPath.Count - 1);
        }
        onPath.Remove(node);
    }
}
