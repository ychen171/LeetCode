public class Solution
{
    // Two Sum of Prefix Sum | Prefix Sum + Dictionary
    // Two Pass
    // Time: O(n)
    // Space: O(n)
    public int FindMaxLength(int[] nums)
    {
        /* 
        (preSum[j] - preSum[i]) * 2 == j - i, (j - i) % 2 == 0
        convert 0 to -1
        preSum[j] - preSum[i] == 0, Max(j - i)
        */

        int n = nums.Length;
        var preSum = new int[n + 1];
        for (int i = 1; i < n + 1; i++)
        {
            var num = nums[i - 1] == 0 ? -1 : 1;
            preSum[i] = preSum[i - 1] + num;
        }

        int result = 0;
        var valToIndex = new Dictionary<int, int>();
        for (int i = 0; i < n + 1; i++)
        {
            if (valToIndex.ContainsKey(preSum[i]))
            {
                result = Math.Max(result, i - valToIndex[preSum[i]]);
            }
            else
            {
                valToIndex[preSum[i]] = i;
            }
        }

        return result;
    }

    // Two Sum of Prefix Sum | Prefix Sum + Dictionary
    // One Pass
    // Time: O(n)
    // Space: O(n)
    public int FindMaxLength1(int[] nums)
    {
        int n = nums.Length;
        int preSum = 0;
        var valToIndex = new Dictionary<int, int>();
        valToIndex[0] = -1;
        int result = 0;
        for (int i = 0; i < n; i++)
        {
            preSum += (nums[i] == 0 ? -1 : 1);
            if (valToIndex.ContainsKey(preSum))
                result = Math.Max(result, i - valToIndex[preSum]);
            else
                valToIndex[preSum] = i;
        }
        return result;
    }
}
