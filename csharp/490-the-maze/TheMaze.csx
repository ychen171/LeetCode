public class Solution
{
    int m;
    int n;
    int[][] directions = new int[][] { new int[] { 1, 0 }, new int[] { 0, 1 }, new int[] { -1, 0 }, new int[] { 0, -1 } };
    public bool HasPath(int[][] maze, int[] start, int[] destination)
    {
        m = maze.Length;
        n = maze[0].Length;
        var visited = new bool[m, n];
        return DFS(maze, visited, start, destination);
    }

    private bool DFS(int[][] maze, bool[,] visited, int[] start, int[] dest)
    {
        int row = start[0];
        int col = start[1];
        // base case
        if (row < 0 || row >= m || col < 0 || col >= n || maze[row][col] == 1)
            return false;
        if (visited[row, col])
            return false;
        if (row == dest[0] && col == dest[1])
            return true;
        // recursive case
        visited[row, col] = true;
        var result = false;
        foreach (var dir in directions)
        {
            int nr = row + dir[0];
            int nc = col + dir[1];
            while (nr >= 0 && nr < m && nc >= 0 && nc < n && maze[nr][nc] == 0)
            {
                nr += dir[0];
                nc += dir[1];
            }
            nr -= dir[0];
            nc -= dir[1];
            if (DFS(maze, visited, new int[] { nr, nc }, dest))
            {
                result = true;
                break;
            }
        }
        return result;
    }
}
