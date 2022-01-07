
public class Solution
{
    // Recursive 
    // Time: O(2^n)
    // Space: O(n)
    public int Fib(int n)
    {
        if (n < 2) return n;
        return Fib(n - 1) + Fib(n - 2);
    }

    // Recursive | Memoization
    // Time: O(n)
    // Space: O(n)
    public int Fib2(int n)
    {
        var memo = new Dictionary<int, int>();
        return FibMemo(n, memo);
    }
    private int FibMemo(int n, Dictionary<int, int> memo)
    {
        if (memo.ContainsKey(n)) return memo[n];
        if (n < 2)
        {
            memo[n] = n;
            return n;
        }
        var result = FibMemo(n - 1, memo) + FibMemo(n - 2, memo);
        memo[n] = result;
        return result;
    }

    // Bottom-up 
    // Time: O(n)
    // Space: O(n)
    public int Fib3(int n)
    {
        var list = new List<int>();
        list.Add(0);
        list.Add(1);
        for (int i = 2; i <= n; i++)
        {
            list.Add(list[i-1] + list[i-2]);
        }
        return list[n];
    }
}





