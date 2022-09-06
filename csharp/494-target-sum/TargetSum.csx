public class Solution
{
    // backtracking
    // Time: O(2^n)
    // Space: O(n)
    public int FindTargetSumWays(int[] nums, int target)
    {
        // backtracking, find the all permutations
        var result = new List<int>();
        Helper(nums, target, 0, 0, result);
        return result.Count;
    }

    private void Helper(int[] nums, int target, int currSum, int nextStart, List<int> result)
    {
        // base case
        if (nextStart == nums.Length)
        {
            if (currSum == target)
            {
                result.Add(currSum);
            }

            return;
        }

        // recursive case: two options: + or -
        int curr = 1 * nums[nextStart];
        currSum += curr;
        Helper(nums, target, currSum, nextStart + 1, result);
        currSum -= curr;

        curr = (-1) * nums[nextStart];
        currSum += curr;
        Helper(nums, target, currSum, nextStart + 1, result);
        currSum -= curr;
    }

    public int FindTargetSumWays1(int[] nums, int target)
    {
        // backtracking, find the all permutations
        var memo = new Dictionary<string, int>();
        return Helper(nums, target, 0, 0, memo);
    }

    private int Helper(int[] nums, int target, int currSum, int nextStart, Dictionary<string, int> memo)
    {
        string key = nextStart + "," + currSum;
        if (memo.ContainsKey(key))
            return memo[key];
        // base case
        if (nextStart == nums.Length)
        {
            if (currSum == target)
                return 1;
            else
                return 0;
        }

        // recursive case: two options: + or -
        int curr = 1 * nums[nextStart];
        currSum += curr;
        int addResult = Helper(nums, target, currSum, nextStart + 1, memo);
        currSum -= curr;

        curr = (-1) * nums[nextStart];
        currSum += curr;
        int minusResult = Helper(nums, target, currSum, nextStart + 1, memo);
        currSum -= curr;

        int result = addResult + minusResult;
        memo[key] = result;
        return result;
    }

    // DP | Tabulation | Knapsack
    // Time:  O(n * a)
    // Space: O(n * a)
    public int FindTargetSumWays2(int[] nums, int target)
    {
        /*
            A: sum of nums with positive sign
            B: sum of nums with negative sign
            
            A - B = target
            A = target + B
            A + A = target + B + A
            2A = target + totalSum
            A = (target + totalSum) / 2

            states: dp[i][j], i: the first i of items, [0, n] j: the weight, [0, a]
            dp: the number of ways
            options: 1. add, 2. skip
            goal: dp[n][a]

            dp[i][j] = dp[i-1][j] + dp[i-1][j-nums[i-1]]    // result if skip + result if add

            base case:
            dp[0][0] = 1
            dp[0][1,a] = 0
            dp[..][0] = 0
        */

        int n = nums.Length;
        int totalSum = nums.Sum();
        // edge case
        if (totalSum < Math.Abs(target))
            return 0;
        if ((target + totalSum) % 2 != 0)
            return 0;

        int a = (target + totalSum) / 2;
        var dp = new int[n + 1][];
        for (int i = 0; i < n + 1; i++)
        {
            dp[i] = new int[a + 1];
        }
        dp[0][0] = 1;

        for (int i = 1; i < n + 1; i++)
        {
            for (int j = 0; j < a + 1; j++)
            {
                if (j >= nums[i - 1])
                    dp[i][j] = dp[i - 1][j] + dp[i - 1][j - nums[i - 1]];
                else
                    dp[i][j] = dp[i - 1][j];
            }
        }

        return dp[n][a];
    }

}