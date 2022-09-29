public class Solution
{
    // Greedy
    // Time: O(n)
    // Space: O(1)
    public int LongestSubarray(int[] nums)
    {
        /*
        
            the bitwise AND of two differernt numbers will always be strictly less than
            the maximum of those two numbers
            so the longest subarray with max bitwise AND would be the subarray containing
            only the max numbers
                1   2   3   3   2   2
                01  10  11  11  10  10

            count length of the subarray where only maximum number is included
        */

        int result = 0, length = 0;
        int max = nums.Max();
        foreach (var num in nums)
        {
            if (num == max)
                length++;
            else
                length = 0;
            result = Math.Max(result, length);
        }

        return result;
    }
}
