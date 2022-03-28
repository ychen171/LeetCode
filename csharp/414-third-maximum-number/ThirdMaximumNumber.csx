public class Solution
{
    // Sorting + Remove duplicates
    // Time: O(n log n)
    // Space: O(1)
    public int ThirdMax(int[] nums)
    {
        // sorting
        Array.Sort(nums);
        // remove dups
        int i = 0;
        for (int j = 1; j < nums.Length; j++)
        {
            if (nums[i] == nums[j]) continue;
            i++;
            nums[i] = nums[j];
        }

        return i < 2 ? nums[i] : nums[i - 2];
    }

    // HashSet
    // Time: O(n)
    // Space: O(n)
    public int ThirdMax1(int[] nums)
    {
        var set = new HashSet<int>();
        foreach (var num in nums)
        {
            if (set.Add(num))
            {
                while (set.Count > 3)
                    set.Remove(set.Min());
            }
        }

        return set.Count < 3 ? set.Max() : set.Min();
    }
}
