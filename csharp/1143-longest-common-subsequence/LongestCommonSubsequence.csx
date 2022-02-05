public class Solution
{
    // DP | Top-down | Memoization | Recursion
    // Time: O(m * n)
    // Space: O(m * n)
    private string text1, text2;
    private int[,] memo;
    public int LongestCommonSubsequence(string text1, string text2)
    {
        this.text1 = text1;
        this.text2 = text2;
        var i = text1.Length - 1;
        var j = text2.Length - 1;
        memo = new int[text1.Length, text2.Length];
        return Helper(i, j);
    }

    public int Helper(int i, int j)
    {
        if (i < 0 || j < 0) return 0;
        if (memo[i, j] != 0) return memo[i, j];
        int result = 0;
        if (text1[i] == text2[j])
            result = 1 + Helper(i - 1, j - 1);
        else
            result = Math.Max(Helper(i - 1, j), Helper(i, j - 1));
        if (memo[i, j] == 0)
            memo[i, j] = result;
        return result;
    }

    // DP | Bottom-up | Tabulation | Iteration
    // Time: O(m * n)
    // Space: O(m * n)
    public int LongestCommonSubsequenceTabulation(string text1, string text2)
    {
        // initialize table with default values
        int[,] table = new int[text1.Length + 1, text2.Length + 1];
        // seed the trivial answer into the table
        // fill further positions with current position
        for (int i = 0; i < text1.Length; i++)
        {
            for (int j = 0; j < text2.Length; j++)
            {
                if (text1[i] == text2[j])
                    table[i + 1, j + 1] += 1;
                table[i + 1, j + 1] += Math.Max(table[i, j + 1], table[i + 1, j]);
            }
        }

        return table[text1.Length, text2.Length];
    }
}


var s = new Solution();
Console.WriteLine(s.LongestCommonSubsequence("abcde", "ace"));
Console.WriteLine(s.LongestCommonSubsequenceTabulation("abcde", "ace"));



