public class Solution
{
    // DP | Tabulation
    // Time: O(n^2)
    // Space: O(n)
    public int NumFactoredBinaryTrees(int[] arr)
    {
        /*
            states: dp[i], i: index of arr, [0, n-1]
            options: take two children nodes or skip
            goal: dp.Sum()

            dp[i] = 2 * dp[l] * dp[r], l: [0, i-1], r: [0, i-1]

            base case:
            dp[i] = 1
        */
        int MOD = 1000000007;
        Array.Sort(arr);
        int n = arr.Length;
        var dp = new long[n];
        var indexDict = new Dictionary<int, int>();
        for (int i = 0; i < n; i++)
        {
            dp[i] = 1;
            indexDict[arr[i]] = i;
        }

        for (int i = 0; i < n; i++)
        {
            for (int r = 0; r < i; r++)
            {
                if (arr[i] % arr[r] == 0)
                {
                    int left = arr[i] / arr[r];
                    if (indexDict.ContainsKey(left))
                    {
                        dp[i] = (dp[i] + dp[indexDict[left]] * dp[r]) % MOD;
                    }
                }
            }
        }

        return (int)(dp.Sum() % MOD);
    }
}
