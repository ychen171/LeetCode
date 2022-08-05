public class Solution
{
    // Dijkstra's Algo
    // Time: O(E log V)
    // Space: O(V + E)
    public double MaxProbability(int n, int[][] edges, double[] succProb, int start, int end)
    {
        // build graph, weighed, directed
        var graph = new List<KeyValuePair<int, double>>[n]; // graph[from] = list of [to, weight]
        for (int i = 0; i < n; i++)
            graph[i] = new List<KeyValuePair<int, double>>();
        for (int i = 0; i < edges.Length; i++)
        {
            var edge = edges[i];
            int a = edge[0];
            int b = edge[1];
            graph[a].Add(new KeyValuePair<int, double>(b, succProb[i]));
            graph[b].Add(new KeyValuePair<int, double>(a, succProb[i]));
        }

        // Dijkstra to find max
        // reverse pq and conditions
        var probFromStart = new double[n];
        for (int i = 0; i < n; i++)
            probFromStart[i] = -1;
        var pq = new PriorityQueue<KeyValuePair<int, double>, double>(); // [node, probFromStart], probFromStart
        // from start to end
        probFromStart[start] = 1;
        // reversed PQ, starting from big to small
        pq.Enqueue(new KeyValuePair<int, double>(start, 1), -1);

        while (pq.Count != 0)
        {
            var curr = pq.Dequeue();
            var currNode = curr.Key;
            var currProbFromStart = curr.Value;
            if (currNode == end)
                return currProbFromStart;

            if (currProbFromStart < probFromStart[currNode]) // reversed condition
                continue;

            foreach (var nei in graph[currNode])
            {
                var neiNode = nei.Key;
                var neiProb = nei.Value;
                var neiProbFromStart = currProbFromStart * neiProb;
                if (neiProbFromStart > probFromStart[neiNode]) // reversed condition
                {
                    probFromStart[neiNode] = neiProbFromStart;
                    pq.Enqueue(new KeyValuePair<int, double>(neiNode, neiProbFromStart), -neiProbFromStart);
                }
            }
        }

        return 0.0;
    }
}
