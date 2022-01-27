

public class Solution
{
    // DP | Memoization | Recursion
    // Time: O(n^2)
    // Space: O(n)
    public int DeleteAndEarn(int[] nums)
    {
        return Helper(nums.ToList(), new Dictionary<string, int>());
    }
    public int Helper(List<int> nums, Dictionary<string, int> memo)
    {
        var sb = new StringBuilder();
        foreach (var num in nums)
            sb.Append(num);
        var key = sb.ToString();
        if (memo.ContainsKey(key)) return memo[key];

        if (nums.Count == 0) return 0;

        int result = 0;

        for (int i = 0; i < nums.Count; i++)
        {
            bool toSkip = true;
            var remainder = new List<int>();
            foreach (var num in nums)
            {
                if (num == nums[i] - 1 || num == nums[i] + 1)
                    continue;
                if (num == nums[i] && toSkip)
                {
                    toSkip = false;
                    continue;
                }
                remainder.Add(num);
            }
            result = Math.Max(result, nums[i] + Helper(remainder, memo));
        }

        memo[key] = result;
        return result;
    }

    // DP | Tabulation | Iteration
    // Time: O(nums.Max())
    // Space: O(nums.Max())
    public int DeleteAndEarnTabulation(int[] nums)
    {
        var table = new List<int>();
        // initialize the table with default value
        for (int i = 0; i <= nums.Max(); i++)
            table.Add(0);
        // seed the trivial answer into the table
        foreach (var num in nums)
            table[num] += num;
        // fill further positions with current position
        for (int i = 2; i < table.Count; i++)
            table[i] = Math.Max(table[i - 2] + table[i], table[i - 1]);

        return table[table.Count - 1];
    }
}

var s = new Solution();
// Console.WriteLine(s.DeleteAndEarn(new int[] { 3, 4, 2 })); // 6
// Console.WriteLine(s.DeleteAndEarn(new int[] { 2, 2, 3, 3, 3, 4 })); // 9
// Console.WriteLine(s.DeleteAndEarn(new int[] { 10, 8, 4, 2, 1, 3, 4, 8, 2, 9, 10, 4, 8, 5, 9, 1, 5, 1, 6, 8, 1, 1, 6, 7, 8, 9, 1, 7, 6, 8, 4, 5, 4, 1, 5, 9, 8, 6, 10, 6, 4, 3, 8, 4, 10, 8, 8, 10, 6, 4, 4, 4, 9, 6, 9, 10, 7, 1, 5, 3, 4, 4, 8, 1, 1, 2, 1, 4, 1, 1, 4, 9, 4, 7, 1, 5, 1, 10, 3, 5, 10, 3, 10, 2, 1, 10, 4, 1, 1, 4, 1, 2, 10, 9, 7, 10, 1, 2, 7, 5 }))

Console.WriteLine(s.DeleteAndEarnTabulation(new int[] { 3, 4, 2 })); // 6
Console.WriteLine(s.DeleteAndEarnTabulation(new int[] { 2, 2, 3, 3, 3, 4 })); // 9
Console.WriteLine(s.DeleteAndEarnTabulation(new int[] { 10, 8, 4, 2, 1, 3, 4, 8, 2, 9, 10, 4, 8, 5, 9, 1, 5, 1, 6, 8, 1, 1, 6, 7, 8, 9, 1, 7, 6, 8, 4, 5, 4, 1, 5, 9, 8, 6, 10, 6, 4, 3, 8, 4, 10, 8, 8, 10, 6, 4, 4, 4, 9, 6, 9, 10, 7, 1, 5, 3, 4, 4, 8, 1, 1, 2, 1, 4, 1, 1, 4, 9, 4, 7, 1, 5, 1, 10, 3, 5, 10, 3, 10, 2, 1, 10, 4, 1, 1, 4, 1, 2, 10, 9, 7, 10, 1, 2, 7, 5 }))







