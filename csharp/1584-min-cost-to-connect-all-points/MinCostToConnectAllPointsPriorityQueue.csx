
public class Solution
{
    // Prim's Algorithm
    // Graph + Priority Queue
    // Time: O(n^2 * log n)
    // Space: O(n^2)
    // E = n^2
    public int MinCostConnectPoints2(int[][] points)
    {
        int n = points.Length;

        var pq = new PriorityQueue<int[], int>();  // <[Cost, NodeToConnect], Cost>
        bool[] inMST = new bool[n];

        pq.Enqueue(new int[] { 0, 0 }, 0); // <[0 cost, node at index 0], 0 cost>
        int mstCost = 0;
        int edgesUsed = 0;

        while (pq.Count != 0 && edgesUsed < n)
        {
            var curr = pq.Dequeue();
            int weight = curr[0];
            int index = curr[1];
            int[] currNode = points[index];

            if (inMST[index])
                continue;

            inMST[index] = true;
            mstCost += weight;
            edgesUsed++;

            // if neighbor node is not in MST, then edge from curr node to neighbor node
            // can be added into the priority queue
            for (int i = 0; i < n; i++)
            {
                if (inMST[i])
                    continue;

                int[] neiNode = points[i];
                int neiWeight = Math.Abs(currNode[0] - neiNode[0]) + Math.Abs(currNode[1] - neiNode[1]);
                pq.Enqueue(new int[] { neiWeight, i }, neiWeight);
            }
        }

        return mstCost;
    }

    public int MinCostConnectPoints(int[][] points)
    {
        // use points to create graph
        int n = points.Length;
        var graph = new List<int[]>[n];
        for (int i = 0; i < n; i++)
            graph[i] = new List<int[]>();
        // graph[from] = list of [from, to, weight]
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                var pi = points[i];
                var pj = points[j];
                var xi = pi[0];
                var yi = pi[1];
                var xj = pj[0];
                var yj = pj[1];
                var weight = Math.Abs(xi - xj) + Math.Abs(yi - yj);
                graph[i].Add(new int[] { i, j, weight });
                graph[j].Add(new int[] { j, i, weight });
            }
        }
        // Prim to build MST
        var prim = new Prim(graph);
        return prim.WeightSum;
    }
}

public class Prim
{
    private PriorityQueue<int[], int> pq;
    private List<int[]>[] graph; // graph[from] = list of [from, to, weight]
    private bool[] inMST;
    public int WeightSum { get; private set; }
    public Prim(List<int[]>[] graph)
    {
        this.pq = new PriorityQueue<int[], int>();
        this.graph = graph;
        int n = graph.Length;
        this.inMST = new bool[n];
        WeightSum = 0;
        // starting from node 0
        inMST[0] = true;
        Cut(0);
        while (pq.Count != 0)
        {
            var edge = pq.Dequeue();
            int to = edge[1];
            int weight = edge[2];
            if (inMST[to])
                continue;

            WeightSum += weight;
            inMST[to] = true;
            Cut(to);
        }
    }

    private void Cut(int node)
    {
        foreach (var edge in graph[node])
        {
            int to = edge[1];
            int weight = edge[2];
            if (inMST[to])
                continue;

            pq.Enqueue(edge, weight);
        }
    }

    public bool AllConnected()
    {
        for (int i = 0; i < inMST.Length; i++)
        {
            if (!inMST[i])
                return false;
        }
        return true;
    }
}