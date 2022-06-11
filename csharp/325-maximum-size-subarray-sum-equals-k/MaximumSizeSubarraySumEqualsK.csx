public class Solution
{
    // Prefix Sum + Dictionary + Two Pointers
    // Time: O(n)
    // Space: O(n)
    public int MaxSubArrayLen(int[] nums, int k)
    {
        // 1  -1  5  -2  3
        // 0  1   0  5   3  6
        // left = 0, right = 4, 3 - 0 = k, 

        // create prefix sum array
        // starting from left = 0, right = 0
        // foreach right, find left, where prefixSum[right] - prefixSum[left] == k

        int n = nums.Length;
        var prefixSum = new int[n + 1];
        var leftMostIndexDict = new Dictionary<int, int>();
        leftMostIndexDict[0] = 0;
        for (int i = 1; i < n + 1; i++)
        {
            prefixSum[i] = prefixSum[i - 1] + nums[i - 1];
            if (!leftMostIndexDict.ContainsKey(prefixSum[i]))
                leftMostIndexDict[prefixSum[i]] = i;
        }

        int left = 0;
        int right = 0;
        int maxLen = 0;
        // foreach right, find left, so that prefixSum[left] == prefixSum[right] - k
        for (right = 0; right < n + 1; right++)
        {
            int target = prefixSum[right] - k;
            if (!leftMostIndexDict.ContainsKey(target))
                continue;
            left = leftMostIndexDict[target];
            if (left <= right)
                maxLen = Math.Max(maxLen, right - left);
        }

        return maxLen;
    }
}
