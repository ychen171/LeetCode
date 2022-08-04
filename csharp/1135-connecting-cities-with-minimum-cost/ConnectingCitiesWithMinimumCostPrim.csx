public class Solution
{
    // Minimum Spanning Tree | Prim | Priority Queue
    // Time: O(E log E)
    // Space: O(V)
    public int MinimumCost(int n, int[][] connections)
    {
        // minimum spanning tree
        // undirected, weighted graph
        // create graph
        var graph = new Dictionary<int, List<int[]>>();
        foreach (var edge in connections)
        {
            int x = edge[0];
            int y = edge[1];
            int weight = edge[2];
            if (!graph.ContainsKey(x))
                graph[x] = new List<int[]>();
            if (!graph.ContainsKey(y))
                graph[y] = new List<int[]>();

            graph[x].Add(new int[] { y, weight });
            graph[y].Add(new int[] { x, weight });
        }
        if (graph.Count != n)
            return -1;
        // prim to build MST
        // var prim = new Prim(graph);
        // return prim.AllConnected() ? prim.WeightSum : -1;

        var pq = new PriorityQueue<int[], int>(); // <[node, weight], weight>
        var inMST = new HashSet<int>();
        int cost = 0;
        // start by adding node 1 into empty MST
        pq.Enqueue(new int[] { 1, 0 }, 0);
        while (pq.Count != 0)
        {
            var curr = pq.Dequeue();
            int node = curr[0];
            int weight = curr[1];
            if (inMST.Contains(node))
                continue;
            cost += weight;
            inMST.Add(node);
            if (graph.ContainsKey(node))
            {
                foreach (var nei in graph[node])
                {
                    if (inMST.Contains(nei[0]))
                        continue;
                    pq.Enqueue(nei, nei[1]);
                }
            }
        }

        return inMST.Count == n ? cost : -1;
    }

}

public class Prim
{
    private PriorityQueue<int[], int> pq;
    private Dictionary<int, List<int[]>> graph;
    private HashSet<int> inMST;
    public int WeightSum { get; private set; }
    public Prim(Dictionary<int, List<int[]>> graph)
    {
        this.graph = graph;
        this.pq = new PriorityQueue<int[], int>();
        this.inMST = new HashSet<int>();
        WeightSum = 0;
        // start from 1
        inMST.Add(1);
        Cut(1);
        while (pq.Count != 0)
        {
            var node = pq.Dequeue();
            int to = node[0];
            int weight = node[1];
            if (inMST.Contains(to))
                continue;

            WeightSum += weight;
            inMST.Add(to);
            Cut(to);
        }
    }

    private void Cut(int node)
    {
        if (!graph.ContainsKey(node))
            return;
        foreach (var nei in graph[node])
        {
            int to = nei[0];
            int weight = nei[1];
            if (inMST.Contains(to))
                continue;
            pq.Enqueue(nei, weight);
        }
    }

    public bool AllConnected()
    {
        for (int i = 1; i <= graph.Count; i++)
        {
            if (!inMST.Contains(i))
                return false;
        }
        return true;
    }
}