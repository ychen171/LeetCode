public class Solution
{
    // Brute force | two pointers
    // Time: O(n^2)
    // Space: O(k)
    public int LengthOfLongestSubstringKDistinct(string s, int k)
    {
        if (k == 0) return 0;
        int maxLen = 0;
        for (int i = 0; i < s.Length; i++)
        {
            var seen = new HashSet<char>();
            for (int j = i; j < s.Length; j++)
            {
                seen.Add(s[j]);
                if (seen.Count > k)
                    break;
                maxLen = j - i + 1;
            }
        }

        return maxLen;
    }

    // Sliding Window + Hashmap
    // Time: O(n * k)
    // Space: O(k)
    public int LengthOfLongestSubstringKDistinct1(string s, int k)
    {
        if (k == 0) return 0;
        int left = 0;
        int right = 0;
        // Dictionary stores <character, rightMostIndex>
        var rightMostPosition = new Dictionary<char, int>();
        int maxLen = 1;
        // move sliding window along with the string
        // keep at most k distinct characters in the window
        // update max substring length in each iteration
        for (right = 0; right < s.Length; right++)
        {
            rightMostPosition[s[right]] = right;
            if (rightMostPosition.Count > k)
            {
                int lowestIndex = rightMostPosition.Values.Min();
                rightMostPosition.Remove(s[lowestIndex]);
                left = lowestIndex + 1;
            }
            maxLen = Math.Max(maxLen, right - left + 1);
        }

        return maxLen;
    }

    // Sliding Window + HashMap
    // Time: O(n * k)
    // Space: O(k)
    public int LengthOfLongestSubstringKDistinct2(string s, int k)
    {
        if (k == 0) return 0;
        int left = 0, right = 0;
        var countDict = new Dictionary<char, int>();
        int maxLen = 1;
        for (right = 0; right < s.Length; right++)
        {
            if (!countDict.ContainsKey(s[right]))
                countDict[s[right]] = 0;
            countDict[s[right]] += 1;
            while (countDict.Count > k)
            {
                if (countDict.ContainsKey(s[left]))
                {
                    countDict[s[left]] -= 1;
                    if (countDict[s[left]] == 0)
                        countDict.Remove(s[left]);
                }
                left++;
            }

            maxLen = Math.Max(maxLen, right - left + 1);
        }

        return maxLen;
    }
}

var s = new Solution();
Console.WriteLine(s.LengthOfLongestSubstringKDistinct2("eceba", 2));
