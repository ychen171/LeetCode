public class Solution
{
    // Two pointers | TwoSum sorted | Three pointers?
    // Time: O(n^2)
    // Space: O()
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        IList<IList<int>> result = new List<IList<int>>();
        List<int> sorted = nums.ToList();
        sorted.Sort();
        for (int i = 0; i < sorted.Count; i++)
        {
            if (sorted[i] > 0) break;
            if (i != 0 && sorted[i - 1] == sorted[i]) continue;
            TwoSum(sorted, i, result);
        }

        return result;
    }

    public void TwoSum(IList<int> nums, int i, IList<IList<int>> result)
    {
        var lo = i + 1;
        var hi = nums.Count - 1;
        while (lo < hi)
        {
            var sum = nums[i] + nums[lo] + nums[hi];
            if (sum < 0) lo++;
            else if (sum > 0) hi--;
            else
            {
                result.Add(new List<int>() { nums[i], nums[lo], nums[hi] });
                lo++;
                hi--;
                while (lo < hi && nums[lo] == nums[lo - 1])
                    lo++;
            }
        }
    }
}

var s = new Solution();
Console.WriteLine(s.ThreeSum(new int[] { -1, 0, 1, 2, -1, -4 }));


