public class Solution
{
    // Binary Search
    // Time: O(log n)
    // Space: O(1)
    public int Search(int[] nums, int target)
    {
        int n = nums.Length;
        int left = 0;
        int right = n - 1;
        while (left < right)
        {
            int mid = left + (right - left) / 2;
            if (nums[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid;
            }
        }

        return nums[left] == target ? left : -1;
    }
}
