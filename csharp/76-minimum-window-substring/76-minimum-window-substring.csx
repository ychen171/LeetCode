public class Solution
{
    // ADOBECODEBANC            ABC
    // ADOBEC                   i=0, j=5, len=6
    // DOBECODEBA               i=1, j=10, len=10

    // Sliding Window + Dictionary
    // Time: O(s + t)
    // Space: O(s + t)
    public string MinWindow(string s, string t)
    {
        var tDict = new Dictionary<char, int>();
        foreach (char c in t)
        {
            tDict[c] = tDict.GetValueOrDefault(c, 0) + 1;
        }

        int i = 0;
        int j = 0;
        int[] ans = new int[] { 0, s.Length - 1, int.MaxValue };
        var sDict = new Dictionary<char, int>();
        int required = tDict.Count;
        int actual = 0;
        // increase window size
        while (j < s.Length)
        {
            char c = s[j];
            if (tDict.ContainsKey(c))
            {
                sDict[c] = sDict.GetValueOrDefault(c, 0) + 1;

                if (sDict[c] == tDict[c])
                    actual++;

                // descrease window size
                while (i <= j && actual == required)
                {
                    c = s[i];
                    if (j - i + 1 < ans[2])
                    {
                        ans[0] = i;
                        ans[1] = j;
                        ans[2] = j - i + 1;
                    }
                    if (tDict.ContainsKey(c))
                    {
                        sDict[c]--;
                        if (sDict[c] < tDict[c])
                            actual--;
                    }
                    i++;
                }
            }
            j++;
        }

        return ans[2] == int.MaxValue ? string.Empty : s.Substring(ans[0], ans[2]);
    }
}
