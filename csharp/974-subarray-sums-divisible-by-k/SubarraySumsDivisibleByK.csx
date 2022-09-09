public class Solution
{
    // Two Sum of Prefix Sum | prefix Sum + dictionary of count
    // Time: O(n)
    // Space: O(n)
    public int SubarraysDivByK(int[] nums, int k)
    {
        /*
            (preSum[j] - preSum[i]) % k == 0
            preSum[j] % k - preSum[i] % k == 0
            preSum[j] % k == preSum[i] % k
        */
        var n = nums.Length;
        var preSum = new int[n + 1];
        for (int i = 1; i < n + 1; i++)
            preSum[i] = (preSum[i - 1] + nums[i - 1]) % k;

        var countDict = new Dictionary<int, int>();
        countDict[0] = 1;
        int result = 0;
        for (int i = 1; i < n + 1; i++)
        {
            var remainder = preSum[i] % k;
            // make sure remainder is positive
            if (remainder < 0)
                remainder += k;
            if (countDict.ContainsKey(remainder))
            {
                result += countDict[remainder];
            }
            countDict[remainder] = countDict.GetValueOrDefault(remainder, 0) + 1;
        }

        return result;
    }
}
