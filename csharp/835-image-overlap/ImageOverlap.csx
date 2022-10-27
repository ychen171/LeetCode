public class Solution
{
    // Brute force
    // Time: O(n^4)
    // Space: O(1)
    public int LargestOverlap(int[][] img1, int[][] img2)
    {
        int maxOverlaps = 0;
        for (int yShift = 0; yShift < img1.Length; yShift++)
        {
            for (int xShift = 0; xShift < img1.Length; xShift++)
            {
                maxOverlaps = Math.Max(maxOverlaps, ShiftAndCount(xShift, yShift, img1, img2));
                maxOverlaps = Math.Max(maxOverlaps, ShiftAndCount(xShift, yShift, img2, img1));
            }
        }
        return maxOverlaps;
    }

    private int ShiftAndCount(int xShift, int yShift, int[][] matrix, int[][] reference)
    {
        int leftShiftCount = 0, rightShiftCount = 0;
        int rRow = 0;
        for (int mRow = yShift; mRow < matrix.Length; mRow++)
        {
            int rCol = 0;
            for (int mCol = xShift; mCol < matrix[0].Length; mCol++)
            {
                if (matrix[mRow][mCol] == 1 && matrix[mRow][mCol] == reference[rRow][rCol])
                    leftShiftCount++;
                if (matrix[mRow][rCol] == 1 && matrix[mRow][rCol] == reference[rRow][mCol])
                    rightShiftCount++;
                rCol++;
            }
            rRow++;
        }
        return Math.Max(leftShiftCount, rightShiftCount);
    }
}
