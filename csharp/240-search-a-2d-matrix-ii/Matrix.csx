public class Solution
{
    // iterate through rows, bineary search columns
    // Time: O(m log(n))
    // Space: O(1)
    public bool SearchMatrix(int[][] matrix, int target)
    {
        for (int i = 0; i < matrix.Length; i++)
        {
            var nums = matrix[i];
            var index = Search(nums, target);
            if (index != -1)
                return true;
        }
        return false;
    }

    public int Search(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length - 1;

        while (left < right)
        {
            var mid = left + (right - left) / 2;
            if (nums[mid] < target)
                left = mid + 1;
            else
                right = mid;
        }

        if (nums[left] == target) return left;
        return -1;
    }

    // Divide and Conquer on row + Binary Search on col
    // Time: O((log m) * (log n))
    // Space: O(m)
    public bool SearchMatrix1(int[][] matrix, int target)
    {
        return Helper(matrix, 0, matrix.Length - 1, target);
    }
    public bool Helper(int[][] matrix, int start, int end, int target)
    {
        // base case
        if (start == end) return BinarySearch(matrix[start], target);
        // divide
        var mid = start + (end - start) / 2;
        // conquer
        var isTop = Helper(matrix, start, mid, target);
        var isBot = Helper(matrix, mid + 1, end, target);
        // combine
        return isTop || isBot;
    }
    public bool BinarySearch(int[] nums, int target)
    {
        var left = 0;
        var right = nums.Length - 1;
        while (left < right)
        {
            var mid = left + (right - left) / 2;
            if (nums[mid] == target) return true;
            else if (nums[mid] < target) left = mid + 1;
            else right = mid;
        }
        return nums[left] == target;
    }

    // 2D Divide and Conquer
    // Time: O()
    // Space: O()
    public bool SearchMatrix2(int[][] matrix, int target)
    {
        return DivideAndConquer(matrix, 0, matrix.Length - 1, 0, matrix[0].Length - 1, target);
    }
    public bool DivideAndConquer(int[][] matrix, int rowStart, int rowEnd, int colStart, int colEnd, int target)
    {
        // base case
        if (rowStart > rowEnd || colStart > colEnd) return false;
        if (rowStart == rowEnd && colStart == colEnd) return matrix[rowStart][colStart] == target;
        var rowMid = rowStart + (rowEnd - rowStart) / 2;
        var colMid = colStart + (colEnd - colStart) / 2;
        var pivot = matrix[rowMid][colMid];
        if (pivot == target) return true;
        // divide
        // conquer
        bool topRight = DivideAndConquer(matrix, rowStart, rowMid, colMid + 1, colEnd, target);
        bool botLeft = DivideAndConquer(matrix, rowMid + 1, rowEnd, colStart, colMid, target);
        bool topLeft = false;
        bool botRight = false;
        if (pivot < target) // discard top left, keep bottom right
        {
            botRight = DivideAndConquer(matrix, rowMid + 1, rowEnd, colMid + 1, colEnd, target);
            return botRight || topRight || botLeft;
        }
        else // keep top left, discard bottom right
        {
            topLeft = DivideAndConquer(matrix, rowStart, rowMid, colStart, colMid, target);
            return topLeft || topRight || botLeft;
        }
    }

    // Approach 4: Search Space Reduction
    // Time: O(m+n)
    // Space: O(1)
    public bool SearchMatrix4(int[][] matrix, int target)
    {
        int row = matrix.Length - 1;
        int col = 0;

        while (row > -1 && col < matrix[0].Length)
        {
            if (matrix[row][col] == target)
                return true;
            else if (matrix[row][col] < target)
                col++;
            else
                row--;
        }

        return false;
    }
}

var s = new Solution();
var matrix = new int[][] { new int[] { 1, 4, 7, 11, 15 }, new int[] { 2, 5, 8, 12, 19 }, new int[] { 3, 6, 9, 16, 22 }, new int[] { 10, 13, 14, 17, 24 }, new int[] { 18, 21, 23, 26, 30 } };
Console.WriteLine(s.SearchMatrix(matrix, 5));
Console.WriteLine(s.SearchMatrix(matrix, 20));
Console.WriteLine();

Console.WriteLine(s.SearchMatrix4(matrix, 5));
Console.WriteLine(s.SearchMatrix4(matrix, 20));
Console.WriteLine();




