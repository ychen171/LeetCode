public class Solution
{
    // DFS
    // Time: O(n)
    // Space: O(n)
    int diameter;
    Dictionary<int, List<int>> graph;
    public int TreeDiameter(int[][] edges)
    {
        // edge case
        if (edges.Length == 0)
            return 0;
        // build graph
        graph = new Dictionary<int, List<int>>();
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

        }
        // starting from each node a, find every leaf node and its distance, 
        // add up top 2 distance to find the max diamater
        DFS(graph.Keys.First(), new HashSet<int>());
        return diameter;
    }

    // return the max distance, starting from the node to its leaf nodes
    private int DFS(int node, HashSet<int> visited)
    {
        // base case
        if (!graph.ContainsKey(node))
            return -1;
        if (visited.Contains(node))
            return -1;
        // recursive case
        visited.Add(node);
        int topDist1 = 0, topDist2 = 0;
        // topDist1 >= topDist2
        foreach (var nei in graph[node])
        {
            int dist = 0;
            dist = 1 + DFS(nei, visited);
            if (dist > topDist1)
            {
                topDist2 = topDist1;
                topDist1 = dist;
            }
            else if (dist > topDist2)
            {
                topDist2 = dist;
            }
        }
        diameter = Math.Max(diameter, topDist1 + topDist2);
        return topDist1;
    }
}
