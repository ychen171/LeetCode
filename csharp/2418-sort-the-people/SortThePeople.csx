public class Solution
{
    // Sort by custom key
    // Time: O(n log n)
    // Space: O(n)
    public string[] SortPeople(string[] names, int[] heights)
    {
        int n = names.Length;
        if (n == 1)
            return names;

        var keys = new int[n];
        for (int i = 0; i < n; i++)
            keys[i] = -heights[i];
        Array.Sort(keys, names);
        return names;
    }
}
