public class Solution
{
    // DFS Traversal
    // Time: O(V + E)
    // Space: O(V + E)
    public int CountComponents(int n, int[][] edges)
    {
        // create graph/array, undirected, unweighted
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
        // DFS, count the number of DFS calls
        int count = 0;
        var visited = new bool[n];
        for (int i = 0; i < n; i++)
        {
            if (visited[i])
                continue;
            DFS(graph, visited, i);
            count++;
        }

        return count;
    }

    private void DFS(List<int>[] graph, bool[] visited, int curr)
    {
        // base case
        if (visited[curr])
            return;

        // recursive case
        visited[curr] = true;
        foreach (var nei in graph[curr])
        {
            DFS(graph, visited, nei);
        }
    }
}
