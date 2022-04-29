public class Solution
{
    // BFS traversal
    // Time: O(V + E)
    // Space: O(V)
    public bool IsBipartite(int[][] graph)
    {
        int n = graph.Length;
        int[] color = new int[n];
        var queue = new Queue<int>();
        for (int node = 0; node < n; node++)
        {
            if (color[node] == 0) // not visited and not colored
            {
                color[node] = 1; // get colored and mark visited
                queue.Enqueue(node);
                while (queue.Count != 0)
                {
                    var curr = queue.Dequeue();
                    foreach (var nei in graph[curr])
                    {
                        if (color[nei] != 0) // visited and colored
                        {
                            if (color[nei] == color[curr]) // invalid color
                                return false;
                            // skip valid color
                        }
                        else // not visited and not colored
                        {
                            color[nei] = -color[curr]; // get colored and mark visited
                            queue.Enqueue(nei);
                        }

                    }
                }
            }
        }

        return true;
    }
}
