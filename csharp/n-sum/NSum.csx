public class Solution
{
    public IList<IList<int>> NSum(int[] nums, int n, int start, int target)
    {
        // nums is sorted
        int size = nums.Length;
        var result = new List<IList<int>>();
        // base case
        if (n < 2 || size < n)
            return result;
        if (n == 2) // 2Sum
        {
            int lo = start, hi = size - 1;
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
        for (int i = 0; i < size; i++)
        {
            var subResult = NSum(nums, n - 1, i + 1, target - nums[i]);
            foreach (var list in subResult)
            {
                list.Add(nums[i]);
                result.Add(list);
            }
            while (i < size - 1 && nums[i] == nums[i + 1])
                i++;
        }
        return result;
    }
}
