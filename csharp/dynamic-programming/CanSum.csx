

// Brute force recursion
// m = target
// n = array length
// Time: O(n^m)
// Space: O(m)
public bool CanSum(int target, int[] nums)
{
    if (target == 0) return true;
    if (target < 0) return false;

    foreach (var num in nums)
    {
        var remainder = target - num;
        var result = CanSum(remainder, nums);
        if (result == true)
            return true;
    }
    return false;
}

var stopwatch1 = new Stopwatch();
stopwatch1.Start();
Console.WriteLine(CanSum(7, new int[] { 2, 3 }));
Console.WriteLine(CanSum(7, new int[] { 5, 3, 4, 7 }));
Console.WriteLine(CanSum(7, new int[] { 2, 4, }));
Console.WriteLine(CanSum(8, new int[] { 2, 3, 5 }));
Console.WriteLine(CanSum(300, new int[] { 7, 14 }));
stopwatch1.Stop();
Console.WriteLine(stopwatch1.ElapsedTicks);

// Memoized recursion
// m = target
// n = array length
// Time: O(n*m) 
// Space: O(m)
public bool CanSum(int target, int[] nums, Dictionary<int, bool> memo)
{
    if (memo.ContainsKey(target)) return memo[target];
    if (target == 0) return true;
    if (target < 0) return false;

    foreach (var num in nums)
    {
        var remainder = target - num;
        var result = CanSum(remainder, nums, memo);
        if (result == true)
        {
            memo[remainder] = true;
            return true;
        }
    }
    memo[target] = false;
    return false;
}

var stopwatch2 = new Stopwatch();
stopwatch2.Start();
Console.WriteLine(CanSum(7, new int[] { 2, 3 }, new Dictionary<int, bool>()));
Console.WriteLine(CanSum(7, new int[] { 5, 3, 4, 7 }, new Dictionary<int, bool>()));
Console.WriteLine(CanSum(7, new int[] { 2, 4, }, new Dictionary<int, bool>()));
Console.WriteLine(CanSum(8, new int[] { 2, 3, 5 }, new Dictionary<int, bool>()));
Console.WriteLine(CanSum(300, new int[] { 7, 14 }, new Dictionary<int, bool>()));
stopwatch2.Stop();
Console.WriteLine(stopwatch2.ElapsedTicks);




