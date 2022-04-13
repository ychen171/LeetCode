public class Solution
{
    // Time: O(n^2)
    // Space: O(1)
    public int[][] GenerateMatrix(int n)
    {
        //  1   2   3   4
        //  12  0   0   5
        //  11  0   0   6
        //  10  9   8   7
        
        //      13  14
        //      16  15
        int r = 0;
        int c = 0;
        int rMin = 0;
        int rMax = n - 1;
        int cMin = 0;
        int cMax = n - 1;

        int[][] matrix = new int[n][];
        for (int i = 0; i < n; i++)
            matrix[i] = new int[n];
        int num = 1;

        while (rMin <= rMax && cMin <= cMax)
        {
            // go right
            r = rMin;
            c = cMin;
            while (c <= cMax)
            {
                matrix[r][c] = num;
                num++;
                c++;
            }
            rMin++;
            // go down
            r = rMin;
            c = cMax;
            while (r <= rMax)
            {
                matrix[r][c] = num;
                num++;
                r++;
            }
            cMax--;
            // go left
            r = rMax;
            c = cMax;
            while (c >= cMin)
            {
                matrix[r][c] = num;
                num++;
                c--;
            }
            rMax--;
            // go up
            r = rMax;
            c = cMin;
            while (r >= rMin)
            {
                matrix[r][c] = num;
                num++;
                r--;
            }
            cMin++;
        }

        return matrix;
    }
}

