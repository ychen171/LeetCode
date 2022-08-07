public class Solution
{
    // DP
    // Time: O(5n) -> O(n)
    // Space: O(5n) -> O(n)
    public int CountVowelPermutation(int n)
    {
        /*
            states: dp[i][j], i: at index, [0, n-1], j: vowel, [a, e, i, o, u],[0, 4]
            options: take, skip
            goal: dp[n-1].Sum()

            a -> e
            e -> a i
            i -> a e o u
            o -> i u
            u -> a

            dp[i][a] = dp[i-1][e] + dp[i-1][i] + dp[i-1][u]
            dp[i][e] = dp[i-1][a] + dp[i-1][i]
            dp[i][i] = dp[i-1][e] + dp[i-1][o]
            dp[i][o] = dp[i-1][i]
            dp[i][u] = dp[i-1][i] + dp[i-1][o]

            base case:
            dp[-1][.] = 0
            dp[0][.] = 1
        */

        int MOD = 1000000007;

        if (n == 0)
            return 0;

        var dp = new long[n][];
        for (int i = 0; i < n; i++)
            dp[i] = new long[5];

        for (int i = 0; i < n; i++)
        {
            if (i == 0)
            {
                for (int j = 0; j < 5; j++)
                    dp[i][j] = 1;
                continue;
            }
            dp[i][0] = (dp[i - 1][1] + dp[i - 1][2] + dp[i - 1][4]) % MOD;
            dp[i][1] = (dp[i - 1][0] + dp[i - 1][2]) % MOD;
            dp[i][2] = (dp[i - 1][1] + dp[i - 1][3]) % MOD;
            dp[i][3] = dp[i - 1][2] % MOD;
            dp[i][4] = (dp[i - 1][2] + dp[i - 1][3]) % MOD;
        }

        long result = 0;
        for (int j = 0; j < 5; j++)
        {
            result += dp[n - 1][j];
            result %= MOD;
        }
        result %= MOD;
        return (int)result;
    }
}
