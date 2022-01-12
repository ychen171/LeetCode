using System.Collections.Generic;
public class Solution
{
    // essentially a fibonacci number
    // Recursion
    // Time: O(2^n)
    // Space: O(n)
    public int ClimbStairs(int n)
    {
        if (n < 2) return 1;
        return ClimbStairs(n - 1) + ClimbStairs(n - 2);
    }

    // memoization
    // Time: O(n)
    // Space: O(n)
    public int ClimbStairs2(int n)
    {
        return ClimbStairsMemo(n, new Dictionary<int, int>());
    }
    public int ClimbStairsMemo(int n, Dictionary<int, int> memo)
    {
        if (memo.ContainsKey(n)) return memo[n];
        if (n < 2)
        {
            memo[n] = 1;
            return 1;
        }
        var result = ClimbStairsMemo(n - 1, memo) + ClimbStairsMemo(n - 2, memo);
        memo[n] = result;
        return result;
    }

    // bottom-up
    // Time: O(n)
    // Space: O(n)
    public int ClimbStairs3(int n)
    {
        var list = new List<int>();
        list.Add(1);
        list.Add(1);
        for (int i = 2; i <= n; i++)
        {
            list.Add(list[i - 1] + list[i - 2]);
        }
        return list[n];
    }
}






