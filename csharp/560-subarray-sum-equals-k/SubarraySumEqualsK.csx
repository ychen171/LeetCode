public class Solution
{
    // Brute force
    // Time: O(n^3)
    // Space: O(1)
    public int SubarraySum1(int[] nums, int k)
    {
        int count = 0;
        for (int start = 0; start < nums.Length; start++)
        {
            for (int end = start + 1; end <= nums.Length; end++)
            {
                int sum = 0;
                for (int i = start; i < end; i++)
                    sum += nums[i];
                if (sum == k)
                    count++;
            }
        }

        return count;
    }

    // DP | Tabulation | Bottom-up
    // Time: O(n^2)
    // Space: O(n)
    public int SubarraySum2(int[] nums, int k)
    {
        int count = 0;
        int[] sum = new int[nums.Length + 1];
        sum[0] = 0;
        for (int i = 1; i < nums.Length + 1; i++)
            sum[i] = sum[i - 1] + nums[i - 1];
        for (int start = 0; start < nums.Length; start++)
        {
            for (int end = start + 1; end <= nums.Length; end++)
            {
                if (sum[end] - sum[start] == k)
                    count++;
            }
        }

        return count;
    }

    // Bottom-up | in-place
    // Time: O(n^2)
    // Space: O(1)
    public int SubarraySum3(int[] nums, int k)
    {
        int count = 0;
        for (int start = 0; start < nums.Length; start++)
        {
            int sum = 0;
            for (int end = start; end < nums.Length; end++)
            {
                sum += nums[end];
                if (sum == k)
                    count++;
            }
        }

        return count;
    }

    // Cumulative sum and count dictionary
    // Time: O(n)
    // Space: O(n)
    public int SubarraySum4(int[] nums, int k)
    {
        int count = 0;
        int sum = 0;
        var sumCountDict = new Dictionary<int, int>();
        sumCountDict[0] = 1;
        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
            if (sumCountDict.ContainsKey(sum - k))
            {
                count += sumCountDict[sum - k];
            }
            sumCountDict[sum] = sumCountDict.GetValueOrDefault(sum, 0) + 1;
        }

        return count;
    }

    public int SubarraySum5(int[] nums, int k)
    {
        int n = nums.Length;
        var preSum = new int[n + 1];
        var countDict = new Dictionary<int, int>();
        countDict[0] = 1;
        int result = 0;

        for (int i = 1; i < n + 1; i++)
        {
            preSum[i] = preSum[i - 1] + nums[i - 1];
            int need = preSum[i] - k;
            if (countDict.ContainsKey(need))
            {
                result += countDict[need];
            }
            countDict[preSum[i]] = countDict.GetValueOrDefault(preSum[i], 0) + 1;
        }

        return result;
    }
}
