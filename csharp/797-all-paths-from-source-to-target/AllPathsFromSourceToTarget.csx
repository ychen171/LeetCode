public class Solution
{
    // DFS | Backtracking
    // Time: O(V * 2^V)
    // Space: O(V)
    public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
    {
        var result = new List<IList<int>>();
        DFS(graph, new List<int>(), 0, result);
        return result;
    }

    private void DFS(int[][] graph, IList<int> path, int curr, IList<IList<int>> result)
    {
        int n = graph.Length;
        // base case
        path.Add(curr);
        if (curr == n - 1)
        {
            result.Add(new List<int>(path));
        }

        // recursive case
        foreach (var nei in graph[curr])
        {
            DFS(graph, path, nei, result);
        }

        path.RemoveAt(path.Count - 1);
    }
}
