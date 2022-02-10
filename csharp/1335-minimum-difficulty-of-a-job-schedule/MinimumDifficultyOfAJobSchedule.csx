public class Solution
{
    // Easier to understand
    // DP | Top-down | Memoization | Recursion
    // Time: O(d * (n-d)^2)
    // Space: O((n-d) * d)
    private int n, d;
    private int[] jobDifficulty;
    private int[] hardestJobRemaining;
    private List<List<int>> memo;
    public int MinDifficulty(int[] jobDifficulty, int d)
    {
        this.n = jobDifficulty.Length;
        this.d = d;
        if (n < d) return -1;
        this.jobDifficulty = jobDifficulty;
        this.hardestJobRemaining = new int[n];
        int hardest = 0;
        for (int i = n - 1; i >= 0; i--)
        {
            hardest = Math.Max(hardest, jobDifficulty[i]);
            hardestJobRemaining[i] = hardest;
        }

        memo = new List<List<int>>();
        for (int i = 0; i < n; i++)
        {
            memo.Add(new List<int>());
            for (int j = 0; j <= d; j++)
                memo[i].Add(-1);
        }
        return Helper(0, 1);
    }
    public int Helper(int i, int day)
    {
        if (memo[i][day] != -1) return memo[i][day];
        // Base case
        if (day == d) return hardestJobRemaining[i];

        int result = int.MaxValue;
        int hardest = 0;
        // Iterate through the options and choose the best
        for (int j = i; j < n - (d - day); j++)
        {
            hardest = Math.Max(hardest, jobDifficulty[j]);
            // Recurrence relation
            result = Math.Min(result, hardest + Helper(j + 1, day + 1));
        }

        memo[i][day] = result;
        return result;
    }

    // DP | Bottom-up | Tabulation | Iteration
    // Time: O(d * (n-d)^2)
    // Space: O(n * d)
    public int MinDifficultyTabulation(int[] jobDifficulty, int d)
    {
        int n = jobDifficulty.Length;
        if (n < d) return -1;

        // initialize table with default value
        var table = new List<List<int>>();
        for (int i = 0; i < n; i++)
        {
            table.Add(new List<int>());
            for (int j = 0; j <= d; j++)
                table[i].Add(int.MaxValue);
        }

        // seed the trivial answer into the table
        table[n - 1][d] = jobDifficulty[n - 1];
        for (int i = n - 2; i >= 0; i--)
            table[i][d] = Math.Max(table[i + 1][d], jobDifficulty[i]);

        // fill further positions with current position
        for (int day = d - 1; day > 0; day--)
        {
            for (int i = day - 1; i < n - (d - day); i++)
            {
                int hardest = 0;
                for (int j = i; j < n - (d - day); j++)
                {
                    hardest = Math.Max(hardest, jobDifficulty[j]);
                    table[i][day] = Math.Min(table[i][day], hardest + table[j + 1][day + 1]);
                }
            }
        }

        return table[0][1];
    }
}


var s = new Solution();
Console.WriteLine(s.MinDifficulty(new int[] { 6, 5, 4, 3, 2, 1 }, 2));
Console.WriteLine(s.MinDifficulty(new int[] { 9, 9, 9 }, 4));
Console.WriteLine(s.MinDifficulty(new int[] { 1, 1, 1 }, 3));





