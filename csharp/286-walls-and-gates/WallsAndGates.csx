public class Solution
{
    // BFS | Brute force
    // Time: O((m*n)^2)
    // Space: O(m*n)
    public void WallsAndGates(int[][] rooms)
    {
        // for each room
        // if room is inf, do BFS to find the answer
        int m = rooms.Length;
        int n = rooms[0].Length;
        var directions = new int[][] { new int[] { 1, 0 }, new int[] { 0, 1 }, new int[] { -1, 0 }, new int[] { 0, -1 } };
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (rooms[i][j] == int.MaxValue)
                {
                    var queue = new Queue<int>();
                    var visited = new HashSet<int>();
                    int key = i * n + j;
                    queue.Enqueue(key);
                    visited.Add(key);
                    int level = 0;
                    int levelLen = queue.Count;
                    bool found = false;
                    while (!found && queue.Count != 0)
                    {
                        levelLen = queue.Count;
                        // Console.WriteLine($"levelLen:{levelLen}, level:{level}");
                        for (int k = 0; k < levelLen; k++)
                        {
                            key = queue.Dequeue();
                            int row = key / n;
                            int col = key % n;
                            var curr = rooms[row][col];
                            // Console.WriteLine($"row:{row},col:{col}  curr:{curr}  i:{i},j:{j}");
                            if (curr == 0)
                            {
                                rooms[i][j] = level;
                                found = true;
                                break;
                            }
                            foreach (var dir in directions)
                            {
                                int r = row + dir[0];
                                int c = col + dir[1];
                                key = r * n + c;
                                if (r < 0 || r >= m || c < 0 || c >= n || rooms[r][c] == -1 || visited.Contains(key))
                                    continue;

                                queue.Enqueue(key);
                                visited.Add(key);
                            }
                        }
                        level++;
                    }
                }
            }
        }
    }

    // BFS
    // Time: O(m*n)
    // Space: O(m*n)
    public void WallsAndGates1(int[][] rooms)
    {
        // find all gates and put them into queue
        // foreach gate, do BFS
        int m = rooms.Length;
        int n = rooms[0].Length;
        var directions = new int[][] { new int[] { 1, 0 }, new int[] { 0, 1 }, new int[] { -1, 0 }, new int[] { 0, -1 } };
        var queue = new Queue<int>();
        int key;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (rooms[i][j] == 0)
                {
                    key = i * n + j;
                    queue.Enqueue(key);
                }
            }
        }

        while (queue.Count != 0)
        {
            key = queue.Dequeue();
            int row = key / n;
            int col = key % n;
            foreach (var dir in directions)
            {
                int r = row + dir[0];
                int c = col + dir[1];
                if (r < 0 || r >= m || c < 0 || c >= n || rooms[r][c] == -1 || rooms[r][c] != int.MaxValue)
                    continue;

                rooms[r][c] = rooms[row][col] + 1;
                key = r * n + c;
                queue.Enqueue(key);
            }
        }
    }
}