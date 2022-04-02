public class Solution
{
    // Brute force
    // Time: O(m*n)
    // Space: O(1)
    public IList<int> SpiralOrder(int[][] matrix)
    {
        var ans = new List<int>();
        int m = matrix.Length;
        int n = matrix[0].Length;
        // row = [0, m-1]
        // col = [0, n-1]
        int row = 0;
        int col = 0;
        int rowMin = 0, rowMax = m - 1;
        int colMin = 0, colMax = n - 1;

        while (true)
        {
            // go right
            row = rowMin;
            col = colMin;
            while (col <= colMax)
            {
                ans.Add(matrix[row][col]);
                Console.WriteLine($"{row},{col} -- {matrix[row][col]}");
                col++;
            }
            rowMin++;
            if (rowMin > rowMax) break;
            // go down
            row = rowMin;
            col = colMax;
            while (row <= rowMax)
            {
                ans.Add(matrix[row][col]);
                Console.WriteLine($"{row},{col} -- {matrix[row][col]}");
                row++;
            }
            colMax--;
            if (colMin > colMax) break;
            // go left
            row = rowMax;
            col = colMax;
            while (col >= colMin)
            {
                ans.Add(matrix[row][col]);
                Console.WriteLine($"{row},{col} -- {matrix[row][col]}");
                col--;
            }
            rowMax--;
            if (rowMin > rowMax) break;
            // go up
            row = rowMax;
            col = colMin;
            while (row >= rowMin)
            {
                ans.Add(matrix[row][col]);
                Console.WriteLine($"{row},{col} -- {matrix[row][col]}");
                row--;
            }
            colMin++;
            if (colMin > colMax) break;
        }

        return ans;
    }
}
