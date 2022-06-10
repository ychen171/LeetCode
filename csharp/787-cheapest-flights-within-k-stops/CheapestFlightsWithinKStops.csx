public class Solution
{
    // Dijkstra's Algorithm | BFS + PriorityQueue
    // Time: O(V^2 * log V)
    // Space: O(V^2)
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k)
    {
        // build the graph using ajacency matrix
        var graph = new int[n][];
        for (int i = 0; i < n; i++)
            graph[i] = new int[n];
        foreach (var flight in flights)
        {
            var from = flight[0];
            var to = flight[1];
            var price = flight[2];
            graph[from][to] = price;
        }
        // create the min cost array and min stop array
        var minCost = new int[n];
        var minStop = new int[n];
        for (int i = 0; i < n; i++)
        {
            minCost[i] = int.MaxValue;
            minStop[i] = int.MaxValue;
        }
        minCost[src] = 0;
        minStop[src] = 0;

        // BFS + PriorityQueue
        // PQ contains [node, cost, stop], comparer
        var pq = new PriorityQueue<int[], int>();
        int[] curr = new int[] { src, 0, 0 };
        pq.Enqueue(curr, 0);
        while (pq.Count != 0)
        {
            curr = pq.Dequeue();
            int node = curr[0];
            int cost = curr[1];
            int stop = curr[2];
            if (node == dst) // reach dst, return cost
                return cost;
            if (stop == k + 1) // no stop left, skip
                continue;
            // examine all neighbors
            for (int nei = 0; nei < n; nei++)
            {
                // invalid, no edge
                if (graph[node][nei] == 0)
                    continue;
                var newCost = cost + graph[node][nei];
                var newStop = stop + 1;
                // less cost, update min cost and enqueue
                if (newCost < minCost[nei])
                {
                    minCost[nei] = newCost;
                    minStop[nei] = newStop;
                    pq.Enqueue(new int[] { nei, newCost, newStop }, newCost);
                }
                // less stop, update min stop and enqueue
                else if (newStop < minStop[nei])
                {
                    minCost[nei] = newCost;
                    minStop[nei] = newStop;
                    pq.Enqueue(new int[] { nei, newCost, newStop }, newCost);
                }
            }
        }

        return minCost[dst] == int.MaxValue ? -1 : minCost[dst];
    }
}
