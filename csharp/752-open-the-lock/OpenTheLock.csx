public class Solution
{
    // BFS
    public int OpenLock(string[] deadends, string target)
    {
        // BFS, 8 neighbors, 
        var dead = deadends.ToHashSet();
        if (dead.Contains("0000"))
            return -1;
        int[][] directions = new int[][]
        {
            new int[] { 1, 0, 0, 0 },
            new int[] { -1, 0, 0, 0 },
            new int[] { 0, 1, 0, 0 },
            new int[] { 0, -1, 0, 0 },
            new int[] { 0, 0, 1, 0 },
            new int[] { 0, 0, -1, 0 },
            new int[] { 0, 0, 0, 1 },
            new int[] { 0, 0, 0, -1 },
        };

        var seen = new HashSet<int>();
        var queue = new Queue<int>();
        int key = 0;
        int level = 0;
        int levelLen = 0;
        seen.Add(key);
        queue.Enqueue(key);
        while (queue.Count != 0)
        {
            levelLen = queue.Count;
            for (int i = 0; i < levelLen; i++)
            {
                key = queue.Dequeue();
                int d0 = key / 1000;
                int m0 = key % 1000;
                int d1 = m0 / 100;
                int m1 = m0 % 100;
                int d2 = m1 / 10;
                int d3 = m1 % 10;
                string dStr = $"{d0}{d1}{d2}{d3}";
                if (dStr == target)
                    return level;

                foreach (var dir in directions)
                {
                    int x0 = d0 + dir[0];
                    x0 = x0 < 0 ? 9 : x0 % 10;
                    int x1 = d1 + dir[1];
                    x1 = x1 < 0 ? 9 : x1 % 10;
                    int x2 = d2 + dir[2];
                    x2 = x2 < 0 ? 9 : x2 % 10;
                    int x3 = d3 + dir[3];
                    x3 = x3 < 0 ? 9 : x3 % 10;

                    string xStr = $"{x0}{x1}{x2}{x3}";
                    key = x0 * 1000 + x1 * 100 + x2 * 10 + x3;
                    if (dead.Contains(xStr) || seen.Contains(key))
                        continue;

                    seen.Add(key);
                    queue.Enqueue(key);
                }
            }
            level++;
        }

        return -1;
    }
}
