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




