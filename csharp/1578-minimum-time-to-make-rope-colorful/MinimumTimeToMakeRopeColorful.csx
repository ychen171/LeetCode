public class Solution
{
    // DP | Tabulation
    // Time: O(n)
    // Space: O(n)
    public int MinCost(string colors, int[] neededTime)
    {
        /*
            states: dp[i][s], i: index, [0, n-1], s: 0: index of previous ballon, 1: min time so far
            dp[i][1]: the min time in the end
            options: 1. keep, or 2. remove
            goal: dp[n-1][1]
            
            var preIndex = dp[i-1][0];
            if (colors[preIndex] == colors[i]) // need to remove one
            {
                if (neededTime[preIndex] < neededTime[i])
                {
                    dp[i][0] = i;
                    dp[i][1] = dp[i-1][1] + neededTime[preIndex];
                }
                else
                {
                    dp[i][0] = preIndex;
                    dp[i][1] = dp[i-1][1] + neededTime[i];
                }
            }
            else
            {
                dp[i][0] = i;
                dp[i][1] = dp[i-1][1];
            }
            
            base case:
            dp[0][0] = 0;
            dp[0][1] = 0;
        */

        int n = colors.Length;
        var dp = new int[n][];
        for (int i = 0; i < n; i++)
            dp[i] = new int[2];

        for (int i = 1; i < n; i++)
        {
            var preIndex = dp[i - 1][0];
            if (colors[preIndex] == colors[i]) // need to remove one
            {
                if (neededTime[preIndex] < neededTime[i])
                {
                    dp[i][0] = i;
                    dp[i][1] = dp[i - 1][1] + neededTime[preIndex];
                }
                else
                {
                    dp[i][0] = preIndex;
                    dp[i][1] = dp[i - 1][1] + neededTime[i];
                }
            }
            else
            {
                dp[i][0] = i;
                dp[i][1] = dp[i - 1][1];
            }
        }
        return dp[n - 1][1];
    }

    // Greedy 
    // Time: O(n)
    // Space: O(1)
    public int MinCost1(string colors, int[] neededTime)
    {
        /*
            for a group of continuous same characters, 
            delete all except one character with most time
        */
        int n = colors.Length;
        int sum = 0, max = 0;
        int result = 0;
        for (int i = 0; i < n; i++)
        {
            if (i != 0 && colors[i - 1] != colors[i]) // start new group
            {
                result += (sum - max);
                sum = 0;
                max = 0;
            }
            sum += neededTime[i];
            max = Math.Max(max, neededTime[i]);
        }
        // check the last group
        if (sum != 0)
            result += (sum - max);

        return result;
    }
}
