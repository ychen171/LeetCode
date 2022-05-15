public class Solution
{
    // BFS
    // Time: O(N * E)
    // Space: O(N * E)
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
}
