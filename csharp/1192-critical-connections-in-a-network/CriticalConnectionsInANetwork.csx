public class Solution
{
    // DFS
    // Time: O(V + E)
    // Space: O(V + E)
    private Dictionary<int, List<int>> graph;
    private Dictionary<int, int> rank;
    private HashSet<KeyValuePair<int, int>> edgeSet;
    public IList<IList<int>> CriticalConnections(int n, IList<IList<int>> connections)
    {
        FormGraph(n, connections);
        DFS(0, 0);

        var result = new List<IList<int>>();
        foreach (var pair in edgeSet)
        {
            result.Add(new List<int>() { pair.Key, pair.Value });
        }

        return result;
    }

    private void FormGraph(int n, IList<IList<int>> connections)
    {
        graph = new Dictionary<int, List<int>>();
        rank = new Dictionary<int, int>();
        edgeSet = new HashSet<KeyValuePair<int, int>>();

        // Default rank for unvisited nodes is int.Min
        for (int i = 0; i < n; i++)
        {
            graph[i] = new List<int>();
            rank[i] = int.MinValue;
        }

        foreach (var edge in connections)
        {
            // bidirectional edges
            int u = edge[0];
            int v = edge[1];
            graph[u].Add(v);
            graph[v].Add(u);

            int sortedU = Math.Min(u, v);
            int sortedV = Math.Max(u, v);
            var pair = new KeyValuePair<int, int>(sortedU, sortedV);
            edgeSet.Add(pair);
        }
    }

    private int DFS(int curr, int currRank)
    {
        // base case
        // this node is already visited. Simply return the rank
        if (rank[curr] != int.MinValue)
            return rank[curr];
        
        // update the rank of curr node
        rank[curr] = currRank;       
        // minRank is the rank for recursive call
        // starting from currRank + 1
        int minRank = currRank + 1;

        // recursive case
        foreach (int nei in graph[curr])
        {
            // skip the unvisted node and parent node
            int neiRank = rank[nei];
            if (neiRank != int.MinValue && neiRank == currRank - 1)
                continue;
            
            int recursiveRank = DFS(nei, currRank + 1);
            // step 1, check if this edge needs to be discarded
            if (recursiveRank <= currRank)
            {
                int sortedU = Math.Min(curr, nei);
                int sortedV = Math.Max(curr, nei);
                var pair = new KeyValuePair<int, int>(sortedU, sortedV);
                edgeSet.Remove(pair);
            }
            // step 2, update the minRank if needed
            minRank = Math.Min(minRank, recursiveRank);
        }

        return minRank;
    }
}
