public class Solution
{
    // DP | Tabulation
    // Time: O(n)
    // Space: O(n)
    public int MaximumSum(int[] arr)
    {
        /*
            states: dp[i][s], i: index so far, [0, n], s: 0: 0 deletion, 1: 1 deletion
            dp[i][s], the max sum at i
            goal: dp[0..n-1].Max()
            option: delete one from [0, i], not to delete

            dp[i][0] = dp[i-1][0] + arr[i]
            dp[i][1] = Math.Max(dp[i-1][0] + arr[i] - currMin, dp[i-1][1] + arr[i])

            base case:
            dp[0][0] = arr[0]
            dp[0][1] = 0
        */
        var n = arr.Length;
        var dp = new int[n][];
        var currMin = int.MaxValue;
        int result = arr[0];
        for (int i = 0; i < n; i++)
        {
            currMin = Math.Min(currMin, arr[i]);
            dp[i] = new int[2];
            if (i == 0)
            {
                dp[i][0] = arr[i];
                result = dp[i][0];
                continue;
            }
            if (dp[i - 1][0] < 0)
                currMin = arr[i];
            dp[i][0] = Math.Max(arr[i], dp[i - 1][0] + arr[i]);
            dp[i][1] = Math.Max(dp[i - 1][0] + arr[i] - currMin, dp[i - 1][1] + arr[i]);
            result = Math.Max(result, dp[i][0]);
            result = Math.Max(result, dp[i][1]);
        }

        return result;
    }
}

var sln = new Solution();
var arr = new int[] { 1, -2, 0, 3 };
var result = sln.MaximumSum(arr);
Console.WriteLine(result);
