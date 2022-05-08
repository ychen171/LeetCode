public class Solution
{
    // Dictionary
    // Time: O(N + K)
    // Space: O(N + K)
    public int MinDeletions(string s)
    {
        int n = s.Length;
        if (n == 1)
            return 0;

        // dict[char] = count
        var countDict = new Dictionary<char, int>();
        foreach (char c in s)
        {
            countDict[c] = countDict.GetValueOrDefault(c, 0) + 1;
        }

        // dict[freq] = list of char
        var freqDict = new Dictionary<int, List<char>>();
        foreach (var kv in countDict)
        {
            char c = kv.Key;
            int freq = kv.Value;
            if (!freqDict.ContainsKey(freq))
                freqDict[freq] = new List<char>();
            freqDict[freq].Add(c);
        }

        int ans = 0;
        var freqList = freqDict.Keys.ToList();
        foreach (int freq in freqList)
        {
            var charList = freqDict[freq];
            while (charList.Count > 1) // different chars have same freq
            {
                char targetChar = charList.Last();
                charList.RemoveAt(charList.Count - 1);
                int newFreq = freq;
                // delete target char
                while (newFreq != 0 && freqDict.ContainsKey(newFreq))
                {
                    newFreq--;
                    ans++;
                }
                // after deletion, if the target char still exists, update freqDict
                if (newFreq != 0)
                {
                    freqDict[newFreq] = new List<char>() { targetChar };
                }
            }
        }

        return ans;
    }

    // Array + HashSet
    // Time: O(N + K^2)
    // Space: O(K)
    public int MinDeletions1(string s)
    {
        int[] freqArray = new int[26];
        foreach (var c in s)
        {
            freqArray[c - 'a']++;
        }

        int ans = 0;
        var seenFreqs = new HashSet<int>();
        for (int i = 0; i < 26; i++)
        {
            // keep decreasing the freq until it is unique
            while (freqArray[i] != 0 && seenFreqs.Contains(freqArray[i]))
            {
                freqArray[i]--;
                ans++;
            }
            // add unique freq to the seen set
            seenFreqs.Add(freqArray[i]);
        }

        return ans;
    }
}
