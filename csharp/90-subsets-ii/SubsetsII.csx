public class Solution
{
    public IList<IList<int>> SubsetsWithDup(int[] nums)
    {
        // order doesn't matter
        // input has duplicates, output can have duplicates
        // num cannot be reused
        // subset is unique

        Array.Sort(nums);
        var result = new List<IList<int>>();
        Backtrack(nums, new List<int>(), 0, result);
        return result;
    }

    // Time: O(n * 2^n)
    // n = nums.Length
    // Space: O(n)
    private void Backtrack(int[] nums, IList<int> combo, int nextStart, IList<IList<int>> result)
    {
        // base case
        result.Add(new List<int>(combo));

        // recursive case
        for (int i = nextStart; i < nums.Length; i++)
        {
            // subset cannot contain duplicates
            // if (i > 0 && nums[i - 1] == nums[i])
            //     continue;
            
            // subset can contain duplicates
            // don't count twice if all values in two subsets are same
            if (i != nextStart && nums[i - 1] == nums[i])
                continue;
            combo.Add(nums[i]);
            Backtrack(nums, combo, i + 1, result);
            combo.RemoveAt(combo.Count - 1);
        }
    }
}
