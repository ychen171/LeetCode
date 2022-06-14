public class Solution1
{
    // Kruskal's Algorithm + Union Find
    // Time: O(n^2 * log n)
    // Space: O(n^2)
    public int MinCostConnectPoints(int[][] points)
    {
        int n = points.Length;
        // 1. build all weighted edges: all combinations of two points (direction doesn't matter)
        List<int[]> edgeList = new List<int[]>();
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                var pA = points[i];
                var pB = points[j];
                int weight = Math.Abs(pA[0] - pB[0]) + Math.Abs(pA[1] - pB[1]);
                // use input array index to represent each item/node/point
                int[] edge = new int[] {weight, i, j};
                edgeList.Add(edge);
            }
        }

        // sort edges by weight
        edgeList.Sort((a, b) => a[0] - b[0]);

        // 2. iterate through edges and perform union find on each edge to build Union graph
        UnionFind uf = new UnionFind(n);
        int mstCost = 0;
        int edgesUsed = 0;
        for (int i = 0; i < edgeList.Count && edgesUsed < n - 1; i++)
        {
            int weight = edgeList[i][0];
            int node1 = edgeList[i][1];
            int node2 = edgeList[i][2];

            if (uf.Union(node1, node2))
            {
                // Do something
                mstCost += weight;
                edgesUsed++;
            }
        }

        return mstCost;
    }

}
public class UnionFind
{
    int[] group;
    int[] rank;

    public UnionFind(int size)
    {
        // initialize group and rank
        // put every item in the same rank
        // put every item in its own group
        group = new int[size];
        rank = new int[size];

        for (int i = 0; i < size; i++)
        {
            group[i] = i;
        }
    }

    public int Find(int node)
    {
        // cycle detection
        if (group[node] != node)
            group[node] = Find(group[node]);

        // return the head of the group, representing the group
        return group[node];
    }

    public bool Union(int node1, int node2)
    {
        int group1 = Find(node1);
        int group2 = Find(node2);

        // node1 and node2 already belong to same group
        if (group1 == group2)
            return false;

        if (rank[group1] > rank[group2])
            group[group2] = group1;
        else if (rank[group1] < rank[group2])
            group[group1] = group2;
        else
        {
            group[group1] = group2;
            rank[group2] += 1;
        }

        return true;
    }
}


public class Solution2
{
    // Prim's Algorithm
    // Graph + Priority Queue
    // Time: O(n^2 * log n)
    // Space: O(n^2)
    public int MinCostConnectPoints2(int[][] points)
    {
        int n = points.Length;

        var pq = new PriorityQueue<int[], int>();  // <[Cost, NodeToConnect], Cost>
        bool[] visited = new bool[n];
        
        pq.Enqueue(new int[]{0, 0}, 0); // <[0 cost, node at index 0], 0 cost>
        int mstCost = 0;
        int edgesUsed = 0;

        while (edgesUsed < n)
        {
            var curr = pq.Dequeue();
            int weight = curr[0];
            int index = curr[1];
            int[] currNode = points[index];

            if (visited[index])
                continue;
            
            visited[index] = true;
            mstCost += weight;
            edgesUsed++;

            // if neighbor node is not in MST, then edge from curr node to neighbor node
            // can be added into the priority queue
            for (int i = 0; i < n; i++)
            {
                if (visited[i])
                    continue;
                
                int[] neiNode = points[i];
                int neiWeight = Math.Abs(currNode[0] - neiNode[0]) + Math.Abs(currNode[1] - neiNode[1]);
                pq.Enqueue(new int[]{neiWeight, i}, neiWeight);
            }
        }

        return mstCost;
    }
}