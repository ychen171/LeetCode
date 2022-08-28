public class Solution
{
    // Topological Sort
    // Time: O(m + n + k + k^2)
    // Space: O(k + k^2)
    // in worst: E = k^2, V = k
    public int[][] BuildMatrix(int k, int[][] rowConditions, int[][] colConditions)
    {
        // sort on rowConditions   from above to below
        var rowGraph = new Dictionary<int, HashSet<int>>();
        var rowIndegree = new Dictionary<int, int>();
        foreach (var pair in rowConditions)
        {
            int above = pair[0];
            int below = pair[1];
            if (!rowGraph.ContainsKey(above))
                rowGraph[above] = new HashSet<int>();
            rowGraph[above].Add(below);
        }
        foreach (var kv in rowGraph)
        {
            var num = kv.Key;
            var neiSet = kv.Value;
            foreach (var nei in neiSet)
                rowIndegree[nei] = rowIndegree.GetValueOrDefault(nei, 0) + 1;
        }
        // sort on colConditions   from left to right
        var colGraph = new Dictionary<int, HashSet<int>>();
        var colIndegree = new Dictionary<int, int>();
        foreach (var pair in colConditions)
        {
            int left = pair[0];
            int right = pair[1];
            if (!colGraph.ContainsKey(left))
                colGraph[left] = new HashSet<int>();
            colGraph[left].Add(right);
        }
        foreach (var kv in colGraph)
        {
            var num = kv.Key;
            var neiSet = kv.Value;
            foreach (var nei in neiSet)
                colIndegree[nei] = colIndegree.GetValueOrDefault(nei, 0) + 1;
        }

        var rowNums = TopoSort(k, rowGraph, rowIndegree);
        var colNums = TopoSort(k, colGraph, colIndegree);
        // has cycle, return empty matrix
        if (rowNums.Count < k || colNums.Count < k)
            return new int[0][];
        var numToColIndex = new Dictionary<int, int>();
        for (int i = 0; i < k; i++)
        {
            int num = colNums[i];
            numToColIndex[num] = i;
        }

        var matrix = new int[k][];
        for (int r = 0; r < k; r++)
        {
            matrix[r] = new int[k];
            int num = rowNums[r];
            int c = numToColIndex[num];
            matrix[r][c] = num;
        }

        return matrix;
    }

    public List<int> TopoSort(int k, Dictionary<int, HashSet<int>> graph, Dictionary<int, int> indegree)
    {
        var ans = new List<int>();
        var queue = new Queue<int>();
        for (int num = 1; num <= k; num++)
        {
            if (!indegree.ContainsKey(num) || indegree[num] == 0)
                queue.Enqueue(num);
        }

        while (queue.Count != 0)
        {
            var curr = queue.Dequeue();
            ans.Add(curr);
            if (!graph.ContainsKey(curr))
                continue;
            foreach (var nei in graph[curr])
            {
                indegree[nei]--;
                if (indegree[nei] == 0)
                    queue.Enqueue(nei);
            }
        }

        return ans;
    }
}
