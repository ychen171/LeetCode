public class Solution
{
    // DP | Memoization Recursion
    // Time: O(n * t *k)
    // Space: O(n * t)
    // t: max target
    int MOD = 1000000007;
    int n;
    int k;
    int target;
    Dictionary<string, int> memo;
    public int NumRollsToTarget(int n, int k, int target)
    {
        this.n = n;
        this.k = k;
        this.target = target;
        this.memo = new Dictionary<string, int>();
        return Helper(0, 0);
    }

    public int Helper(int sum, int start)
    {
        // base case
        var key = $"{sum},{start}";
        if (memo.ContainsKey(key))
            return memo[key];

        if (start == n)
            return sum == target ? 1 : 0;
        if (sum > target)
            return 0;

        // recursive case
        int result = 0;
        for (int num = 1; num <= k; num++)
        {
            sum += num;
            result = (result + Helper(sum, start + 1)) % MOD;
            sum -= num;
        }
        memo[key] = result;
        return result;
    }
}
