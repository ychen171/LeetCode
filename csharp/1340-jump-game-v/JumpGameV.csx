public class Solution
{
    // DP | Top-down | Memoization | Recursion
    // Time: O(n^2)
    // Space: O(n)
    public int MaxJumps1(int[] arr, int d)
    {
        int n = arr.Length;
        var maxJumps = int.MinValue;
        var memo = new int[n];
        Array.Fill(memo, int.MinValue);
        for (int i = 0; i < n; i++)
            maxJumps = Math.Max(maxJumps, Helper(arr, d, i, memo));

        return maxJumps;
    }

    public int Helper(int[] arr, int d, int i, int[] memo)
    {
        if (memo[i] != int.MinValue)
            return memo[i];

        int n = arr.Length;
        int startJ = Math.Max(0, i - d);
        int endJ = Math.Min(n - 1, i + d);

        int ans = 1;
        for (int j = startJ; j <= endJ; j++)
        {
            if (j == i)
                continue;
            if (arr[j] >= arr[i])
                continue;

            int startK = Math.Min(i, j) + 1;
            int endK = Math.Max(i, j) - 1;
            bool validJ = true;
            for (int k = startK; k <= endK; k++)
            {
                if (arr[k] >= arr[i])
                {
                    validJ = false;
                    break;
                }
            }
            if (!validJ)
                continue;

            ans = Math.Max(ans, 1 + Helper(arr, d, j, memo));
        }

        memo[i] = ans;
        return ans;
    }

    // DP | Top-down | Memoization | Recursion
    // Time: O(n*d)
    // Space: O(n)
    public int MaxJumpsOptimized(int[] arr, int d)
    {
        int n = arr.Length;
        var maxJumps = int.MinValue;
        var memo = new int[n];
        Array.Fill(memo, int.MinValue);
        for (int i = 0; i < n; i++)
            maxJumps = Math.Max(maxJumps, HelperOptimized(arr, d, i, memo));

        return maxJumps;
    }
    public int HelperOptimized(int[] arr, int d, int i, int[] memo)
    {
        if (memo[i] != int.MinValue)
            return memo[i];

        int n = arr.Length;
        int startJ = Math.Max(0, i - d);
        int endJ = Math.Min(n - 1, i + d);

        int ans = 1;
        // search left side: from i - 1 to startJ
        for (int j = i - 1; j >= startJ; j--)
        {
            if (arr[j] >= arr[i]) // j is blocking the further indexes
                break;

            ans = Math.Max(ans, 1 + HelperOptimized(arr, d, j, memo));
        }
        // search right side: from i + 1 to endJ
        for (int j = i + 1; j <= endJ; j++)
        {
            if (arr[j] >= arr[i]) // j is blocking the further indexes
                break;

            ans = Math.Max(ans, 1 + HelperOptimized(arr, d, j, memo));
        }

        memo[i] = ans;
        return ans;
    }
}

var s = new Solution();
int result;

result = s.MaxJumps1(new int[] { 6, 4, 14, 6, 8, 13, 9, 7, 10, 6, 12 }, 2);
Console.WriteLine(result);

result = s.MaxJumps1(new int[] { 3, 3, 3, 3, 3 }, 3);
Console.WriteLine(result);

result = s.MaxJumps1(new int[] { 7, 6, 5, 4, 3, 2, 1 }, 1);
Console.WriteLine(result);
