

// Brute force recursion
// m = target
// n = array length
// Time: O(n^m) 
// Space: O(m)
public List<int> HowSum(int target, int[] nums)
{
    if (target == 0) return new List<int>();
    if (target < 0) return null;

    foreach (var num in nums)
    {
        var remainder = target - num;
        var result = HowSum(remainder, nums);
        if (result != null)
        {
            result.Add(num);
            return result;
        }
    }
    return null;
}

// Memoized recursion
// m = target
// n = array length
// Time: O(n*m)
// Space: O(m^2)
public List<int> HowSum(int target, int[] nums, Dictionary<int, List<int>> memo)
{
    if (memo.ContainsKey(target)) return memo[target];
    if (target == 0) return new List<int>();
    if (target < 0) return null;
    
    foreach (var num in nums)
    {
        var remainder = target - num;
        var result = HowSum(remainder, nums, memo);
        if (result != null)
        {
            result.Add(num);
            memo[remainder] = result;
            return result;
        }
    }
    memo[target] = null;
    return null;
}

public string ToString(List<int> list)
{
    if (list == null) return "null";
    var sb = new StringBuilder();
    sb.Append("[");
    foreach (var item in list)
    {
        sb.Append(item + ", ");
    }
    sb.Append("]");
    return sb.ToString();
}

var stopwatch1 = new Stopwatch();
stopwatch1.Start();
Console.WriteLine(ToString(HowSum(7, new int[] { 2, 3 })));
Console.WriteLine(ToString(HowSum(7, new int[] { 5, 3, 4, 7 })));
Console.WriteLine(ToString(HowSum(7, new int[] { 2, 4, })));
Console.WriteLine(ToString(HowSum(8, new int[] { 2, 3, 5 })));
Console.WriteLine(ToString(HowSum(300, new int[] { 7, 14 })));
stopwatch1.Stop();
Console.WriteLine(stopwatch1.ElapsedTicks);


var stopwatch2 = new Stopwatch();
stopwatch2.Start();
Console.WriteLine(ToString(HowSum(7, new int[] { 2, 3 }, new Dictionary<int, List<int>>())));
Console.WriteLine(ToString(HowSum(7, new int[] { 5, 3, 4, 7 }, new Dictionary<int, List<int>>())));
Console.WriteLine(ToString(HowSum(7, new int[] { 2, 4, }, new Dictionary<int, List<int>>())));
Console.WriteLine(ToString(HowSum(8, new int[] { 2, 3, 5 }, new Dictionary<int, List<int>>())));
Console.WriteLine(ToString(HowSum(300, new int[] { 7, 14 }, new Dictionary<int, List<int>>())));
stopwatch2.Stop();
Console.WriteLine(stopwatch2.ElapsedTicks);


