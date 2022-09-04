public class Solution
{
    // Sliding Window
    // Time: O(n)
    // Space: O(1)
    public int LongestNiceSubarray(int[] nums)
    {
        int n = nums.Length;
        int i = 0, j = 0;
        int and = 0;
        int result = 0;
        for (j = 0; j < n; j++)
        {
            while ((and & nums[j]) != 0)
            {
                and ^= nums[i];
                i++;
            }
            and |= nums[j];
            result = Math.Max(result, j - i + 1);
        }

        return result;
    }
}
