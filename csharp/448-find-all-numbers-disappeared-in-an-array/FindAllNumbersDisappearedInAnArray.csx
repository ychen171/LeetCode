public class Solution
{
    // HashSet
    // Time: O(n)
    // Space: O(n)
    public IList<int> FindDisappearedNumbers(int[] nums)
    {
        int n = nums.Length;
        var set = new HashSet<int>();
        foreach (var num in nums)
            set.Add(num);
        var result = new List<int>();
        for (int i = 1; i <= n; i++)
        {
            if (set.Contains(i)) continue;
            result.Add(i);
        }

        return result;
    }

    // Negative values | in place modification
    // use sign as bool
    // Time: O(n)
    // Space: O(1) 
    public IList<int> FindDisappearedNumbers1(int[] nums)
    {
        int n = nums.Length;
        // iterate nums and negate value in index (num - 1) as seen
        for (int i = 0; i < n; i++)
        {
            var index = Math.Abs(nums[i]) - 1;
            if (nums[index] > 0)
                nums[index] = -nums[index];
        }
        // iterate nums again, if value is positive, index + 1 is the unseen value
        var result = new List<int>();
        for (int i = 0; i < n; i++)
        {
            if (nums[i] > 0)
                result.Add(i + 1);
        }

        return result;
    }
}
