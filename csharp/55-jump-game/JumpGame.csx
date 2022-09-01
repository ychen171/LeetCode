public class Solution
{
    // DP | Top-down | Memoization | Recursion
    // Time: O(n^2)
    // Space: O(n)
    private Dictionary<int, bool> memo = new Dictionary<int, bool>();
    public bool CanJump(int[] nums)
    {
        return Helper(nums, 0);
    }
    private bool Helper(int[] nums, int start)
    {
        if (memo.ContainsKey(start)) return memo[start];
        if (start < nums.Length - 1 && nums[start] == 0) return false;
        if (start + nums[start] >= nums.Length - 1) return true;
        int maxLen = nums[start];
        bool result = false;
        for (int i = 1; i <= maxLen; i++)
        {
            if (Helper(nums, start + i))
            {
                result = true;
                break;
            }
        }
        memo[start] = result;
        return result;
    }

    // DP | Bottom-up | Tabulation | Iteration
    // Time: O(n^2)
    // Space: O(n)
    public bool CanJumpTabulation(int[] nums)
    {
        int n = nums.Length;
        if (n == 1) return true;
        // initialize table with default value
        bool[] dp = new bool[nums.Length];
        // seed the trivial answer into the table
        dp[n - 1] = true;
        // fill further positions with current position
        for (int i = n - 2; i >= 0; i--)
        {
            var maxLen = nums[i];
            for (int j = i + 1; j <= Math.Min(i + maxLen, n - 1); j++)
            {
                if (dp[j])
                {
                    dp[i] = true;
                    break;
                }
            }
        }

        return dp[0];
    }

    // Greedy
    // Time: O(n)
    // Space: O(1)
    public bool CanJumpGreedy(int[] nums)
    {
        int lastPos = nums.Length - 1;
        for (int i = nums.Length - 1; i >= 0; i--)
        {
            if (i + nums[i] >= lastPos)
                lastPos = i;
        }

        return lastPos == 0;
    }

    // Greedy
    // Time: O(n)
    // Space: O(1)
    public bool CanJumpGreedy1(int[] nums)
    {
        int n = nums.Length;
        int farthest = 0;
        for (int i = 0; i < n - 1; i++)
        {
            farthest = Math.Max(farthest, i + nums[i]);
            if (farthest <= i) // stuck
                return false;
        }

        return farthest >= n - 1;
    }
}

var s = new Solution();
Console.WriteLine(s.CanJumpTabulation(new int[] { 2, 3, 1, 1, 4 }));