
// Brute force recursion
// m = target
// n = array length
// Time: O(n^m)
// Space: O(m)
public List<int> BestSum(int target, int[] nums)
{
    if (target == 0) return new List<int>();
    if (target < 0) return null;

    List<int> shortestResult = null;

    foreach (var num in nums)
    {
        var remainder = target - num;
        var result = BestSum(remainder, nums);
        if (result != null)
        {
            result.Add(num);
            if (shortestResult == null || result.Count < shortestResult.Count)
                shortestResult = result;
        }
    }
    return shortestResult;
}

// Memoized recursion
// m = target
// n = array length
// Time: O(n*m)
// Space: O(m^2)
public List<int> BestSum(int target, int[] nums, Dictionary<int, List<int>> memo)
{
    if (memo.ContainsKey(target)) return memo[target];
    if (target == 0) return new List<int>();
    if (target < 0) return null;

    List<int> shortestResult = null;

    foreach (var num in nums)
    {
        var remainder = target - num;
        var result = BestSum(remainder, nums);
        if (result != null)
        {
            result.Add(num);
            if (shortestResult == null || result.Count < shortestResult.Count)
                shortestResult = result;
        }
    }
    memo[target] = shortestResult;
    return shortestResult;
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


// Iteration | Tabulation
// m = target
// n = array length
// Time: O(m * n * m)
// Space: O(m^2)
public List<int> BestSumTabulation(int target, int[] nums)
{
    var table = new Dictionary<int, List<int>>();
    // initialize table with default value
    for (int i = 0; i <= target; i++)
        table[i] = null;
    // seed the trivial answer into the table
    table[0] = new List<int>();
    // fill further positions with current position
    for (int i = 0; i <= target; i++)
    {
        if (table[i] != null)
        {
            foreach (var num in nums)
            {
                var nextIndex = i + num;
                if (nextIndex <= target)
                {
                    if (table[nextIndex] == null || table[nextIndex].Count > table[i].Count)
                    {
                        table[nextIndex] = new List<int>(table[i]);
                        table[nextIndex].Add(num);
                    }
                }
            }
        }
    }

    return table[target];
}

var stopwatch1 = new Stopwatch();
stopwatch1.Start();
Console.WriteLine(ToString(BestSum(7, new int[] { 5, 3, 4, 7 })));
Console.WriteLine(ToString(BestSum(8, new int[] { 2, 3, 5 })));
Console.WriteLine(ToString(BestSum(8, new int[] { 1, 4, 5 })));
Console.WriteLine(ToString(BestSum(100, new int[] { 5, 25 })));
stopwatch1.Stop();
Console.WriteLine(stopwatch1.ElapsedTicks);

var stopwatch2 = new Stopwatch();
stopwatch2.Start();
Console.WriteLine(ToString(BestSum(7, new int[] { 5, 3, 4, 7 }, new Dictionary<int, List<int>>())));
Console.WriteLine(ToString(BestSum(8, new int[] { 2, 3, 5 }, new Dictionary<int, List<int>>())));
Console.WriteLine(ToString(BestSum(8, new int[] { 1, 4, 5 }, new Dictionary<int, List<int>>())));
Console.WriteLine(ToString(BestSum(100, new int[] { 5, 25 }, new Dictionary<int, List<int>>())));
stopwatch2.Stop();
Console.WriteLine(stopwatch2.ElapsedTicks);


var stopwatch3 = new Stopwatch();
stopwatch3.Start();
Console.WriteLine(ToString(BestSumTabulation(7, new int[] { 5, 3, 4, 7 })));
Console.WriteLine(ToString(BestSumTabulation(8, new int[] { 2, 3, 5 })));
Console.WriteLine(ToString(BestSumTabulation(8, new int[] { 1, 4, 5 })));
Console.WriteLine(ToString(BestSumTabulation(100, new int[] { 5, 25 })));
stopwatch3.Stop();
Console.WriteLine(stopwatch3.ElapsedTicks);


