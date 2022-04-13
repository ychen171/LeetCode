public class Solution
{
    // Time: O(n)
    // Space: O(n)
    int[][] directions = new int[][]
    {
        new int[]{1, 0},
        new int[]{0, 1},
        new int[]{-1, 0},
        new int[]{0, -1},
    };
    public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
    {
        // DFS and mark visited using newColor
        DFS(image, sr, sc, image[sr][sc], newColor);
        return image;
    }

    private void DFS(int[][] image, int row, int col, int color, int newColor)
    {
        // base case
        int m = image.Length;
        int n = image[0].Length;
        if (image[row][col] != color)
            return;
        
        // mark visited using newColor
        image[row][col] = newColor;
        // recursive case
        foreach (var dir in directions)
        {
            int r = row + dir[0];
            int c = col + dir[1];
            if (r < 0 || r >= m || c < 0 || c >= n || image[r][c] == newColor)
                continue;
            DFS(image, r, c, color, newColor);
        }
    }
}
