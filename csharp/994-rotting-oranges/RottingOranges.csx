public class Solution
{
    // BFS
    // Time: O(m * n)
    // Space: O(m * n)
    public int OrangesRotting(int[][] grid)
    {
        var directions = new int[][] { new int[] { 1, 0 }, new int[] { 0, 1 }, new int[] { -1, 0 }, new int[] { 0, -1 } };
        int m = grid.Length;
        int n = grid[0].Length;
        var queue = new Queue<int>();
        int freshCount = 0;
        // find all starting cells for the starting level
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                var cell = grid[i][j];
                if (cell == 1)
                {
                    freshCount++;
                }
                else if (cell == 2)
                {
                    int key = i * n + j;
                    queue.Enqueue(key);
                }
            }
        }

        int minutes = 0;
        // BFS to find the shortest path
        while (queue.Count != 0)
        {
            int levelLen = queue.Count;
            // Console.WriteLine(levelLen);
            for (int i = 0; i < levelLen; i++)
            {
                int key = queue.Dequeue();
                int row = key / n;
                int col = key % n;
                // Console.WriteLine($"curr: {row},{col}");
                foreach (var dir in directions)
                {
                    int r = row + dir[0];
                    int c = col + dir[1];
                    // Console.WriteLine($"nei: {r},{c}");
                    if (r < 0 || r >= m || c < 0 || c >= n)
                        continue;
                    if (grid[r][c] == 1)
                    {
                        // Console.WriteLine($"Rotting {r},{c}");
                        grid[r][c] = 2;
                        freshCount--;
                        queue.Enqueue(r * n + c);
                    }
                }
            }

            if (queue.Count > 0)
                minutes++;
        }

        return freshCount == 0 ? minutes : -1;
    }
}
