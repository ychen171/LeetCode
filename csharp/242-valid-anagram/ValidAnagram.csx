public class Solution
{
    // Dictionary
    // Time: O(m + n)
    // Space: O(1)     26 characters
    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length)
            return false;
        var sDict = new Dictionary<char, int>();
        var tDict = new Dictionary<char, int>();
        foreach (char c in s)
        {
            sDict[c] = sDict.GetValueOrDefault(c, 0) + 1;
        }
        foreach (char c in t)
        {
            tDict[c] = tDict.GetValueOrDefault(c, 0) + 1;
        }
        
        // iterate and check every char count
        foreach (char c in sDict.Keys)
        {
            if (!tDict.ContainsKey(c))
                return false;
            if (sDict[c] != tDict[c])
                return false;
        }

        return true;
    }
}
