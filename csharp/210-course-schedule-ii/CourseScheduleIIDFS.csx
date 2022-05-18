public class Solution
{
    // TODO | Doesn't work
    // Topological Sort | DFS
    public int[] FindOrder(int numCourses, int[][] prerequisites)
    {
        // build the graph
        var graph = new Dictionary<int, List<int>>();
        foreach (var pair in prerequisites)
        {
            var a = pair[0];
            var b = pair[1];
            if (!graph.ContainsKey(b))
                graph[b] = new List<int>();
            graph[b].Add(a);
        }

        // DFS, traverse all courses
        var learned = new HashSet<int>();
        var stack = new Stack<int>();
        for (int i = 0; i < numCourses; i++)
        {
            if (learned.Contains(i))
                continue;
            DFS(graph, numCourses, learned, i, stack);
        }

        if (stack.Count == 0)
            return new int[] { };
        var result = new List<int>();
        while (stack.Count != 0)
        {
            result.Add(stack.Pop());
        }

        return result.ToArray();
    }

    private void DFS(Dictionary<int, List<int>> graph, int numCourses, HashSet<int> learned, int curr, Stack<int> stack)
    {
        // base case
        if (learned.Count == numCourses)
            return;
        if (learned.Contains(curr))
            return;

        learned.Add(curr);

        // recursive case
        if (graph.ContainsKey(curr))
        {
            foreach (var nei in graph[curr])
            {
                if (learned.Contains(nei))
                    continue;
                DFS(graph, numCourses, learned, nei, stack);
            }
        }

        stack.Push(curr);
    }
}
