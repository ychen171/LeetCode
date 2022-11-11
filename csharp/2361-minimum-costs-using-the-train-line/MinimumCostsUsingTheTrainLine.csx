public class Solution
{
    public long[] MinimumCosts(int[] regular, int[] express, int expressCost)
    {
        /*
            dp[i][s]: min cost so far at i, s: 0 regular, 1 express
            goal: min dp[n][0,1]
            option: regular to regular, regular to express, express to express, express to regular
            
            dp[i][0] = Math.min(dp[i-1][0] + regular[i-1], dp[i-1][1] + regular[i-1])
            dp[i][1] = Math.min(dp[i-1][1] + express[i-1], dp[i-1][0] + expressCost + express[i-1])
        */
        int n = regular.Length;
        var dp = new long[n + 1, 2];
        var result = new long[n];
        dp[0, 0] = 0;
        dp[0, 1] = expressCost;
        for (int i = 1; i <= n; i++)
        {
            dp[i, 0] = Math.Min(dp[i - 1, 0] + regular[i - 1], dp[i - 1, 1] + regular[i - 1]);
            dp[i, 1] = Math.Min(dp[i - 1, 1] + express[i - 1], dp[i - 1, 0] + expressCost + express[i - 1]);
            result[i - 1] = Math.Min(dp[i, 0], dp[i, 1]);
        }
        return result;
    }
}
// DP
// Time: O(n)
// Space: O(n)
