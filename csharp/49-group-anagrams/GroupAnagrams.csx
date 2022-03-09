public class Solution
{
    // Dictionary | Categorize by sorted strings
    // Time: O(N * K * log K) 
    // N is the length of strs
    // K is the maximum length of a string in strs
    // Space: O(N * K)
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        var strDict = new Dictionary<string, List<string>>();
        foreach (var str in strs)
        {
            string sortedStr = new string(str.OrderBy(c => c).ToArray());
            if (!strDict.ContainsKey(sortedStr))
                strDict[sortedStr] = new List<string>();
            strDict[sortedStr].Add(str);
        }

        IList<IList<string>> result = new List<IList<string>>();
        foreach (var kv in strDict)
        {
            result.Add(kv.Value);
        }

        return result;
    }

    // Dictionary | Categorize by Letter Count
    // Time: O(N * K)
    // N is the length of strs
    // K is the maximum length of a string in strs
    // Space: O(N * K)
    public IList<IList<string>> GroupAnagrams1(string[] strs)
    {
        var strDict = new Dictionary<string, List<string>>();
        foreach (var str in strs)
        {
            int[] count = new int[26];
            foreach (var c in str)
                count[c-'a']++;
            var sb = new StringBuilder();
            for (int i=0; i<26; i++)
                sb.Append('#').Append(count[i]);
            var key = sb.ToString();
            if (!strDict.ContainsKey(key))
                strDict[key] = new List<string>();
            strDict[key].Add(str);
        }

        IList<IList<string>> result = new List<IList<string>>();
        foreach (var list in strDict.Values)
            result.Add(list);
        
        return result;
    }
}
