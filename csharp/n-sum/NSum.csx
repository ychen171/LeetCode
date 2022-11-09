public class Solution
{
    public IList<IList<int>> NSum(int[] nums, int k, int start, int target)
    {
        // nums is sorted
        int n = nums.Length;
        var result = new List<IList<int>>();
        // base case
        if (k < 2 || n < k)
            return result;
        if (k == 2) // 2Sum
        {
            int lo = start, hi = n - 1;
            while (lo < hi)
            {
                var left = nums[lo];
                var right = nums[hi];
                var sum = left + right;
                if (sum < target)
                {
                    while (lo < hi && nums[lo] == left)
                        lo++;
                }
                else if (sum > target)
                {
                    while (lo < hi && nums[hi] == right)
                        hi--;
                }
                else // ==
                {
                    result.Add(new List<int> { left, right });
                    while (lo < hi && nums[lo] == left)
                        lo++;
                    while (lo < hi && nums[hi] == right)
                        hi--;
                }
            }
            return result;
        }
        // recursive case
        for (int i = 0; i < n; i++)
        {
            var subResult = NSum(nums, k - 1, i + 1, target - nums[i]);
            foreach (var list in subResult)
            {
                list.Add(nums[i]);
                result.Add(list);
            }
            while (i < n - 1 && nums[i] == nums[i + 1]) // reach the last duplicate num so that the next iteration will have a new number
                i++;
        }
        return result;
    }
}
