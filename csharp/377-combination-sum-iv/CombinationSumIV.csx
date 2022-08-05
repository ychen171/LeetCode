public class Solution
{
    // Backtracking | TLE
    // Time: O(N^T)
    // Space: O(T)
    int count = 0;
    public int CombinationSum4(int[] nums, int target)
    {
        // output order matters
        // input has no duplicate, output can have duplicates
        // num can be reused
        // output are unique
        var result = new List<List<int>>();
        Backtrack(nums, target);
        return count;
    }

    public void Backtrack(int[] nums, int target)
    {
        // base case
        if (target == 0)
        {
            count++;
            return;
        }
        if (target < 0)
            return;

        // recursive case
        for (int i = 0; i < nums.Length; i++)
        {
            Backtrack(nums, target - nums[i]);
        }
    }

    // DP | Memoization | Recursion
    // Time: O(T*N)
    // Space: O(T)
    public int CombinationSum4Memo(int[] nums, int target)
    {
        var memo = new int[target + 1];
        for (int i = 0; i < target + 1; i++)
            memo[i] = -1;
        return Helper(nums, target, memo);
    }

    public int Helper(int[] nums, int target, int[] memo)
    {
        if (target == 0)
            return 1;
        if (target < 0)
            return 0;

        if (memo[target] != -1)
            return memo[target];

        int ans = 0;
        foreach (var num in nums)
        {
            ans += Helper(nums, target - num, memo);
        }

        memo[target] = ans;
        return ans;
    }

    // DP | Tabulation | Iteration
    // Time: O(T*N)
    // Space: O(T)
    public int CombinationSum4Tabulation(int[] nums, int target)
    {
        /*
            states: dp[remain], remain: [0, target]
            options: nums
            goal: dp[target]

            dp[i] += dp[i-num]

            base cases:
            dp[0] = 1
            dp[-1] = 0
        */

        var n = nums.Length;
        var dp = new int[target + 1];
        dp[0] = 1;
        for (int i = 1; i <= target; i++)
        {
            foreach (var num in nums)
            {
                if (i - num < 0)
                    continue;
                dp[i] += dp[i - num];
            }
        }

        return dp[target];
    }
}

