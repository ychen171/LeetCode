public class Solution
{
    // Sliding Window + Bitwise
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

    public int LongestNiceSubarray1(int[] nums)
    {
        int n = nums.Length;
        int left = 0, right = 0;
        int result = 0;
        while (right < n)
        {
            int i = right - 1;
            while (i >= left)
            {
                if ((nums[i] & nums[right]) != 0)
                {
                    left = i + 1;
                    break;
                }
                i--;
            }
            result = Math.Max(result, right - left + 1);
            right++;
        }

        return result;
    }
}
