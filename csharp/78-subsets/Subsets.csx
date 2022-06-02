public class Solution
{
    // Backtracking | Subsets
    // Time: O(n * 2^n)
    // Space: O(n)
    public IList<IList<int>> Subsets(int[] nums)
    {
        // elements in nums are unique
        // find all combinations. Order doesn't matter
        var result = new List<IList<int>>();
        Backtrack(nums, new List<int>(), 0, result);
        return result;
    }

    private void Backtrack(int[] nums, IList<int> combo, int nextStart, IList<IList<int>> result)
    {
        // base case
        result.Add(new List<int>(combo));

        // recursive case
        for (int i = nextStart; i < nums.Length; i++)
        {
            combo.Add(nums[i]);
            Backtrack(nums, combo, i + 1, result);
            combo.RemoveAt(combo.Count - 1);
        }
    }
}
