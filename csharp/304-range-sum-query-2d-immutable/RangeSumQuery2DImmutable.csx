// Brute force
public class NumMatrix
{
    private int[][] matrix;

    // Time: O(1)
    // Space: O(m * n)
    public NumMatrix(int[][] matrix)
    {
        this.matrix = matrix;
    }

    // Time: O(m * n)
    // Space: O(1)
    public int SumRegion(int row1, int col1, int row2, int col2)
    {
        int m = matrix.Length;
        int n = matrix[0].Length;
        int sum = 0;
        for (int i = row1; i <= row2; i++)
        {
            for (int j = col1; j <= col2; j++)
            {
                sum += matrix[i][j];
            }
        }

        return sum;
    }
}

// Caching Rows | Prefix Sum
public class NumMatrix1
{
    private int[][] prefixSum;
    private int m;
    private int n;

    // Time: O(m * n)
    // Space: O(m * n)
    public NumMatrix1(int[][] matrix)
    {
        m = matrix.Length;
        n = matrix[0].Length;
        prefixSum = new int[m][];
        for (int i = 0; i < m; i++)
        {
            prefixSum[i] = new int[n + 1];
            for (int j = 1; j < n + 1; j++)
            {
                prefixSum[i][j] = prefixSum[i][j - 1] + matrix[i][j - 1];
            }
        }
    }

    // Time: O(m)
    // Space: O(1)
    public int SumRegion(int row1, int col1, int row2, int col2)
    {
        int sum = 0;
        for (int i = row1; i <= row2; i++)
        {
            sum += prefixSum[i][col2 + 1] - prefixSum[i][col1];
        }

        return sum;
    }
}

// Caching Rows and Cols | Prefix Sum
public class NumMatrix2
{
    private int[][] prefixSum;
    private int m;
    private int n;
    // Time: O(m * n)
    // Space: O(m * n)
    public NumMatrix2(int[][] matrix)
    {
        m = matrix.Length;
        n = matrix[0].Length;
        // initialize the table with default values
        prefixSum = new int[m + 1][];
        for (int i = 0; i < m + 1; i++)
            prefixSum[i] = new int[n + 1];

        // seed the trivial answers into the table
        // fill further positions based on current position
        for (int i = 1; i < m + 1; i++)
        {
            for (int j = 1; j < n + 1; j++)
            {
                prefixSum[i][j] = prefixSum[i - 1][j] + prefixSum[i][j - 1] - prefixSum[i - 1][j - 1] + matrix[i - 1][j - 1];
            }
        }
    }

    // Time: O(1)
    // Space: O(1)
    public int SumRegion(int row1, int col1, int row2, int col2)
    {
        return prefixSum[row2 + 1][col2 + 1] - prefixSum[row1][col2 + 1] - prefixSum[row2 + 1][col1] + prefixSum[row1][col1];
    }
}

/**
 * Your NumMatrix object will be instantiated and called as such:
 * NumMatrix obj = new NumMatrix(matrix);
 * int param_1 = obj.SumRegion(row1,col1,row2,col2);
 */
