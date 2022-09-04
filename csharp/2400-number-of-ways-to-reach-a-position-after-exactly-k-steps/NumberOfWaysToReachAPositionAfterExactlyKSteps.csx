public class Solution
{
    int MOD = 1000000007;
    Dictionary<string, int> memo;
    // DP | Memoization | Recursion
    // Time: O(1000^3)
    // Space: O(1000^3)
    public int NumberOfWays(int startPos, int endPos, int k)
    {
        /*
            order matters
            input has no dups, output can have dups
            num can be reused
            unique result
        */
        memo = new Dictionary<string, int>();
        return DFS(startPos, endPos, k);
    }

    public int DFS(int start, int end, int k)
    {
        var key = $"{start},{end},{k}";
        if (memo.ContainsKey(key))
            return memo[key];

        // base case
        if (Math.Abs(end - start) > k)
            return 0;
        if (k == 0)
        {
            if (start == end)
                return 1;
            else
                return 0;
        }

        // recursive case
        int sub1 = DFS(start + 1, end, k - 1);
        int sub2 = DFS(start - 1, end, k - 1);
        int result = (sub1 + sub2) % MOD;
        memo[key] = result;
        return result;
    }
}

var sln = new Solution();
var result = sln.NumberOfWays(1, 2, 3);
Console.WriteLine(result);
