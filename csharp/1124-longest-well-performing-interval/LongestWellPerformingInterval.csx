public class Solution
{
    // Two Sum of Prefix Sum + Dictionary of Index
    // Time: O(n)
    // Space: O(n)
    public int LongestWPI(int[] hours)
    {
        /*
                9   9   6   0   6   6   9
                1   1   -1  -1  -1  -1  1
            0   1   2   1   0   -1  -2  -1

                6   6   9
                -1  -1  1
            0   -1  -2  -1


                6   9   9
                -1  0   1
            0   -1  0   1
        */
        var n = hours.Length;
        // create prefix sum
        var nums = new int[n];
        for (int i = 0; i < n; i++)
            nums[i] = hours[i] > 8 ? 1 : -1;
        var preSum = new int[n + 1];
        for (int i = 1; i < n + 1; i++)
            preSum[i] = preSum[i - 1] + nums[i - 1];

        // find the longest subarray with positive sum
        // sum[i, j] >= 1
        // preSum[j] - preSum[i] >= 1
        int ans = 0;
        var valToIndex = new Dictionary<int, int>();
        for (int i = 0; i < n + 1; i++)
        {
            if (preSum[i] >= 1)
                ans = Math.Max(ans, i);
            if (valToIndex.ContainsKey(preSum[i] - 1))
                ans = Math.Max(ans, i - valToIndex[preSum[i] - 1]);

            if (!valToIndex.ContainsKey(preSum[i]))
                valToIndex[preSum[i]] = i;
        }

        return ans;
    }
}

var sln = new Solution();
var hours = new int[] { 9, 9, 6, 0, 6, 6, 9 };
var result = sln.LongestWPI(hours);
Console.WriteLine(result);

