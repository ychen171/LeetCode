public class Solution
{
    // DFS | Flood
    // Time: O(m * n)
    // Space: O(m * n)
    int[][] directions = new int[][] { new int[] { 1, 0 }, new int[] { 0, 1 }, new int[] { -1, 0 }, new int[] { 0, -1 } };
    public IList<IList<int>> PacificAtlantic(int[][] heights)
    {
        int m = heights.Length;
        int n = heights[0].Length;

        // flood from pacific
        var pacific = new bool[m * n];
        for (int row = 0; row < m; row++)
        {
            DFS(heights, row, 0, pacific);
        }
        for (int col = 0; col < n; col++)
        {
            DFS(heights, 0, col, pacific);
        }

        // flood from atlantic
        var atlantic = new bool[m * n];
        for (int row = 0; row < m; row++)
        {
            DFS(heights, row, n - 1, atlantic);
        }
        for (int col = 0; col < n; col++)
        {
            DFS(heights, m - 1, col, atlantic);
        }

        // find overlapped
        var result = new List<IList<int>>();
        for (int row = 0; row < m; row++)
        {
            for (int col = 0; col < n; col++)
            {
                var key = row * n + col;
                if (pacific[key] && atlantic[key])
                    result.Add(new List<int> { row, col });
            }
        }

        return result;
    }

    public void DFS(int[][] heights, int row, int col, bool[] visited)
    {
        int m = heights.Length;
        int n = heights[0].Length;
        var key = row * n + col;
        if (visited[key])
            return;

        visited[key] = true;
        foreach (var dir in directions)
        {
            var nr = row + dir[0];
            var nc = col + dir[1];
            if (nr < 0 || nr >= m || nc < 0 || nc >= n)
                continue;
            if (heights[nr][nc] < heights[row][col])
                continue;

            DFS(heights, nr, nc, visited);
        }
    }
}

// [1,2,2,3,5],[3,2,3,4,4],[2,4,5,3,1],[6,7,1,4,5],[5,1,1,2,4]
var heights = new int[][] { new int[] { 1, 2, 2, 3, 5 }, new int[] { 3, 2, 3, 4, 4 }, new int[] { 2, 4, 5, 3, 1 }, new int[] { 6, 7, 1, 4, 5 }, new int[] { 5, 1, 1, 2, 4 } };
var sln = new Solution();
var result = sln.PacificAtlantic(heights);
Console.WriteLine(result);
