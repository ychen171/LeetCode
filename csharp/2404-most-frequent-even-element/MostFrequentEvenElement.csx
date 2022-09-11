public class Solution
{
    // Dictionary
    // Time: O(n)
    // Space: O(n)
    public int MostFrequentEven(int[] nums)
    {
        var countDict = new Dictionary<int, int>();
        foreach (var num in nums)
        {
            if (num % 2 != 0)
                continue;
            countDict[num] = countDict.GetValueOrDefault(num, 0) + 1;
        }

        if (countDict.Count == 0)
            return -1;

        var maxCount = countDict.Values.Max();
        var list = new List<int>();
        foreach (var kv in countDict)
        {
            var num = kv.Key;
            var count = kv.Value;
            if (count == maxCount)
                list.Add(num);
        }

        return list.Min();
    }
}
