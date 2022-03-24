public class Solution
{
    int[][] dirs = new int[][]{new int[]{0, 1}, new int[]{1, 0}, new int[]{0, -1}, new int[]{-1, 0}};
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
        foreach (var dir in dirs)
        {
            DFS(grid, row + dir[0], col + dir[1]);
        }
    }

    // BFS Traversal | Iteration
    // Time: O(m * n)
    // Space: O(min(m, n))
    public int NumIslandsBFS(char[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        int num = 0;
        
        // for each point, if it is '1', mark as '0' and start BFS
        var queue = new Queue<int>();
        for (int i=0; i<m; i++)
        {
            for (int j=0; j<n; j++)
            {
                if (grid[i][j] == '1')
                {
                    num++;
                    int key = i * n + j;
                    queue.Enqueue(key);
                    grid[i][j] = '0';
                    while (queue.Count != 0)
                    {
                        key = queue.Dequeue();
                        int r = key / n;
                        int c = key % n;
                        // add 4 neighbors into queue if valid and not visited
                        // [r-1][c]  [r][c-1]  [r+1][c]  [r][c+1]
                        foreach (var dir in dirs)
                        {
                            var row = r + dir[0];
                            var col = c + dir[1];
                            if (row < 0 || row >= m || col < 0 || col >= n || grid[row][col] == '0')
                                continue;
                            queue.Enqueue(row * n + col);
                            grid[row][col] = '0';
                        }
                    }
                }
            }
        }
        
        return num;
    }
}

var s = new Solution();
Console.WriteLine(s.NumIslandsBFS(new char[][] { new char[] { '1', '1', '1', '1', '0' }, new char[] { '1', '1', '0', '1', '0' }, new char[] { '1', '1', '0', '0', '0' }, new char[] { '0', '0', '0', '0', '0' } }))

