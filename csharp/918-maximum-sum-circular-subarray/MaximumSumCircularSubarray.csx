public class Solution
{
    // Prefix Sum
    // Time: O(n)
    // Space: O(n)
    public int MaxSubarraySumCircular(int[] nums)
    {
        /*
            5   -3  5   5   -3  5
            0   1   2   0   1   2
            arraySum[i, j] = preSum[j+1] - preSum[i]
            1. find maxSubarraySum in nums

            2. find minSubarraySum in nums
            maxSubarraySum = totalSum - minSubarraySum

            3. compare two maxSubarraySum
            edge case: nums are all negative, return the max num
        */

        // compute preSum
        int n = nums.Length;
        var preSum = new int[n + 1];
        for (int i = 0; i < n; i++)
            preSum[i + 1] = preSum[i] + nums[i];

        // 1. 
        int minPreSum = int.MaxValue;
        int maxSum = int.MinValue;
        for (int i = 0; i < n; i++)
        {
            minPreSum = Math.Min(minPreSum, preSum[i]);
            maxSum = Math.Max(maxSum, preSum[i + 1] - minPreSum);
        }
        // 2. 
        int totalSum = preSum.Last();
        int minSum = int.MaxValue;
        int maxPreSum = int.MinValue;
        for (int i = 0; i < n; i++)
        {
            maxPreSum = Math.Max(maxPreSum, preSum[i]);
            minSum = Math.Min(minSum, preSum[i + 1] - maxPreSum);
        }

        return maxSum > 0 ? Math.Max(maxSum, totalSum - minSum) : maxSum;
    }
}

var sln = new Solution();
var nums = new int[] { 5, -3, 5 };
var result = sln.MaxSubarraySumCircular(nums);
Console.WriteLine(result);
