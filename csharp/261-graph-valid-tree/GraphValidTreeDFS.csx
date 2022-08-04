public class Solution
{
    // DFS 
    // Time: O(V + E)
    // Space: O(V + E)
    public bool ValidTree(int n, int[][] edges)
    {
        // create graph / array, undirected, unweighted
        var graph = new List<int>[n];
        for (int i = 0; i < n; i++)
            graph[i] = new List<int>();
        foreach (var edge in edges)
        {
            int a = edge[0];
            int b = edge[1];
            graph[a].Add(b);
            graph[b].Add(a);
        }

        // DFS to determine if it is valid tree:
        // all nodes are connected
        // no cycle
        var visited = new HashSet<int>();
        var onPath = new HashSet<int>();
        DFS(graph, visited, onPath, -1, 0);
        return !hasCycle && visited.Count == n;
    }

    bool hasCycle = false;
    public void DFS(List<int>[] graph, HashSet<int> visited, HashSet<int> onPath, int prev, int curr)
    {
        // base case
        if (onPath.Contains(curr))
        {
            hasCycle = true;
            return;
        }
        if (hasCycle || visited.Contains(curr))
            return;

        // recursive case
        visited.Add(curr);
        onPath.Add(curr);
        foreach (var nei in graph[curr])
        {
            if (nei == prev) // prevent it from going back / trival cycle
                continue;
            DFS(graph, visited, onPath, curr, nei);
        }
        onPath.Remove(curr);
    }
}
