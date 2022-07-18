public class Solution
{
    // Stack overflow
    // DP | Memoization | Recursion
    // Time: O((m*n)^2)
    // Space: O((m*n)^2)
    int[][] matrix;
    int ROWS;
    int COLS;
    int ans = 0;
    int[][] directions = new int[][] { new int[] { 1, 0 }, new int[] { 0, 1 }, new int[] { -1, 0 }, new int[] { 0, -1 } };
    int[,,,] memo; // [r1][c1][r2][c2]
    int[,] ps; // prefixSum
    public int NumSubmatrixSumTarget(int[][] matrix, int target)
    {
        // initialize
        this.matrix = matrix;
        this.ROWS = matrix.Length;
        this.COLS = matrix[0].Length;

        ps = new int[ROWS + 1, COLS + 1];
        for (int r = 1; r < ROWS + 1; r++)
        {
            for (int c = 1; c < COLS + 1; c++)
            {
                ps[r, c] = ps[r, c - 1] + ps[r - 1, c] - ps[r - 1, c - 1] + matrix[r - 1][c - 1];
            }
        }

        memo = new int[ROWS, COLS, ROWS, COLS];

        Helper(target, 0, 0, ROWS - 1, COLS - 1);

        return ans;
    }
    public void Helper(int target, int r1, int c1, int r2, int c2)
    {
        // base case
        if (r1 > r2 || c1 > c2)
            return;
        if (r1 < 0 || r1 >= ROWS || c1 < 0 || c1 >= COLS)
            return;
        if (r2 < 0 || r2 >= ROWS || c2 < 0 || c2 >= COLS)
            return;

        if (memo[r1, c1, r2, c2] != 0)
        {
            return;
        }

        bool found = SumToTarget(target, r1, c1, r2, c2);
        memo[r1, c1, r2, c2] = found ? 1 : -1;
        if (found)
        {
            ans++;
        }

        // recursive case
        foreach (var dir in directions)
        {
            int rDiff = dir[0];
            int cDiff = dir[1];
            Helper(target, r1 + rDiff, c1 + cDiff, r2, c2);
            Helper(target, r1, c1, r2 + rDiff, c2 + cDiff);
        }
    }

    public bool SumToTarget(int target, int r1, int c1, int r2, int c2)
    {
        int sum = ps[r2 + 1, c2 + 1] - ps[r1, c2 + 1] - ps[r2 + 1, c1] + ps[r1, c1];
        if (sum == target)
            Console.WriteLine($"({r1},{c1},{r2},{c2})");
        return sum == target;
    }

    // Vertical 1D Prefix Sum
    // Time: O(R*C^2)
    // Space: O(R*C)
    public int NumSubmatrixSumTarget1(int[][] matrix, int target)
    {
        this.matrix = matrix;
        this.ROWS = matrix.Length;
        this.COLS = matrix[0].Length;

        ps = new int[ROWS + 1, COLS + 1];
        for (int r = 1; r < ROWS + 1; r++)
        {
            for (int c = 1; c < COLS + 1; c++)
            {
                ps[r, c] = ps[r - 1, c] + ps[r, c - 1] - ps[r - 1, c - 1] + matrix[r - 1][c - 1];
            }
        }

        int count = 0;
        int currSum = 0;
        var h = new Dictionary<int, int>();
        // resduce 2D problem to 1D problem
        // by fixing two columns c1 and c2 and 
        // computing 1D prefix sum for all matrices using [c1...c2] columns
        for (int c1 = 1; c1 < COLS + 1; c1++)
        {
            for (int c2 = c1; c2 < COLS + 1; c2++)
            {
                h.Clear();
                h[0] = 1;
                for (int r = 1; r < ROWS + 1; r++)
                {
                    // current 1D prefix sum
                    currSum = ps[r, c2] - ps[r, c1 - 1];
                    // add subarrays which sum up to (currSum - target)
                    count += h.GetValueOrDefault(currSum - target, 0);
                    // save current prefix sum
                    h[currSum] = h.GetValueOrDefault(currSum, 0) + 1;
                }
            }
        }

        return count;
    }
}

var s = new Solution();
var matrix = new int[][] { new int[] { 0, 1, 0 }, new int[] { 1, 1, 1, }, new int[] { 0, 1, 0 } };
// [[0,1,1,1,0,1],[0,0,0,0,0,1],[0,0,1,0,0,1],[1,1,0,1,1,0],[1,0,0,1,0,0]]
matrix = new int[][] { new int[] { 0, 1, 1, 1, 0, 1 }, new int[] { 0, 0, 0, 0, 0, 1 }, new int[] { 0, 0, 1, 0, 0, 1 }, new int[] { 1, 1, 0, 1, 1, 0 }, new int[] { 1, 0, 0, 1, 0, 0 } };
var target = 0;
var result = s.NumSubmatrixSumTarget(matrix, target);
Console.WriteLine(result);
