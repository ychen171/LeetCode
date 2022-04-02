public class Solution
{
    // Sorting
    // Time: O(n log n)
    // Space: O(1)
    public int ArrayPairSum(int[] nums)
    {
        int n = nums.Length;
        if (n == 2) return nums.Min();
        Array.Sort(nums);
        int sum = 0;
        for (int i = 0; i < n; i += 2)
        {
            sum += nums[i];
        }

        return sum;
    }
}
