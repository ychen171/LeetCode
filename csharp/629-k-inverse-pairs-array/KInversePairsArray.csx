public class Solution
{
    // Brute force
    // Time: O(n! * n^2)
    // Space: O(n)
    int ans = 0;
    public int KInversePairs(int n, int k)
    {
        // find all permutations with k inverse pairs

        // output order matters
        // input has no duplicates
        // num cannot be reused
        // permutations are unique

        var used = new bool[n + 1];
        var perm = new List<int>();
        Backtrack(n, k, used, perm);
        return ans;
    }

    public void Backtrack(int n, int k, bool[] used, IList<int> perm)
    {
        // base case
        if (perm.Count == n)
        {
            int pairCount = CountInversePairs(perm);
            if (pairCount == k)
            {
                ans++;
            }
            return;
        }

        // recursive case
        for (int num = 1; num <= n; num++)
        {
            if (used[num])
                continue;

            perm.Add(num);
            used[num] = true;
            Backtrack(n, k, used, perm);
            perm.RemoveAt(perm.Count - 1);
            used[num] = false;
        }
    }

    public int CountInversePairs(IList<int> nums)
    {
        int n = nums.Count;
        int count = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                if (nums[i] > nums[j])
                    count++;
            }
        }

        return count;
    }

    // DP | Memoization | Recursion
    // Time: O(n * k * min(n,k))
    // Space: O(n * k)
    public int KInversePairs1(int n, int k)
    {
        var memo = new int[n + 1][];
        for (int i = 0; i < n + 1; i++)
        {
            memo[i] = new int[k + 1];
            for (int j = 0; j < k + 1; j++)
                memo[i][j] = -1;
        }

        return Helper(n, k, memo);
    }

    public int Helper(int n, int k, int[][] memo)
    {
        if (memo[n][k] != -1)
            return memo[n][k];
        if (n == 0)
            return 0;
        if (k == 0)
            return 1;

        int ans = 0;
        for (int i = 0; i <= Math.Min(k, n - 1); i++)
        {
            ans = (ans + Helper(n - 1, k - i, memo)) % 1000000007;
        }

        memo[n][k] = ans;
        return ans;
    }
}
