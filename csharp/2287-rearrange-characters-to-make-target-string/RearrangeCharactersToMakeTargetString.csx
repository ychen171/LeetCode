public class Solution
{
    // Dictionary | Array
    // Time: O(s + t)
    // Space: O(s + t)
    public int RearrangeCharacters(string s, string target)
    {
        // count target letter
        var tDict = new Dictionary<char, int>();
        foreach (var c in target)
        {
            tDict[c] = tDict.GetValueOrDefault(c, 0) + 1;
        }

        // count s letter
        var sDict = new Dictionary<char, int>();
        foreach (var c in s)
        {
            sDict[c] = sDict.GetValueOrDefault(c, 0) + 1;
        }

        // greedy, find the number of copy we can form
        int ans = 0;
        while (sDict.Count >= tDict.Count)
        {
            // source doesn't contain target
            if (!Contains(sDict, tDict))
                break;

            // source contains target
            // form one copy and update source
            foreach (var kv in tDict)
            {
                char c = kv.Key;
                int count = kv.Value;
                sDict[c] -= count;
                if (sDict[c] == 0)
                    sDict.Remove(c);
            }
            ans++;
        }

        return ans;
    }

    public bool Contains(Dictionary<char, int> source, Dictionary<char, int> target)
    {
        foreach (var kv in target)
        {
            char c = kv.Key;
            int count = kv.Value;
            if (!source.ContainsKey(c) || source[c] < count)
                return false;
        }

        return true;
    }
}
