public class Solution
{
    // Dijkstra's Algo
    // Time: O(m*n*log(m*n))
    // Space: O(m*n)
    public int MinimumEffortPath(int[][] heights)
    {
        // build graph, weighted, directed
        int m = heights.Length;
        int n = heights[0].Length;
        var directions = new int[][] { new int[] { 1, 0 }, new int[] { 0, 1 }, new int[] { -1, 0 }, new int[] { 0, -1 } };
        var graph = new List<int[]>[m * n]; // graph[from] = list of [to, weight]
        for (int r = 0; r < m; r++)
        {
            for (int c = 0; c < n; c++)
            {
                var curr = r * n + c;
                graph[curr] = new List<int[]>();
                foreach (var dir in directions)
                {
                    int nr = r + dir[0];
                    int nc = c + dir[1];
                    if (nr < 0 || nr >= m || nc < 0 || nc >= n)
                        continue;
                    int weight = Math.Abs(heights[r][c] - heights[nr][nc]);
                    graph[curr].Add(new int[] { nr * n + nc, weight });
                }
            }
        }

        // dijkstra
        var effortFromStart = new int[m * n];
        for (int i = 0; i < m * n; i++)
            effortFromStart[i] = int.MaxValue;
        var pq = new PriorityQueue<int[], int>(); // <[node, effortFromStart], effortFromStart>
        // start from 0,0
        effortFromStart[0] = 0;
        pq.Enqueue(new int[] { 0, 0 }, 0);

        while (pq.Count != 0)
        {
            var curr = pq.Dequeue();
            var currNode = curr[0];
            var currEffortFromStart = curr[1];
            int r = currNode / n;
            int c = currNode % n;
            if (r == m - 1 && c == n - 1)
                return currEffortFromStart;

            if (currEffortFromStart > effortFromStart[currNode])
                continue;

            foreach (var nei in graph[currNode])
            {
                var neiNode = nei[0];
                var neiEffort = nei[1]; // the effort from curr to nei
                var neiEffortFromStart = Math.Max(neiEffort, effortFromStart[currNode]);
                if (neiEffortFromStart < effortFromStart[neiNode])
                {
                    effortFromStart[neiNode] = neiEffortFromStart;
                    pq.Enqueue(new int[] { neiNode, neiEffortFromStart }, neiEffortFromStart);
                }
            }
        }

        return -1;
    }
}

var s = new Solution();
// [[1,10,6,7,9,10,4,9]]
var heights = new int[][] { new int[] { 1, 10, 6, 7, 9, 10, 4, 9 } };
var result = s.MinimumEffortPath(heights);
Console.WriteLine(result);
