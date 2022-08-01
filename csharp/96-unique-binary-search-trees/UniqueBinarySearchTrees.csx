public class Solution
{
    // DP | Memoization | Recursion
    // Time: O(n^2)
    // Space: O(n^2)
    int[][] memo;
    public int NumTrees(int n)
    {
        memo = new int[n + 1][];
        for (int i = 0; i < n + 1; i++)
            memo[i] = new int[n + 1];
        return Helper(n, 1, n);
    }

    public int Helper(int n, int lo, int hi)
    {
        // base case
        if (lo >= hi)
            return 1;

        if (memo[lo][hi] != 0)
            return memo[lo][hi];

        // recursive case
        int ans = 0;
        for (int i = lo; i <= hi; i++)
        {
            int left = Helper(n, lo, i - 1);
            int right = Helper(n, i + 1, hi);
            ans += left * right;
        }

        memo[lo][hi] = ans;
        return ans;
    }
}
