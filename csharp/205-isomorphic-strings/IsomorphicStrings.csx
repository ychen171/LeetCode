public class Solution
{
    // Dictionary
    // Time: O(n)
    // Space: O(n)
    public bool IsIsomorphic(string s, string t)
    {
        var stDict = new Dictionary<char, char>();
        var tsDict = new Dictionary<char, char>();
        for (int i = 0; i < s.Length; i++)
        {
            char sc = s[i];
            char tc = t[i];
            if (stDict.ContainsKey(sc) && stDict[sc] != tc)
            {
                return false;
            }
            if (tsDict.ContainsKey(tc) && tsDict[tc] != sc)
            {
                return false;
            }

            stDict[sc] = tc;
            tsDict[tc] = sc;
        }

        return true;
    }
}
