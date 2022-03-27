public class Solution
{
    // Brute force
    // Time: O(n)
    // Space: O(1)
    public int FindMaxConsecutiveOnes(int[] nums)
    {
        int maxCount = 0;
        int count = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 1)
            {
                count++;
            }
            else
            {
                maxCount = Math.Max(maxCount, count);
                count = 0;
            }
        }
        maxCount = Math.Max(maxCount, count);

        return maxCount;
    }
}
