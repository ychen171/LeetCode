public class Solution
{
    // BFS
    // Time: O(n)
    // Space: O(n)
    public int ShortestPathBinaryMatrix(int[][] grid)
    {
        int n = grid.Length;
        if (n == 1)
            return grid[0][0] == 0 ? 1 : -1;
        // BFS, staring from (0,0), to (n-1,n-1)
        var queue = new Queue<int>();
        var visited = new HashSet<int>();
        var directions = new int[][]
        {
            new int[] { -1, 0 }, new int[] { -1, -1 }, new int[] { 0, -1 }, new int[] { 1, -1 },
            new int[] { 1, 0 }, new int[] { 1, 1 }, new int[] { 0, 1 }, new int[] { -1, 1 },
        };
        if (grid[0][0] == 0)
        {
            queue.Enqueue(0);
            visited.Add(0);
        }
        // BFS
        int step = 1;
        while (queue.Count != 0)
        {
            int levelLen = queue.Count;
            step++;
            for (int i = 0; i < levelLen; i++)
            {
                var key = queue.Dequeue();
                int row = key / n;
                int col = key % n;
                foreach (var dir in directions)
                {
                    int r = row + dir[0];
                    int c = col + dir[1];
                    if (r < 0 || r >= n || c < 0 || c >= n)
                        continue;
                    if (grid[r][c] == 1)
                        continue;
                    if (r == n - 1 && c == n - 1)
                        return step;
                    key = r * n + c;
                    if (visited.Add(key))
                    {
                        queue.Enqueue(key);
                    }
                }
            }
        }

        return -1;
    }
}
