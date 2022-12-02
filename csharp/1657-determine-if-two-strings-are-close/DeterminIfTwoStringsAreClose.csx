public class Solution
{
    public bool CloseStrings(string word1, string word2)
    {
        int n1 = word1.Length;
        int n2 = word2.Length;
        if (n1 != n2)
            return false;
        // char to count map
        var charToCount1 = new Dictionary<char, int>();
        var charToCount2 = new Dictionary<char, int>();
        foreach (var c1 in word1)
            charToCount1[c1] = charToCount1.GetValueOrDefault(c1, 0) + 1;
        foreach (var c2 in word2)
            charToCount2[c2] = charToCount2.GetValueOrDefault(c2, 0) + 1;
        // check if chars match
        foreach (var c in charToCount1.Keys)
        {
            if (!charToCount2.ContainsKey(c))
                return false;
        }
        // count to freq map
        var countToFreq1 = new Dictionary<int, int>();
        var countToFreq2 = new Dictionary<int, int>();
        foreach (var cnt1 in charToCount1.Values)
            countToFreq1[cnt1] = countToFreq1.GetValueOrDefault(cnt1, 0) + 1;
        foreach (var cnt2 in charToCount2.Values)
            countToFreq2[cnt2] = countToFreq2.GetValueOrDefault(cnt2, 0) + 1;
        // check if freqs match
        foreach (var cnt in countToFreq1.Keys)
        {
            if (!countToFreq2.ContainsKey(cnt) || countToFreq1[cnt] != countToFreq2[cnt])
                return false;
        }
        return true;
    }
}
// Dictionary
// Time: O(n1 + n2)
// Space: O(n1 + n2)
