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
        if (nums.Length == 1) return true;
        // initialize table with default value
        bool[] table = new bool[nums.Length];
        // seed the trivial answer into the table
        table[0] = true;
        // fill further positions with current position
        for (int i = 0; i < nums.Length; i++)
        {
            var maxLen = nums[i];
            if (table[i])
            {
                for (int k = 1; k <= maxLen && i + k < nums.Length; k++)
                {
                    Console.WriteLine($"table[{i+k}] = true");
                    table[i + k] = true;
                }
            }
        }

        return table[table.Length - 1];
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
}

var s = new Solution();
Console.WriteLine(s.CanJumpTabulation(new int[] { 2, 3, 1, 1, 4 }));