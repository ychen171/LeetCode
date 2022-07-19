public class Solution
{
    // Sliding Window | Two Pointers + Dictionary
    // Time: O(S + P)
    // Space: O(1)
    public IList<int> FindAnagrams(string s, string p)
    {
        var result = new List<int>();
        if (s.Length < p.Length)
            return result;

        // create pDict[char] = count
        var pDict = new Dictionary<char, int>();
        foreach (var c in p)
        {
            pDict[c] = pDict.GetValueOrDefault(c, 0) + 1;
        }
        // iterate through s, keep the window size == pLen
        // [left, right)
        int sLen = s.Length;
        int pLen = p.Length;
        int left = 0;
        int right = 0;
        var sDict = new Dictionary<char, int>();
        while (right < pLen)
        {
            var cToAdd = s[right];
            sDict[cToAdd] = sDict.GetValueOrDefault(cToAdd, 0) + 1;
            right++;
        }
        if (Match(sDict, pDict))
        {
            result.Add(left);
        }

        while (right < sLen)
        {
            // left and right move forward by 1
            var cToRemove = s[left];
            sDict[cToRemove]--;
            if (sDict[cToRemove] == 0)
                sDict.Remove(cToRemove);
            left++;

            var cToAdd = s[right];
            sDict[cToAdd] = sDict.GetValueOrDefault(cToAdd, 0) + 1;
            right++;

            if (Match(sDict, pDict))
                result.Add(left);
        }

        return result;
    }

    private bool Match(Dictionary<char, int> dict1, Dictionary<char, int> dict2)
    {
        foreach (var key in dict1.Keys)
        {
            if (!dict2.ContainsKey(key))
                return false;

            if (dict2[key] != dict1[key])
                return false;
        }

        return true;
    }

    // Sliding Window | Standard Template
    // Time: O(m + n)
    public IList<int> FindAnagrams1(string s, string p) 
    {
        int m = s.Length; // source
        int n = p.Length; // target
        var result = new List<int>();
        // edge case
        if (m < n)
            return result;
        
        var needDict = new Dictionary<char, int>();
        foreach (var c in p)
            needDict[c] = needDict.GetValueOrDefault(c, 0) + 1;
        var windowDict = new Dictionary<char, int>();
        int expected = needDict.Count;
        int actual = 0;
        
        int left = 0, right = 0;
        while (right < m)
        {
            char c = s[right];
            right++;
            // update data in window [left, right)
            if (needDict.ContainsKey(c))
            {
                windowDict[c] = windowDict.GetValueOrDefault(c, 0) + 1;
                if (windowDict[c] == needDict[c])
                    actual++;
            }
            
            // check if we need to shrink window
            if (right - left == n)
            {
                // update result
                if (actual == expected)
                    result.Add(left);
                    
                char d = s[left];
                left++;
                // update data in window [left, right)
                if (needDict.ContainsKey(d))
                {
                    if (windowDict[d] == needDict[d])
                        actual--;
                    windowDict[d]--;
                }
            }
        }
        
        return result;
    }
}
