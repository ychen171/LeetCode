public class Solution
{
    // Backtracking
    // Time: O(n!/((n-4)! * 4!))
    // Space: O(4)
    public IList<IList<int>> FourSum(int[] nums, int target)
    {
        var combo = new List<int>();
        var result = new List<IList<int>>();
        Array.Sort(nums);
        Backtrack(nums, target, combo, 0, result);
        return result;
    }

    private void Backtrack(int[] nums, long target, List<int> combo, int nextStart, IList<IList<int>> result)
    {
        // base case
        if (combo.Count == 4)
        {
            if (target == 0)
            {
                result.Add(new List<int>(combo));
            }
            return;
        }
        // recursive case
        for (int i = nextStart; i < nums.Length; i++)
        {
            if (i > nextStart && nums[i] == nums[i - 1])
                continue;
            combo.Add(nums[i]);
            Backtrack(nums, target - nums[i], combo, i + 1, result);
            combo.RemoveAt(combo.Count - 1);
        }
    }

    // Two Pointers + Sorting + Recursion
    // Time: O(n log n) + O(n^(k-1)) or O(n^3)
    // Space: O(n) + O(k) or O(3)
    public IList<IList<int>> FourSum1(int[] nums, int target)
    {
        // sort before the recursion
        Array.Sort(nums);

        return KSum(nums, 4, 0, target);
    }

    public IList<IList<int>> KSum(int[] nums, int k, int start, long target)
    {
        int n = nums.Length;
        var result = new List<IList<int>>();
        // edge case
        if (n < k || k < 2)
            return result;

        // base case
        if (k == 2)
        {
            int lo = start;
            int hi = n - 1;
            while (lo < hi)
            {
                int left = nums[lo];
                int right = nums[hi];
                long sum = left + right;
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
                else // sum == target
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
        for (int i = start; i < n; i++)
        {
            if (i != start && nums[i - 1] == nums[i])
                continue;
            var subResult = KSum(nums, k - 1, i + 1, target - nums[i]);
            foreach (var combo in subResult)
            {
                combo.Add(nums[i]);
                result.Add(combo);
            }
        }

        return result;
    }
}

var sln = new Solution();
/*
[1000000000,1000000000,1000000000,1000000000]
-294,967,296

[1,0,-1,0,-2,2]
0
*/
var nums = new int[] { 1000000000, 1000000000, 1000000000, 1000000000 };
var target = -294967296;
var result = sln.FourSum1(nums, target);
Console.WriteLine(result);
