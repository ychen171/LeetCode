public class Solution
{
    // Backtracking
    public IList<IList<int>> FourSum(int[] nums, int target)
    {
        var combo = new List<int>();
        var result = new List<IList<int>>();
        Array.Sort(nums);
        Backtrack(nums, target, combo, 0, 0, result);
        return result;
    }

    private void Backtrack(int[] nums, int target, List<int> combo, int sum, int nextStart, IList<IList<int>> result)
    {
        // base case
        if (combo.Count == 4)
        {
            if (sum == target)
            {
                result.Add(new List<int>(combo));
                return;
            }
            else
                return;
        }
        // recursive case
        for (int i = nextStart; i < nums.Length; i++)
        {
            if (i > nextStart && nums[i] == nums[i-1])
                continue;
            combo.Add(nums[i]);
            sum += nums[i];
            Backtrack(nums, target, combo, sum, i + 1, result);
            combo.RemoveAt(combo.Count - 1);
            sum -= nums[i];
        }
    }
}
