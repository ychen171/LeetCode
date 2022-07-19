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
        int m = s.Length;
        int n = t.Length;
        // edge case
        if (m == 0 || n == 0 || m < n)
            return string.Empty;
        var sDict = new Dictionary<char, int>();
        var tDict = new Dictionary<char, int>();
        foreach (char c in t)
            tDict[c] = tDict.GetValueOrDefault(c, 0) + 1;

        int required = tDict.Count;
        int actual = 0;
        int left = 0, right = 0;
        int start = 0, len = int.MaxValue;
        // [left, right)
        while (right < m)
        {
            // c is the char to add to the window
            char c = s[right];
            // increase the window size
            right++;
            // update data in the window
            if (tDict.ContainsKey(c))
            {
                sDict[c] = sDict.GetValueOrDefault(c, 0) + 1;
                if (sDict[c] == tDict[c])
                    actual++;
            }

            // check if we need to shrink the window
            while (left <= right && actual == required)
            {
                // update answer
                if (right - left < len)
                {
                    start = left;
                    len = right - left;
                }

                // d is the char to remove from the window
                char d = s[left];
                // decrease the window size
                left++;
                // update data in the window
                if (tDict.ContainsKey(d))
                {
                    sDict[d]--;
                    if (sDict[d] < tDict[d])
                        actual--;

                    if (sDict[d] == 0)
                        sDict.Remove(d);
                }
            }
        }

        return len == int.MaxValue ? string.Empty : s.Substring(start, len);
    }
}
