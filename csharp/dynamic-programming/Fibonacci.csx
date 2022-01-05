
// Recursion
// Time: O(2^n)
// Space: O(n)
public long Fib(int n)
{
    if (n <= 2) return 1;
    return Fib(n - 1) + Fib(n - 2);
}

// Memoization | DP | Recursion
public long FibMemo(int n, Dictionary<int, long> memo)
{
    if (memo.ContainsKey(n)) return memo[n];
    long result;
    if (n <= 2) result = 1;
    else result = FibMemo(n - 1, memo) + FibMemo(n - 2, memo);
    memo[n] = result;
    return result;
}

public long FibBottomUp(int n)
{
    var dict = new Dictionary<int, long>();
    dict[1] = 1;
    dict[2] = 1;
    for (int i = 3; i <= n; i++)
        dict[i] = dict[i - 1] + dict[i - 2];
    return dict[n];
}






Console.WriteLine(Fib(6));
Console.WriteLine(Fib(7));
Console.WriteLine(Fib(8));

Console.WriteLine(FibMemo(6, new Dictionary<int, long>()));
Console.WriteLine(FibMemo(7, new Dictionary<int, long>()));
Console.WriteLine(FibMemo(8, new Dictionary<int, long>()));
Console.WriteLine(FibMemo(50, new Dictionary<int, long>()));

Console.WriteLine(FibBottomUp(6));
Console.WriteLine(FibBottomUp(7));
Console.WriteLine(FibBottomUp(8));
Console.WriteLine(FibBottomUp(50));

