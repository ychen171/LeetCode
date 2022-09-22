public class Solution
{
    // loop
    // Time: O(m*n)
    // Space: O(1)
    public int[][] FlipAndInvertImage(int[][] image)
    {
        int m = image.Length;
        int n = image[0].Length;
        for (int i = 0; i < m; i++)
        {
            int l = 0, r = n - 1;
            while (l <= r)
            {
                // swap and invert
                int temp = image[i][l];
                image[i][l] = image[i][r] == 0 ? 1 : 0;
                image[i][r] = temp == 0 ? 1 : 0;
                l++;
                r--;
            }
        }

        return image;
    }
}
