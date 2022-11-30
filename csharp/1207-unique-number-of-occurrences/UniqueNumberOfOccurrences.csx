public class Solution
{
    public bool UniqueOccurrences(int[] arr)
    {
        var numCountMap = new Dictionary<int, int>();
        foreach (var num in arr)
            numCountMap[num] = numCountMap.GetValueOrDefault(num, 0) + 1;
        var freqSet = new HashSet<int>();
        foreach (var count in numCountMap.Values)
        {
            if (!freqSet.Add(count))
                return false;
        }
        return true;
    }
}
// Dictionary + HashSet
// Time: O(n)
// Space: O(n)
