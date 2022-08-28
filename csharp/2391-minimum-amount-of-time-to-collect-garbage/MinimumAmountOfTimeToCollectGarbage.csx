public class Solution
{
    // Dictionary
    // Time: O(n)
    // Space: O(n)
    public int GarbageCollection(string[] garbage, int[] travel)
    {
        int n = garbage.Length; // number of houses
        // for each garbage type, find the index of last house
        var typeToLastIndex = new Dictionary<char, int>();
        var typeToCount = new Dictionary<char, int>();
        for (int i = 0; i < n; i++)
        {
            var bin = garbage[i];
            foreach (var c in bin)
            {
                typeToLastIndex[c] = i;
                typeToCount[c] = typeToCount.GetValueOrDefault(c, 0) + 1;
            }
        }
        int ans = 0;
        foreach (var key in typeToLastIndex.Keys)
        {
            var lastIndex = typeToLastIndex[key];
            var count = typeToCount[key];
            for (int i = 0; i < lastIndex; i++)
                ans += travel[i];
            ans += count;
        }

        return ans;
    }
}
