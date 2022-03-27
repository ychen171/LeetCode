public class Solution
{
    // Brute force + sorting
    // Time: O(n log n)
    // Space: O(n)
    public int[] SortedSquares(int[] nums)
    {
        int[] result = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            result[i] = nums[i] * nums[i];
        }
        Array.Sort(result);
        return result;
    }

    // Two pointers | similar to MergeSort
    // Time: O(n)
    // Space: O(n)
    public int[] SortedSquares1(int[] nums)
    {
        int n = nums.Length;
        int left = 0;
        int right = n - 1;
        int[] result = new int[n];
        for (int i = n - 1; i >= 0; i--)
        {
            int selected;
            if (Math.Abs(nums[left]) < Math.Abs(nums[right]))
                selected = nums[right--];
            else
                selected = nums[left++];
            result[i] = selected * selected;
        }

        return result;
    }
}

