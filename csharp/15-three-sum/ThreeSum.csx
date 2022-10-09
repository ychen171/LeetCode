public class Solution
{
    // Two pointers | TwoSum sorted | Three pointers?
    // Time: O(n^2)
    // Space: O(n)
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        IList<IList<int>> result = new List<IList<int>>();
        List<int> sorted = nums.ToList();
        sorted.Sort();
        for (int i = 0; i < sorted.Count; i++)
        {
            if (sorted[i] > 0) break;
            if (i != 0 && sorted[i - 1] == sorted[i]) continue;

            var lo = i + 1;
            var hi = sorted.Count - 1;
            while (lo < hi)
            {
                var sum = sorted[i] + sorted[lo] + sorted[hi];
                if (sum < 0) lo++;
                else if (sum > 0) hi--;
                else
                {
                    result.Add(new List<int>() { sorted[i], sorted[lo], sorted[hi] });
                    lo++;
                    hi--;
                    while (lo < hi && sorted[lo] == sorted[lo - 1])
                        lo++;
                }
            }
        }

        return result;
    }

    // No-sort | HashMap/Dictionary and HashSet
    // Time : O(n^2)
    // Space: O(n)
    public IList<IList<int>> ThreeSum1(int[] nums)
    {
        var resultSet = new HashSet<List<int>>();
        var dups = new HashSet<int>();
        var seen = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (dups.Add(nums[i]))
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    var complement = -nums[i] - nums[j];
                    if (seen.ContainsKey(complement) && seen[complement] == i)
                    {
                        var triplet = new List<int> { nums[i], nums[j], complement };
                        triplet.Sort();
                        resultSet.Add(triplet);
                    }
                    seen[nums[j]] = i;
                }
            }
        }
        IList<IList<int>> result = new List<IList<int>>();
        foreach (var list in resultSet)
            result.Add(list);

        return result;
    }

    // Sort + Two Pointers + Recursion
    // Time: O(n^2)
    // Space: O(n)
    public IList<IList<int>> ThreeSum2(int[] nums)
    {
        // sort first
        Array.Sort(nums);
        return NSum(nums, 3, 0, 0);
    }

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

var s = new Solution();
// Console.WriteLine(s.ThreeSum(new int[] { -1, 0, 1, 2, -1, -4 }));
Console.WriteLine(s.ThreeSum1(new int[] { -1, 0, 1, 2, -1, -4 }));


