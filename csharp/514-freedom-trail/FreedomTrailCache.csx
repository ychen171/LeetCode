public class Solution
{
    // DP | Memoization Recursion
    // Time: O(m * n)
    // Space: O(m * n)
    int m;
    int n;
    int[][] memo;
    Dictionary<char, List<int>> charToIndex;
    public int FindRotateSteps(string ring, string key)
    {
        /*
            godding godding
        */
        m = ring.Length; // options
        n = key.Length;  // levels
        memo = new int[m][];
        for (int i = 0; i < m; i++)
            memo[i] = new int[n];
        charToIndex = new Dictionary<char, List<int>>();
        for (int i = 0; i < m; i++)
        {
            var c = ring[i];
            if (!charToIndex.ContainsKey(c))
                charToIndex[c] = new List<int>();
            charToIndex[c].Add(i);
        }
        return Helper(ring, 0, key, 0);
    }

    public int Helper(string ring, int i, string key, int j)
    {
        // base case
        if (j == n)
            return 0;

        if (memo[i][j] != 0)
            return memo[i][j];

        // recursive case
        // press or turn and press
        int result = int.MaxValue;
        foreach (var nextI in charToIndex[key[j]])
        {
            var diff = Math.Abs(nextI - i);
            var moves = Math.Min(diff, m - diff);
            result = Math.Min(result, 1 + moves + Helper(ring, nextI, key, j + 1));
        }
        memo[i][j] = result;
        return result;
    }
}

var sln = new Solution();
var ring = "godding";
var key = "gd";
var result = sln.FindRotateSteps(ring, key);
Console.WriteLine(result);
