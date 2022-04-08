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
            {
                return 1;
            }
            else
            {
                return 0;
            }
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

}