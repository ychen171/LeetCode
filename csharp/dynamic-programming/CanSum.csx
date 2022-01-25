

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



// Iteration | Tabulation
// m = target
// n = array length
// Time: O(m*n)
// Space: O(m)
public bool CanSumTabulation(int target, int[] nums)
{
    var table = new List<bool>();
    // initialize table with default value false
    for (int i = 0; i <= target; i++)
        table.Add(false);
    // seed the trivial answer into the table
    table[0] = true;
    // fill further positions with current position
    for (int i = 0; i <= target; i++)
    {
        if (table[i] == true)
        {
            foreach (var num in nums)
            {
                var nextIndex = i + num;
                if (nextIndex <= target)
                    table[nextIndex] = true;
            }
        }
    }

    return table[target];
}
var stopwatch3 = new Stopwatch();
stopwatch3.Start();
Console.WriteLine(CanSumTabulation(7, new int[] { 2, 3 }));
Console.WriteLine(CanSumTabulation(7, new int[] { 5, 3, 4, 7 }));
Console.WriteLine(CanSumTabulation(7, new int[] { 2, 4, }));
Console.WriteLine(CanSumTabulation(8, new int[] { 2, 3, 5 }));
Console.WriteLine(CanSumTabulation(300, new int[] { 7, 14 }));
stopwatch3.Stop();
Console.WriteLine(stopwatch3.ElapsedTicks);



