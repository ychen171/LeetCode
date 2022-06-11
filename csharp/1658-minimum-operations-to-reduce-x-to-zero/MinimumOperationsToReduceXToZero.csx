public class Solution
{
    // Sliding Window + Prefix Sum
    // Time: O(n)
    // Space: O(n)
    public int MinOperations(int[] nums, int x)
    {
        int n = nums.Length;
        // build prefix sum
        // 1 1 4 2 3
        // 0 1 2 6 8 11    prefixSum
        // total sum = 11, x = 5, target = 6
        // left = 0, right = 3, n = 5
        // ans = n - (right - left)

        // 5  2  3  1  1
        // 0  5  7 10 11 12 prefixSum
        // total sum = 12, x = 5, target = 7
        // left = 1, right = 5, maxLen = 4, n = 5
        // ans = 1
        var prefixSum = new int[n + 1];
        for (int i = 1; i < n + 1; i++)
            prefixSum[i] = prefixSum[i - 1] + nums[i - 1];
        int totalSum = prefixSum.Last();
        // find the longest subarray where array sum = total sum - x
        int target = totalSum - x;
        if (target < 0)
            return -1;
        if (target == 0)
            return n;

        // sliding window
        int left = 0;
        int right = 0;
        int maxLen = 0;
        for (right = 0; right < n + 1; right++)
        {
            while (prefixSum[right] - prefixSum[left] > target)
            {
                left++;
            }
            if (prefixSum[right] - prefixSum[left] == target)
            {
                maxLen = Math.Max(maxLen, right - left);
            }
        }

        return maxLen == 0 ? -1 : n - maxLen;
    }
}
