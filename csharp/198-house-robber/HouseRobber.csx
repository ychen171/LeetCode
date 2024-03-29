
public class Solution
{
    // Recursion | Memoization | Top-down | DP
    // n = nums.Length
    // Time: O(n)
    // Space: O(n)
    public int RobMemo(int[] nums)
    {
        return Helper(nums, nums.Length, new Dictionary<int, int>());
    }
    public int Helper(int[] nums, int n, Dictionary<int, int> memo)
    {
        if (memo.ContainsKey(n)) return memo[n];
        if (n == 1) return nums[0];
        if (n == 2) return Math.Max(nums[0], nums[1]);
        var result = Math.Max(Helper(nums, n - 1, memo), Helper(nums, n - 2, memo) + nums[n - 1]);
        memo[n] = result;
        return result;
    }

    // Iteration | Tabulation | Bottom-up | DP
    // n = nums.Length
    // Time: O(n)
    // Space: O(n)
    public int RobTabulation(int[] nums)
    {
        var table = new List<int>();
        // initialize the table with default value
        for (int i = 0; i < nums.Length; i++)
            table.Add(0);
        // seed the trivial answer into the table
        table[0] = nums[0];
        if (nums.Length > 1)
            table[1] = Math.Max(nums[0], nums[1]);
        // fill further positions with current position
        for (int i = 2; i < nums.Length; i++)
            table[i] = Math.Max(table[i - 1], table[i - 2] + nums[i]);

        return table[nums.Length - 1];
    }

    // DP Template
    // Time: O(n)
    // Space: O(n)
    public int RobTemplate(int[] nums)
    {
        /*
            states: dp[i][s], i: house index [0, n-1], s: 0 = not robbed, 1 = robbed
            options: rob, skip
            goal: Math.Max(dp[n-1][0], dp[n-1][1])

            dp[i][0] = Math.Max(dp[i-1][1], dp[i-1][0])
            dp[i][1] = Math.Max(dp[i-1][1], dp[i-1][0] + nums[i])

            base case:
            dp[-1][0] = 0
            dp[-1][1] = int.MinValue
        */

        int n = nums.Length;
        var dp = new int[n][];
        for (int i = 0; i < n; i++)
            dp[i] = new int[2];

        for (int i = 0; i < n; i++)
        {
            // base case
            if (i - 1 == -1)
            {
                dp[i][0] = 0;
                dp[i][1] = nums[i];
                continue;
            }
            dp[i][0] = Math.Max(dp[i - 1][1], dp[i - 1][0]);
            dp[i][1] = Math.Max(dp[i - 1][1], dp[i - 1][0] + nums[i]);
        }

        return Math.Max(dp[n - 1][0], dp[n - 1][1]);
    }
}

var nums1 = new int[] { 1, 2, 3, 1 };
var nums2 = new int[] { 2, 7, 9, 3, 1 };
var nums3 = new int[] { 2, 1, 1, 2 };
var s = new Solution();

Console.WriteLine(s.RobMemo(nums1));
Console.WriteLine(s.RobMemo(nums2));
Console.WriteLine(s.RobMemo(nums3));


Console.WriteLine(s.RobTabulation(nums1));
Console.WriteLine(s.RobTabulation(nums2));
Console.WriteLine(s.RobTabulation(nums3));