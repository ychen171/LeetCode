public class Solution
{
    // Preprocessing count on row and count on col
    // Time: O(m*n)
    // Space: O(m+n)
    public int CountServers(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        // store count of servers for each row and each col
        int[] countOnRow = new int[m];
        int[] countOnCol = new int[n];
        List<int[]> serverList = new List<int[]>();
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] == 1)
                {
                    countOnRow[i]++;
                    countOnCol[j]++;
                    serverList.Add(new int[] { i, j });
                }
            }
        }

        int count = 0;
        // for every server, check if its row or it col contains other server
        foreach (var server in serverList)
        {
            int row = server[0];
            int col = server[1];
            Console.WriteLine($"Server:{row},{col}");
            if (countOnRow[row] > 1 || countOnCol[col] > 1)
                count++;
        }

        return count;
    }
}

var s = new Solution();
var result = s.CountServers(new int[][] {new int[]{1,0}, new int[]{1,1}});
Console.WriteLine(result);