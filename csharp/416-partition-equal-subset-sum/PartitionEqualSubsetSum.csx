public class Solution
{
    // DP | DFS | Top-down | Memoization
    // Time: O(m * n)
    // Space: O(m * n)
    public bool CanPartition(int[] nums)
    {
        int n = nums.Length;
        if (n == 1)
            return false;
        // calculate total sum of all nums
        // goal: find the subset where sum == totalSum / 2
        // get totalSum
        int totalSum = nums.Sum();
        if (totalSum % 2 != 0)
            return false;
        int target = totalSum / 2;
        var memo = new int[target + 1][];
        for (int i = 0; i < target + 1; i++)
            memo[i] = new int[n];
        return DFS(nums, target, 0, memo);
    }

    private bool DFS(int[] nums, int target, int currIndex, int[][] memo)
    {
        int n = nums.Length;
        // base case
        if (target == 0)
            return true;
        if (target < 0 || currIndex == n)
            return false;
        if (memo[target][currIndex] != 0)
            return memo[target][currIndex] == 1 ? true : false;

        // recursive case
        bool ans = DFS(nums, target - nums[currIndex], currIndex + 1, memo) || DFS(nums, target, currIndex + 1, memo);
        memo[target][currIndex] = ans ? 1 : -1;
        return ans;
    }

    // DP | Tabulation 
    // Time: O(m * n)
    // Space: O(m * n)
    public bool CanPartition1(int[] nums)
    {
        int n = nums.Length;
        if (n == 1)
            return false;
        int totalSum = nums.Sum();
        if (totalSum % 2 != 0)
            return false;
        int target = totalSum / 2;
        // initialize the table with default values
        var table = new bool[n + 1][];
        // seed the trivial answer into the table
        for (int i = 0; i < n + 1; i++)
        {
            table[i] = new bool[target + 1];
            table[i][0] = true;
        }
        // fill further positions based on current position
        for (int i = 1; i < n + 1; i++)
        {
            for (int j = 0; j <= target; j++)
            {
                if (j >= nums[i - 1])
                    table[i][j] = table[i - 1][j - nums[i - 1]] || table[i - 1][j];
                else
                    table[i][j] = table[i - 1][j];
            }
        }

        return table[n][target];
    }

    // DP | Memoization Recursion | Subset
    // Time: O(m * n)
    // Space: O(m * n)
    Dictionary<string, bool> memo;
    public bool CanPartition2(int[] nums) 
    {
        /*
            find subsequence/subset whose sum == 0.5 * totalSum == target
            
            subset, order doesn't matter
            input has dups, output has dups
            number cannot be reused
            unique 
        */
        int n = nums.Length;
        if (n == 1) return false;
        var totalSum = nums.Sum();
        if (totalSum % 2 != 0) return false;
        
        memo = new Dictionary<string, bool>();
        var target = totalSum / 2;
        return Helper(nums, target, 0);
    }
    
    private bool Helper(int[] nums, int target, int nextStart)
    {
        int n = nums.Length;
        // base case
        if (target == 0)
            return true;
        if (target < 0 || nextStart == n)
            return false;
        
        var key = $"{target},{nextStart}";
        if (memo.ContainsKey(key))
            return memo[key];
        
        // recursive case
        bool result = false;
        for (int i = nextStart; i < n; i++)
        {
            if (i > nextStart && nums[i] == nums[i-1])
                continue;
            if (Helper(nums, target - nums[i], i + 1))
            {
                result = true;
                break;
            }
        }
        memo[key] = result;
        return result;
    }
}
