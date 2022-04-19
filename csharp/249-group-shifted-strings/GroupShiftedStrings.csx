public class Solution
{
    // Dictionary | normalized key
    // Time: O(n * k)
    // Space: O(n * k)
    public IList<IList<string>> GroupStrings(string[] strings)
    {
        // m = 26
        // "a"     "z"
        //  0      25
        // "az"    "ba"
        // 0,25    1,0 = 1, 26
        //  25            25
        var dict = new Dictionary<string, IList<string>>();
        foreach (var str in strings)
        {
            string key = BuildKey(str);
            if (!dict.ContainsKey(key))
            {
                dict[key] = new List<string>();
            }
            dict[key].Add(str);
        }

        return dict.Values.ToList();
    }

    // Time: O(k)
    // Space: O(k)
    private string BuildKey(string str)
    {
        char[] cs = str.ToCharArray();
        var sb = new StringBuilder();
        for (int i = 1; i < cs.Length; i++)
        {
            char normalized = (char)((cs[i] - cs[i-1] + 26) % 26 + 'a');
            sb.Append(normalized);
        }

        return sb.ToString();
    }
}
