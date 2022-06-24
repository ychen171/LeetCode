public class Solution
{
    // Time: O(N^2)
    // Space: O(N^2)
    public int MaximalNetworkRank(int n, int[][] roads)
    {
        // build graph and indegree
        var graph = new Dictionary<int, HashSet<int>>();
        var indegree = new int[n];
        foreach (var road in roads)
        {
            var a = road[0];
            var b = road[1];
            if (!graph.ContainsKey(a))
                graph[a] = new HashSet<int>();
            graph[a].Add(b);
            if (!graph.ContainsKey(b))
                graph[b] = new HashSet<int>();
            graph[b].Add(a);

            indegree[a]++;
            indegree[b]++;
        }

        int ans = 0;
        for (int a = 0; a < n; a++)
        {
            for (int b = a + 1; b < n; b++)
            {
                bool isConnected = graph.ContainsKey(a) && graph[a].Contains(b);
                var rank = indegree[a] + indegree[b];
                if (isConnected)
                    rank--;

                ans = Math.Max(ans, rank);

            }
        }

        return ans;
    }
}

var s = new Solution();
var n = 4;
var roads = new int[][] { new int[] { 0, 1 }, new int[] { 0, 3 }, new int[] { 1, 2 }, new int[] { 1, 3 } };
var result = s.MaximalNetworkRank(n, roads);
Console.WriteLine(result);
