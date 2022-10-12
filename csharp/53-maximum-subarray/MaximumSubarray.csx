public class Solution
{
    // DP
    // Time: O(n)
    // Space: O(n)
    public int MaxSubArray(int[] nums)
    {
        /*
            states: dp[i]: largest sum from the subarray ending at i, i = [0, n-1]
            goal: dp.Max()
            option: add to previous group, start a new group
            
            dp[i] = Math.Max(dp[i-1] + nums[i], nums[i])
            
            base case:
            dp[0] = Math.Max(dp[-1] + nums[0], nums[0]) = nums[0]
        */

        var n = nums.Length;
        var dp = new int[n];
        for (int i = 0; i < n; i++)
        {
            if (i == 0)
            {
                dp[i] = nums[i];
                continue;
            }
            dp[i] = Math.Max(dp[i - 1] + nums[i], nums[i]);
        }

        return dp.Max();
    }

    // Sliding Window
    // Time: O(n)
    // Space: O(1)
    public int MaxSubArray1(int[] nums)
    {
        int n = nums.Length;
        var windowSum = 0;
        var result = int.MinValue;
        // [left, right)
        int left = 0, right = 0;
        while (right < n)
        {
            windowSum += nums[right];
            right++;

            result = Math.Max(result, windowSum);

            while (left <= right && windowSum < 0)
            {
                windowSum -= nums[left];
                left++;
            }
        }
        return result;
    }

    // Prefix Sum
    // Time: O(n)
    // Space: O(n)
    public int MaxSubArray2(int[] nums)
    {
        /*
            subarraySum[i, j] = preSum[j+1] - preSum[i]

            max sub array ending at index j
            preSum[j+1] - min(preSum[i]), where i = [0, j]
        */
        int n = nums.Length;
        var preSum = new int[n + 1];
        for (int i = 0; i < n; i++)
            preSum[i + 1] = preSum[i] + nums[i];

        int result = int.MinValue;
        int minPreSum = int.MaxValue;
        for (int i = 0; i < n; i++)
        {
            minPreSum = Math.Min(minPreSum, preSum[i]);
            result = Math.Max(result, preSum[i + 1] - minPreSum);
        }
        return result;
    }
}