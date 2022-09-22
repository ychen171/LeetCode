public class Solution
{
    // DP | Memoization Recursion
    // Time: O(n * m)
    // Space: O(n * m)
    Dictionary<string, double> memo;
    public string MinimizeError(string[] prices, int target)
    {
        int n = prices.Length;
        var nums = new double[n];
        for (int i = 0; i < n; i++)
            nums[i] = double.Parse(prices[i]);
        memo = new Dictionary<string, double>();
        var sum = Helper(nums, target, 0);
        if (sum == -1) return "-1";
        return sum.ToString("0.000");
    }

    public double Helper(double[] nums, int target, int index)
    {
        // base case
        if (target < 0.0)
            return -1;
        if (index == nums.Length)
        {
            if (target == 0.0)
                return 0;
            else
                return -1;
        }

        string key = $"{target},{index}";
        if (memo.ContainsKey(key))
            return memo[key];

        // recursive case
        double result = int.MaxValue;
        // floor
        int lo = (int)Math.Floor(nums[index]);
        double roundDown = Math.Abs(lo - nums[index]);
        double sub1 = Helper(nums, target - lo, index + 1);
        if (sub1 != -1)
        {
            result = Math.Min(result, sub1 + roundDown);
        }

        // ceiling
        int hi = (int)Math.Ceiling(nums[index]);
        double roundUp = Math.Abs(hi - nums[index]);
        double sub2 = Helper(nums, target - hi, index + 1);
        if (sub2 != -1)
        {
            result = Math.Min(result, sub2 + roundUp);
        }

        if (result == int.MaxValue)
            result = -1;

        memo[key] = result;
        return result;
    }
}
