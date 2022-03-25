
public class Solution
{
    // Graph | DFS | Top-down
    // Time: O(n^2)
    // Space: O(n)
    public int[] FindRedundantConnection(int[][] edges)
    {
        // construct graph using dictionary
        var graph = new Dictionary<int, List<int>>();
        var visited = new HashSet<int>();
        foreach (var edge in edges)
        {
            var source = edge[0];
            var target = edge[1];
            if (!graph.ContainsKey(source))
                graph[source] = new List<int>();
            if (!graph.ContainsKey(target))
                graph[target] = new List<int>();
            // before we build the edge between source and target
            // if source can reach target from a non-visited way, return
            visited.Clear();
            if (DFS(graph, visited, source, target))
                return edge;
            // build the graph and continue
            graph[source].Add(target);
            graph[target].Add(source);
        }

        return null;
    }

    private bool DFS(Dictionary<int, List<int>> graph, HashSet<int> visited, int source, int target)
    {
        // base case
        if (visited.Contains(source))
            return false;
        visited.Add(source);
        if (source == target)
            return true;
        
        // traverse neighbors
        foreach (var nei in graph[source])
        {
            if (DFS(graph, visited, nei, target))
                return true;
        }
        return false;
    }

    // private bool DFS(Dictionary<int, List<int>> graph, HashSet<int> visited, int source, int target)
    // {
    //     if (visited.Add(source))
    //     {
    //         if (source == target)
    //             return true;
    //         foreach (var nei in graph[source])
    //         {
    //             if (DFS(graph, visited, nei, target))
    //                 return true;
    //         }
    //     }
    //     return false;
    // }
}
