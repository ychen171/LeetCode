public class Solution
{
    // Time: O(m*n)
    // Space:O(m*n)
    public void SetZeroes(int[][] matrix)
    {
        int m = matrix.Length;
        int n = matrix[0].Length;
        var zeros = new List<int[]>();
        for (int r = 0; r < m; r++)
        {
            for (int c = 0; c < n; c++)
            {
                if (matrix[r][c] == 0)
                    zeros.Add(new int[] { r, c });
            }
        }

        foreach (var zero in zeros)
        {
            int r = zero[0];
            int c = zero[1];
            for (int i = 0; i < m; i++)
            {
                matrix[i][c] = 0;
            }
            for (int j = 0; j < n; j++)
            {
                matrix[r][j] = 0;
            }
        }
    }

    // Time: O(m*n)
    // Space: O(1)
    public void SetZeroes1(int[][] matrix)
    {
        bool isCol = false;
        int m = matrix.Length;
        int n = matrix[0].Length;

        for (int i = 0; i < m; i++)
        {
            // since first cell for both first row and first column is the same i.e. matrix[0][0]
            // We can use an additional variable for either the first row or column. 
            // For this solution we are using an addtional variable for the first column
            // and using matrix[0][0] for the first row. 
            if (matrix[i][0] == 0)
            {
                isCol = true;
            }

            for (int j = 1; j < n; j++)
            {
                // if an element is zero, we set the first element of the coresponding row and column to 0
                if (matrix[i][j] == 0)
                {
                    matrix[0][j] = 0;
                    matrix[i][0] = 0;
                }
            }
        }

        // iterate over the array once again and using the first row and first column, update the elements
        for (int i = 1; i < m; i++)
        {
            for (int j = 1; j < n; j++)
            {
                if (matrix[i][0] == 0 || matrix[0][j] == 0)
                {
                    matrix[i][j] = 0;
                }
            }
        }

        // see if the first row needs to be set to zero as well
        if (matrix[0][0] == 0)
        {
            for (int j = 0; j < n; j++)
                matrix[0][j] = 0;
        }

        // see if the first column needs to be set to zero as well
        if (isCol)
        {
            for (int i = 0; i < m; i++)
                matrix[i][0] = 0;
        }
    }
}
