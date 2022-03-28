public class Solution
{
    // Two pointers + HashSet
    // Time: O(n)
    // Space: O(1)
    public int RemoveDuplicates(int[] nums)
    {
        if (nums.Length <= 1) return nums.Length;
        int l = 0;
        int r = 0;
        var seen = new HashSet<int>();
        while (r < nums.Length)
        {
            if (seen.Add(nums[r]))
            {
                nums[l] = nums[r];
                l++;
            }
            r++;
        }

        return l;
    }

    // Two pointers | nums are sorted
    // Time: O(n)
    // Space: O(1)
    public int RemoveDuplicates1(int[] nums)
    {
        if (nums.Length <= 1) return nums.Length;
        int i = 0;
        for (int j = 1; j < nums.Length; j++)
        {
            if (nums[i] == nums[j]) continue;
            i++;
            nums[i] = nums[j];
        }

        return i + 1;
    }
}
