public class Solution
{
    // Memoization | Recursion | Top-down
    // Time: O(n)
    // Space: O(n)
    public int Tribonacci(int n)
    {
        return Helper(n, new Dictionary<int, int>());
    }
    public int Helper(int n, Dictionary<int, int> memo)
    {
        if (memo.ContainsKey(n)) return memo[n];
        if (n == 0) return 0;
        if (n == 1 || n == 2) return 1;
        var result = Helper(n - 1, memo) + Helper(n - 2, memo) + Helper(n - 3, memo);
        memo[n] = result;
        return result;
    }

    // Tabulation | Iteration | Bottom-up
    // Time: O(n)
    // Space: O(n)
    public int TribonacciTabulation(int n)
    {
        // initialize the table with default value
        var table = new List<int>();
        for (int i = 0; i <= n; i++)
            table.Add(0);
        // seed the trivial answer into the table
        table[1] = 1;
        table[2] = 1;
        // fill further positions with current position
        for (int i = 3; i < n + 1; i++)
            table[i] = table[i - 1] + table[i - 2] + table[i - 3];

        return table[table.Count - 1];
    }
}


var s = new Solution();
Console.WriteLine(s.Tribonacci(4));
Console.WriteLine(s.Tribonacci(25));
Console.WriteLine(s.TribonacciTabulation(4));
Console.WriteLine(s.TribonacciTabulation(25));


