public class Solution
{
    public int NearestExit(char[][] maze, int[] entrance)
    {
        int[][] directions = new int[][] { new int[] { 1, 0 }, new int[] { 0, 1 }, new int[] { -1, 0 }, new int[] { 0, -1 } };
        int m = maze.Length;
        int n = maze[0].Length;
        var queue = new Queue<int[]>();
        var visited = new bool[m, n];
        int[] curr = entrance;
        int row = curr[0];
        int col = curr[1];
        queue.Enqueue(curr);
        visited[row, col] = true;

        int level = 0;
        while (queue.Count != 0)
        {
            int levelLen = queue.Count;
            for (int i = 0; i < levelLen; i++)
            {
                curr = queue.Dequeue();
                row = curr[0];
                col = curr[1];
                foreach (var dir in directions)
                {
                    int nr = row + dir[0];
                    int nc = col + dir[1];
                    if (nr < 0 || nr >= m || nc < 0 || nc >= n || maze[nr][nc] == '+')
                        continue;
                    if (visited[nr, nc])
                        continue;
                    // return result
                    if (maze[nr][nc] == '.' && (nr == 0 || nr == m - 1 || nc == 0 || nc == n - 1))
                        return level + 1;
                    queue.Enqueue(new int[] { nr, nc });
                    visited[nr, nc] = true;
                }
            }
            level++;
        }
        return -1;
    }
}
// BFS
// Time: O(m * n)
// Space: O(max(m, n))
