public class Solution
{
    // DP | Tabulation
    // Time: O(n)
    // Space: O(n)
    public int NumDecodings(string s)
    {
        /*
            226

            2   26
            22  6
            2   2   6

            states: dp[i], number of decodings ending at i
            goal: dp[n-1]
            options: 1. append prev 2. start new

            dp[i] = dp[i-1] + dp[i-2]
             
        */
        if (s[0] == '0')
            return 0;

        int n = s.Length;
        var dp = new int[n + 1];
        dp[0] = 1;
        dp[1] = s[0] == '0' ? 0 : 1;

        for (int i = 2; i < n + 1; i++)
        {
            char c = s[i - 1];
            char d = s[i - 2];
            // check if successful single digit decode is possible / start new
            if (c != '0')
                dp[i] += dp[i - 1];

            // check if successful double digit decode is possible
            if (d == '1' || (d == '2' && c <= '6'))
                dp[i] += dp[i - 2];
        }

        return dp[n];
    }

    // DP | Memoization Recursion
    // Time: O(n)
    // Space: O(n)
    Dictionary<int, int> memo;
    public int NumDecodings1(string s)
    {
        memo = new Dictionary<int, int>();
        return Helper(s, 0);
    }

    public int Helper(string s, int start)
    {
        if (memo.ContainsKey(start))
            return memo[start];
        int n = s.Length;
        // base case
        if (start == n)
            return 1;
        if (s[start] == '0')
            return 0;
        if (start == n - 1)
            return 1;

        // recursive case
        int result = Helper(s, start + 1);
        var twoDigit = int.Parse(s.Substring(start, 2));
        if (twoDigit >= 10 && twoDigit <= 26)
            result += Helper(s, start + 2);

        memo[start] = result;
        return result;
    }
}

// var sln = new Solution();
// var s = "2101";
// var result = sln.NumDecodings(s);
// Console.WriteLine(result);
