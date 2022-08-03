public class Solution
{
    // Time: O(V + E)
    // Space: O(V)
    bool valid = true;
    public bool PossibleBipartition(int n, int[][] dislikes)
    {
        // bipartite graph
        // create graph, undirected, unweighted
        var graph = new Dictionary<int, List<int>>();
        foreach (var dislike in dislikes)
        {
            int a = dislike[0];
            int b = dislike[1];
            // a dislikes b
            if (!graph.ContainsKey(a))
                graph[a] = new List<int>();
            graph[a].Add(b);
            if (!graph.ContainsKey(b))
                graph[b] = new List<int>();
            graph[b].Add(a);
        }
        // DFS to color all nodes
        var color = new bool[n + 1];
        var visited = new bool[n + 1];
        for (int i = 1; i <= n; i++)
        {
            DFS(graph, color, visited, i);
            if (!valid)
                return false;
        }

        return true;
    }

    private void DFS(Dictionary<int, List<int>> graph, bool[] color, bool[] visited, int curr)
    {
        // base case
        if (!valid)
            return;
        if (visited[curr])
            return;

        // recursive case
        visited[curr] = true;
        if (!graph.ContainsKey(curr))
            return;
        foreach (var nei in graph[curr])
        {
            if (visited[nei])
            {
                if (color[nei] == color[curr])
                {
                    valid = false;
                    return;
                }
            }
            else // !visited[nei]
            {
                color[nei] = !color[curr];
                DFS(graph, color, visited, nei);
            }
        }
    }

    // BFS
    // Time: O(V + E)
    // Space: O(V)
    public bool PossibleBipartition1(int n, int[][] dislikes)
    {
        // create graph, undirected, unweighted
        var graph = new Dictionary<int, List<int>>();
        foreach (var dislike in dislikes)
        {
            int a = dislike[0];
            int b = dislike[1];
            if (!graph.ContainsKey(a))
                graph[a] = new List<int>();
            graph[a].Add(b);
            if (!graph.ContainsKey(b))
                graph[b] = new List<int>();
            graph[b].Add(a);
        }
        // BFS to color all nodes
        var color = new bool[n + 1];
        var visited = new bool[n + 1];
        var queue = new Queue<int>();
        for (int i = 1; i <= n; i++)
        {
            if (visited[i])
                continue;
            queue.Enqueue(i);
            visited[i] = true;
            while (queue.Count != 0)
            {
                var curr = queue.Dequeue();
                if (!graph.ContainsKey(curr))
                    continue;

                foreach (var nei in graph[curr])
                {
                    if (visited[nei])
                    {
                        if (color[nei] == color[curr])
                            return false;
                    }
                    else // !visited[nei]
                    {
                        visited[nei] = true;
                        color[nei] = !color[curr];
                        queue.Enqueue(nei);
                    }
                }
            }
        }
        return true;
    }
}
