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

        int expected = tDict.Count;
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
            while (left <= right && actual == expected)
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
                    if (sDict[d] == tDict[d])
                        actual--;
                    sDict[d]--;
                }
            }
        }

        return len == int.MaxValue ? string.Empty : s.Substring(start, len);
    }

    // Sliding Window + Dictionary
    // Time: O(s + t)
    // Space: O(s + t)
    public string MinWindow1(string s, string t)
    {
        int n = s.Length;
        var need = new Dictionary<char, int>();
        foreach (var c in t)
            need[c] = need.GetValueOrDefault(c, 0) + 1;
        var window = new Dictionary<char, int>();
        // [left, right)
        int left = 0, right = 0;
        int start = 0, minLen = int.MaxValue;
        while (right < n)
        {
            char c = s[right];
            right++;
            window[c] = window.GetValueOrDefault(c, 0) + 1;

            while (left < right && IsIncluded(window, need))
            {
                if (right - left < minLen)
                {
                    start = left;
                    minLen = right - left;
                }

                char d = s[left];
                window[d]--;
                left++;
            }
        }
        return minLen == int.MaxValue ? string.Empty : s.Substring(start, minLen);
    }

    private bool IsIncluded(Dictionary<char, int> window, Dictionary<char, int> need)
    {
        foreach (var c in need.Keys)
        {
            if (window.GetValueOrDefault(c, 0) < need[c])
                return false;
        }
        return true;
    }
}

/*
Input: s = "ADOBECODEBANC", t = "ABC"
Output: "BANC"
*/
var s = "a";
var t = "aa";
var sln = new Solution();
var result = sln.MinWindow1(s, t);
Console.WriteLine(result);
