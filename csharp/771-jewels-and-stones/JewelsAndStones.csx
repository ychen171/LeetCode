public class Solution
{
    // Hash Table | Dictionary
    // Time: O(m + n)
    // Space: O(m)
    public int NumJewelsInStones(string jewels, string stones)
    {
        // dict[type] = count
        var typeCountDict = new Dictionary<char, int>();
        foreach (char jewel in jewels)
            typeCountDict[jewel] = 0;
        
        foreach (char item in stones)
        {
            if (typeCountDict.ContainsKey(item))
                typeCountDict[item]++;
        }

        return typeCountDict.Values.Sum();
    }
}
