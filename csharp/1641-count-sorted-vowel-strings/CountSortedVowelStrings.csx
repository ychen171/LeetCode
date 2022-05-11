public class Solution
{
    // Backtracking | DFS
    // Time: O(5^n)
    // Space: O(n)
    public int CountVowelStrings(int n)
    {
        var vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };
        var combo = new StringBuilder();
        var result = new List<string>();
        Backtrack(n, vowels, combo, 0, result);
        return result.Count;
    }

    private void Backtrack(int n, char[] vowels, StringBuilder combo, int start, List<string> result)
    {
        // base case
        if (combo.Length == n)
        {
            result.Add(combo.ToString());
            return;
        }
        if (start >= vowels.Length || combo.Length > n)
        {
            return;
        }
        // recursive case
        for (int i = start; i < vowels.Length; i++)
        {
            combo.Append(vowels[i]);
            Backtrack(n, vowels, combo, i, result);
            combo.Remove(combo.Length - 1, 1);
        }
    }

    // Optimized Backtracking | DP | Top-down Memoization Recursion
    // Time: O(n)
    // Space: O(n)
    public int CountVowelStrings1(int n)
    {
        int[][] memo = new int[n + 1][];
        for (int i = 0; i < n + 1; i++)
        {
            memo[i] = new int[5];
        }
        return DFS(n, 0, memo);
    }

    private int DFS(int n, int start, int[][] memo)
    {
        if (memo[n][start] != 0)
            return memo[n][start];
        if (n == 0)
            return 1;
        int result = 0;
        for (int i = start; i < 5; i++)
        {
            result += DFS(n - 1, i, memo);
        }

        memo[n][start] = result;
        return result;
    }

    // DP | Bottom-up Tabulation Iteration
    // dp[n][vowel] = dp[n - 1][vowel] + dp[n][vowel - 1]
    // Time: O(n)
    // Space: O(n)
    public int CountVowelStrings2(int n)
    {
        // initialize the table with default values
        int[][] table = new int[n + 1][];
        for (int level = 0; level < n + 1; level++)
        {
            table[level] = new int[6];
            table[level][0] = 1;
        }
        // seed the trivial answer into the table
        for (int vowel = 1; vowel < 6; vowel++)
            table[0][vowel] = 1;
        // fill further positions based on current position
        for (int level = 1; level < n + 1; level++)
        {
            for (int vowel = 1; vowel < 5; vowel++)
            {
                table[level][vowel] = table[level - 1][vowel] + table[level][vowel - 1];
            }
        }

        return table[n].Max();
    }
}
