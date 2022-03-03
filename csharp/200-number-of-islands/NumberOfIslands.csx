public class Solution
{
    // DFS Traversal | Recursion
    // Time: O(m * n)
    // Space: O(m * n)
    public int NumIslands(char[][] grid)
    {
        if (grid == null || grid.Length == 0) return 0;
        var m = grid.Length;
        var n = grid[0].Length;
        var num = 0;
        for (int row = 0; row < m; row++)
        {
            for (int col = 0; col < n; col++)
            {
                // count every root node and start DFS traversal
                if (grid[row][col] == '1')
                {
                    num++;
                    DFS(grid, row, col);
                }
            }
        }

        return num;
    }

    private void DFS(char[][] grid, int row, int col)
    {
        var m = grid.Length;
        var n = grid[0].Length;
        // base case
        if (row < 0 || col < 0 || row >= m || col >= n || grid[row][col] == '0')
            return;

        // mark the visited node as '0'
        grid[row][col] = '0';
        // traverse 4 directions
        DFS(grid, row - 1, col);
        DFS(grid, row + 1, col);
        DFS(grid, row, col - 1);
        DFS(grid, row, col + 1);
    }

    // BFS Traversal | Iteration
    // Time: O(m * n)
    // Space: O(min(m, n))
    public int NumIslandsBFS(char[][] grid)
    {
        if (grid == null || grid.Length == 0) return 0;
        var m = grid.Length;
        var n = grid[0].Length;
        var num = 0;
        for (int r = 0; r < m; r++)
        {
            for (int c = 0; c < n; c++)
            {
                if (grid[r][c] == '1') num++;
                grid[r][c] = '0';
                var key = r * n + c;
                var queue = new Queue<int>();
                queue.Enqueue(key);
                while (queue.Count != 0)
                {
                    key = queue.Dequeue();
                    var row = key / n;
                    var col = key % n;
                    if (row - 1 >= 0 && row - 1 < m && grid[row - 1][col] == '1')
                    {
                        queue.Enqueue((row - 1) * n + col);
                        grid[row - 1][col] = '0';
                    }
                    if (row + 1 >= 0 && row + 1 < m && grid[row + 1][col] == '1')
                    {
                        queue.Enqueue((row + 1) * n + col);
                        grid[row + 1][col] = '0';
                    }
                    if (col - 1 >= 0 && col - 1 < n && grid[row][col - 1] == '1')
                    {
                        queue.Enqueue(row * n + col - 1);
                        grid[row][col - 1] = '0';
                    }
                    if (col + 1 >= 0 && col + 1 < n && grid[row][col + 1] == '1')
                    {
                        queue.Enqueue(row * n + col + 1);
                        grid[row][col + 1] = '0';
                    }
                }
            }
        }

        return num;
    }
}

var s = new Solution();
Console.WriteLine(s.NumIslandsBFS(new char[][] { new char[] { '1', '1', '1', '1', '0' }, new char[] { '1', '1', '0', '1', '0' }, new char[] { '1', '1', '0', '0', '0' }, new char[] { '0', '0', '0', '0', '0' } }))

