public class Solution
{
    // Prefix Sum
    // Time: O(n^2)
    // Space: O(n)
    public bool CheckSubarraySum(int[] nums, int k)
    {
        int n = nums.Length;
        var preSum = new int[n + 1];
        for (int i = 1; i < n + 1; i++)
            preSum[i] = preSum[i - 1] + nums[i - 1];

        // [left, right)
        for (int right = 0; right < n + 1; right++)
        {
            for (int left = 0; left + 1 < right; left++)
            {
                int currSum = preSum[right] - preSum[left];
                if (currSum % k == 0)
                    return true;
            }
        }

        return false;
    }

    // Two Sum of Prefix Sum | Two Sum + Dictionary
    // Time: O(n)
    // Space: O(n)
    public bool CheckSubarraySum1(int[] nums, int k)
    {
        /*
            (preSum[j] - preSum[i]) % k == 0, j - i >= 2
            preSum[j] % k - preSum[i] % k == 0
        */
        // Prefix Sum
        int n = nums.Length;
        var preSum = new int[n + 1];
        for (int i = 1; i < n + 1; i++)
            preSum[i] = preSum[i - 1] + nums[i - 1];

        // Two Sum
        var valToIndex = new Dictionary<int, int>();
        for (int i = 0; i < n + 1; i++)
        {
            var val = preSum[i] % k;
            if (valToIndex.ContainsKey(val))
            {
                if (i - valToIndex[val] >= 2)
                    return true;
            }
            else
            {
                // keep the index as small as possible
                valToIndex[val] = i;
            }
        }

        return false;
    }
}
