public class Solution
{
    // DP | Bottom-up | Tabulation | Iteration
    // Time: O(n^2)
    // Space: O(n)
    public int Jump(int[] nums)
    {
        // initialize table with default value
        int n = nums.Length;
        var dp = new int[n];
        Array.Fill(dp, int.MaxValue);
        // seed the trivial answer into the table
        dp[0] = 0;
        // fill further positions with current position
        for (int i = 0; i < n; i++)
        {
            var maxLen = nums[i];
            for (int j = 1; j < n && j - i <= maxLen; j++)
                dp[j] = Math.Min(dp[j], dp[i] + 1);
        }
        return dp[n - 1];
    }

    // DP | Top-down | Memoization | Recursion
    // Time: O(n^2)
    // Space: O(n)
    public int JumpR(int[] nums)
    {
        int n = nums.Length;
        if (n == 1)
            return 0;
        var memo = new int[n];
        Array.Fill(memo, int.MaxValue);
        return Helper(nums, 0, memo);
    }

    public int Helper(int[] nums, int index, int[] memo)
    {
        int n = nums.Length;
        // base case
        if (index >= n - 1)
            return 0;
        
        if (memo[index] != int.MaxValue)
            return memo[index];

        // recursive case
        int result = int.MaxValue;
        int len = nums[index];
        for (int jump = 1; jump <= len; jump++)
        {
            var nextIndex = index + jump;
            var subResult = Helper(nums, nextIndex, memo);
            if (subResult == int.MaxValue)
                continue;
            result = Math.Min(result, subResult + 1);
        }
        memo[index] = result;
        return result;
    }

    // Greedy
    // Time: O(n)
    // Space: O(1)
    public int JumpGreedy(int[] nums)
    {
        int jumps = 0;
        int currentJumpEnd = 0;
        int farthest = 0;
        for (int i = 0; i < nums.Length - 1; i++)
        {
            farthest = Math.Max(farthest, i + nums[i]);
            if (i == currentJumpEnd)
            {
                jumps++;
                currentJumpEnd = farthest;
            }
        }

        return jumps;
    }
}
