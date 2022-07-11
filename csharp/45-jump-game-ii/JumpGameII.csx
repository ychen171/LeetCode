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
        return Helper(nums, n - 1, memo);
    }

    public int Helper(int[] nums, int index, int[] memo)
    {
        if (memo[index] != int.MaxValue)
            return memo[index];

        int n = nums.Length;
        // base case
        if (index == 0)
            return 0;

        // recursive case
        int jumps = int.MaxValue;
        for (int prevIndex = 0; prevIndex < index; prevIndex++)
        {
            if (prevIndex + nums[prevIndex] >= index)
            {
                var prevJumps = Helper(nums, prevIndex, memo);
                if (prevJumps == int.MaxValue) // unreachable
                    continue;
                jumps = Math.Min(jumps, prevJumps + 1);
            }
        }
        memo[index] = jumps;
        return jumps;
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
