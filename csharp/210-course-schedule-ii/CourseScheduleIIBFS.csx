public class Solution
{
    // Topological Sort | BFS
    // Time: O(V + E)
    // Space: O(V + E)
    public int[] FindOrder(int numCourses, int[][] prerequisites)
    {
        // build the graph and incoming edge count
        // [a,b]       b -----> a
        var graph = new Dictionary<int, List<int>>();
        var indegree = new Dictionary<int, int>();
        foreach (var pair in prerequisites)
        {
            var a = pair[0];
            var b = pair[1];
            if (!graph.ContainsKey(b))
                graph[b] = new List<int>();
            graph[b].Add(a);

            indegree[a] = indegree.GetValueOrDefault(a, 0) + 1;
        }

        // BFS to sort node
        var queue = new Queue<int>();
        // add all entry nodes
        for (int i = 0; i < numCourses; i++)
        {
            if (!indegree.ContainsKey(i))
            {
                queue.Enqueue(i);
            }
        }
        // BFS
        var result = new List<int>();
        while (queue.Count != 0)
        {
            var curr = queue.Dequeue();
            result.Add(curr);
            if (!graph.ContainsKey(curr)) // curr is not a prerequisite
                continue;
            foreach (int nei in graph[curr])
            {
                // visit one edge, mark it by reducing the count
                indegree[nei]--;
                // all incoming edges are visited, meaning all prerequisites are meet
                if (indegree[nei] == 0) 
                {
                    queue.Enqueue(nei);
                }
            }
        }

        return result.Count < numCourses ? new int[]{} : result.ToArray();
    }
}
