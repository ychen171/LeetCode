public class Solution
{
    // BFS traversal
    // Time: O(V + E)
    // Space: O(V)
    public bool IsBipartite(int[][] graph)
    {
        int n = graph.Length;
        var color = new bool[n]; // two colors
        var visited = new bool[n];
        var queue = new Queue<int>();
        for (int node = 0; node < n; node++)
        {
            if (visited[node]) // visited
                continue;

            visited[node] = true; // mark visited
            queue.Enqueue(node);
            while (queue.Count != 0)
            {
                var curr = queue.Dequeue();
                foreach (var nei in graph[curr])
                {
                    if (visited[nei]) // visited
                    {
                        if (color[nei] == color[curr]) // invalid color
                            return false;
                        // skip valid color
                    }
                    else // not visited
                    {
                        color[nei] = !color[curr]; // get colored
                        visited[nei] = true;
                        queue.Enqueue(nei);
                    }
                }
            }
        }
        return true;
    }

    // DFS
    // Time: O(V + E)
    // Space: O(V)
    public bool IsBipartite1(int[][] graph)
    {
        int n = graph.Length;
        var color = new bool[n]; // two colors
        var visited = new bool[n];
        for (int i = 0; i < n; i++)
        {
            if (!DFS(graph, color, visited, i))
                return false;
        }

        return true;
    }

    private bool DFS(int[][] graph, bool[] color, bool[] visited, int curr)
    {
        // base case
        if (visited[curr])
            return true;

        // recursive case
        visited[curr] = true;

        bool ans = true;
        foreach (var nei in graph[curr])
        {
            if (visited[nei])
            {
                if (color[nei] == color[curr])
                {
                    ans = false;
                    break;
                }
            }
            else
            {
                color[nei] = !color[curr];
                if (!DFS(graph, color, visited, nei))
                {
                    ans = false;
                    break;
                }
            }
        }

        return ans;
    }
}
