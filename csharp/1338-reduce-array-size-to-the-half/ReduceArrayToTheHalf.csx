public class Solution
{
    // Greedy | Dictionary | Sort
    // Time: O(n log n)
    // Space: O(n)
    public int MinSetSize(int[] arr)
    {
        var countDict = new Dictionary<int, int>();
        int n = arr.Length;
        foreach (var num in arr)
            countDict[num] = countDict.GetValueOrDefault(num, 0) + 1;

        int numCount = 0;
        int ans = 0;
        var kvList = countDict.ToList();
        kvList.Sort((a, b) => b.Value - a.Value);
        foreach (var kv in kvList)
        {
            numCount += kv.Value;
            ans++;
            if (2 * numCount >= n)
                break;
        }

        return ans;
    }
}

var sln = new Solution();
var arr = new int[] { 3, 3, 3, 3, 5, 5, 5, 2, 2, 7 };
var result = sln.MinSetSize(arr);
Console.WriteLine(result);
