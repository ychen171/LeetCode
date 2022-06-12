public class Solution
{
    // BFS
    // Time: O(N * E) --> O(N * N*(N-1)) --> O(N^3)
    // Space: O(N * E) --> O(N * N*(N-1)) --> O(N^3)
    public int NetworkDelayTime(int[][] times, int n, int k)
    {
        // build the graph [src] = [des, weight]
        var graph = new Dictionary<int, List<int[]>>();
        foreach (var item in times)
        {
            var src = item[0];
            var des = item[1];
            var time = item[2];
            if (!graph.ContainsKey(src))
                graph[src] = new List<int[]>();
            graph[src].Add(new int[] { des, time });
        }

        // initialize the used time array with max value
        var usedTime = new int[n];
        for (int i = 0; i < n; i++)
            usedTime[i] = int.MaxValue;

        // BFS
        var queue = new Queue<int>();
        queue.Enqueue(k);
        usedTime[k - 1] = 0;

        while (queue.Count != 0)
        {
            int levelLen = queue.Count;
            for (int i = 0; i < levelLen; i++)
            {
                var curr = queue.Dequeue();
                if (!graph.ContainsKey(curr)) // deadend
                    continue;
                var neighbors = graph[curr];
                foreach (var nei in neighbors)
                {
                    int des = nei[0];
                    int time = nei[1];
                    // found shorter time, 
                    // update usedTime and enqueue to redo the used times for children levels
                    if (usedTime[des - 1] > usedTime[curr - 1] + time)
                    {
                        usedTime[des - 1] = usedTime[curr - 1] + time;
                        queue.Enqueue(des);
                    }
                }
            }
        }

        int ans = -1;
        for (int i = 0; i < n; i++)
        {
            if (usedTime[i] == int.MaxValue) // unreachable
                return -1;
            ans = Math.Max(ans, usedTime[i]);
        }

        return ans;
    }

    // DFS | Recursion
    // Time: O()
    // Space: O()
    public int NetworkDelayTime1(int[][] times, int n, int k)
    {
        // build the graph
        var graph = new Dictionary<int, List<int[]>>();
        foreach (var item in times)
        {
            var src = item[0];
            var des = item[1];
            var time = item[2];
            if (!graph.ContainsKey(src))
                graph[src] = new List<int[]>();
            graph[src].Add(new int[] { des, time });
        }
        // sort list by time
        foreach (var kv in graph)
        {
            kv.Value.OrderBy((x) => x[1]);
        }
        // initialize the used time array with max value
        var usedTime = new int[n];
        for (int i = 0; i < n; i++)
            usedTime[i] = int.MaxValue;
        // DFS
        usedTime[k - 1] = 0;
        DFS(graph, usedTime, k);

        int ans = -1;
        for (int i = 0; i < n; i++)
        {
            if (usedTime[i] == int.MaxValue)
                return -1;

            ans = Math.Max(ans, usedTime[i]);
        }

        return ans;
    }

    private void DFS(Dictionary<int, List<int[]>> graph, int[] usedTime, int src)
    {
        // base case
        if (!graph.ContainsKey(src))
            return;
        // recursive case
        foreach (var nei in graph[src])
        {
            int des = nei[0];
            int time = nei[1];
            if (usedTime[src - 1] + time < usedTime[des - 1])
            {
                usedTime[des - 1] = usedTime[src - 1] + time;
                DFS(graph, usedTime, des);
            }
        }
    }

    // Dijkstra's Algorithm
    // Time: O(E log E) --> O(N * (N-1) * log (N * (N-1))) --> O(N^2 * log N)
    // Space: O(E) --> O(N^2)
    public int NetworkDelayTime2(int[][] times, int n, int k)
    {
        // build graph (adjacency list)
        var graph = new Dictionary<int, List<int[]>>();
        foreach (var item in times)
        {
            int src = item[0];
            int dst = item[1];
            int time = item[2];
            if (!graph.ContainsKey(src))
                graph[src] = new List<int[]>();
            graph[src].Add(new int[] { dst, time });
        }

        // create min time array
        var minUsedTime = new int[n + 1];
        for (int i = 0; i <= n; i++)
        {
            minUsedTime[i] = int.MaxValue;
        }

        // BFS using PriorityQueue
        // start at k
        var pq = new PriorityQueue<int[], int>(); // element = [node, usedTime], priority comparer = usedTime
        pq.Enqueue(new int[]{k, 0}, 0);
        minUsedTime[k] = 0;

        while (pq.Count != 0)
        {
            var element = pq.Dequeue();
            var node = element[0];
            var usedTime = element[1];
            // invalid
            if (!graph.ContainsKey(node))
                continue;
            // examine neighbors
            foreach (int[] nei in graph[node])
            {
                var neiNode = nei[0];
                var neiTime = nei[1];
                
                var newUsedTime = usedTime + neiTime;
                if (newUsedTime < minUsedTime[neiNode])
                {
                    minUsedTime[neiNode] = newUsedTime;
                    pq.Enqueue(new int[]{neiNode, newUsedTime}, newUsedTime);
                }
            }
        }

        int ans = -1;
        for (int i = 1; i <= n; i++)
        {
            if (minUsedTime[i] == int.MaxValue)
                return -1;
            ans = Math.Max(ans, minUsedTime[i]);
        }

        return ans;
    }
}
