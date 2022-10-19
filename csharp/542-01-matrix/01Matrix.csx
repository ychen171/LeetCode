public class Solution
{
    int[][] directions = new int[][]
    {
        new int[] { 1, 0 },
        new int[] { 0, 1 },
        new int[] { -1, 0 },
        new int[] { 0, -1 }
    };
    
    // Starting from each 1 cell
    // Time: O(m * n * m * n)
    // Space: O(m * n)
    public int[][] UpdateMatrix(int[][] mat)
    {
        // BFS to find the shortest path
        // starting from each 1 cell
        // do BFS, record visited cells
        // return distance when 0 cell is found, mark the current cell is done using -1
        int m = mat.Length;
        int n = mat[0].Length;
        int[][] ans = new int[m][];
        for (int i = 0; i < m; i++)
            ans[i] = new int[n];

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (mat[i][j] == 1)
                {
                    var step = BFS(mat, i, j);
                    ans[i][j] = step;
                }
            }
        }

        return ans;
    }

    private int BFS(int[][] mat, int i, int j)
    {
        int m = mat.Length;
        int n = mat[0].Length;
        var queue = new Queue<int>();
        var visited = new HashSet<int>();
        int key = i * n + j;
        queue.Enqueue(key);
        visited.Add(key);
        int level = 0;
        int levelLen = 0;
        while (queue.Count != 0)
        {
            levelLen = queue.Count;
            for (int k = 0; k < levelLen; k++)
            {
                key = queue.Dequeue();
                int row = key / n;
                int col = key % n;
                if (mat[row][col] == 0)
                {
                    mat[i][j] = -1;
                    return level;
                }
                foreach (var dir in directions)
                {
                    int r = row + dir[0];
                    int c = col + dir[1];


                    key = r * n + c;
                    if (r < 0 || r >= m || c < 0 || c >= n || visited.Contains(key))
                        continue;

                    queue.Enqueue(key);
                    visited.Add(key);
                }
            }
            level++;
        }

        return -1;
    }

    // Starting from all 0 cells
    // Time: O(m * n)
    // Space: O(m * n)
    public int[][] UpdateMatrix1(int[][] mat)
    {
        // BFS to find the shortest path
        // starting from each 0 cell
        // foreach 0 cell, do BFS, store distance on ans matrix
        // if curr distance + 1 < neighbor, update neighbor and continue
        int m = mat.Length;
        int n = mat[0].Length;
        int[][] ans = new int[m][];
        for (int i = 0; i < m; i++)
        {
            ans[i] = new int[n];
            for (int j = 0; j < n; j++)
            {
                ans[i][j] = mat[i][j] == 0 ? 0 : int.MaxValue;
            }
        }

        var queue = new Queue<int>();
        int key;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (mat[i][j] == 0)
                {
                    ans[i][j] = 0;
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
                if (r < 0 || r >= m || c < 0 || c >= n)
                    continue;
                if (ans[r][c] != int.MaxValue)
                    continue;
                
                ans[r][c] = ans[row][col] + 1;
                key = r * n + c;
                queue.Enqueue(key);
            }
        }

        return ans;
    }
    
    // Starting from all 0 cells
    // Time: O(m * n)
    // Space: O(m * n)
    int m;
    int n;
    public int[][] UpdateMatrix2(int[][] mat) 
    {
        m = mat.Length;
        n = mat[0].Length;
        var visited = new HashSet<int>();
        var queue = new Queue<int>();
        
        for (int r = 0; r < m; r++)
        {
            for (int c = 0; c < n; c++)
            {
                // add entry points into queue
                if (mat[r][c] == 0)
                {
                    var key = r * n + c;
                    queue.Enqueue(key);
                    visited.Add(key);
                }
            }
        }
        // BFS to update mat
        BFS(mat, visited, queue);
        return mat;
    }
    
    private void BFS(int[][] mat, HashSet<int> visited, Queue<int> queue)
    {
        int curr, next;
        int level = 0;
        while (queue.Count != 0)
        {
            int levelLen = queue.Count;
            for (int i = 0; i < levelLen; i++)
            {
                curr = queue.Dequeue();
                int r = curr / n;
                int c = curr % n;
                mat[r][c] = level;
                foreach (var dir in directions)
                {
                    var nr = r + dir[0];
                    var nc = c + dir[1];
                    if (nr < 0 || nr >= m || nc < 0 || nc >= n) // invalid
                        continue;
                    next = nr * n + nc;
                    if (visited.Contains(next)) // visited
                        continue;

                    queue.Enqueue(next);
                    visited.Add(next);
                }
            }
            level++;
        }
    }
}
