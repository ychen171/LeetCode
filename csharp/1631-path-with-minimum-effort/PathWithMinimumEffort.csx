public class Solution
{
    // Union Find
    // Time: (m*n) * log(m*n)
    // Space: O(m*n)
    public int MinimumEffortPath(int[][] heights)
    {
        // union find to see if we can travel from 0,0 to m-1,n-1
        int m = heights.Length;
        int n = heights[0].Length;

        // 1. build all edges
        var edgeList = new List<int[]>();
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n - 1; j++)
            {
                int node1Key = i * n + j;
                int node2Key = i * n + j + 1;
                int weight = Math.Abs(heights[i][j+1] - heights[i][j]);
                edgeList.Add(new int[]{weight, node1Key, node2Key});
            }
        }

        for (int j = 0; j < n; j++)
        {
            for (int i = 0; i < m - 1; i++)
            {
                int node1Key = i * n + j;
                int node2Key = (i+1) * n + j;
                int weight = Math.Abs(heights[i+1][j] - heights[i][j]);
                edgeList.Add(new int[]{weight, node1Key, node2Key});
            }
        }

        // 2. sort edges by weight
        edgeList.Sort((a, b) => a[0] - b[0]);

        // 3. union find to build graph
        var uf = new UnionFind(m*n);
        int prevWeight = 0;
        int startKey = 0;
        int endKey = (m-1) * n + (n - 1);
        foreach (int[] edge in edgeList)
        {
            var weight = edge[0];
            if (weight > prevWeight)
            {
                // check if 0,0 can travel to m-1,n-1
                if (uf.Find(startKey) == uf.Find(endKey))
                    return prevWeight;
                prevWeight = weight;
            }
            var node1Key = edge[1];
            var node2Key = edge[2];
            // Console.WriteLine($"weight:{weight}, edge: {node1Key}, {node2Key}");
            uf.Union(node1Key, node2Key);
        }

        return prevWeight;
    }
}


public class UnionFind
{
    int[] group;
    int[] rank;
    public UnionFind(int size)
    {
        group = new int[size];
        rank = new int[size];
        for (int i = 0; i < size; i++)
            group[i] = i;
    }

    public int Find(int vertex)
    {
        if (group[vertex] != vertex)
        {
            group[vertex] = Find(group[vertex]);
        }

        return group[vertex];
    }

    public void Union(int vertex1, int vertex2)
    {
        int group1 = Find(vertex1);
        int group2 = Find(vertex2);
        
        if (rank[group1] > rank[group2])
            group[group2] = group1;
        else if (rank[group1] < rank[group2])
            group[group1] = group2;
        else
        {
            group[group1] = group2;
            rank[group2]++;
        }
    }
}