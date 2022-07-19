public class Solution
{
    // Backtracking | TLE
    // Time: O(n!)
    // Space: O(n!)
    public bool CheckInclusion(string s1, string s2)
    {
        List<char> candidates = s1.ToList();
        List<char> perm = new List<char>();
        List<string> result = new List<string>();
        Backtrack(s1.Length, candidates, perm, result);
        foreach (var element in result)
        {
            if (s2.Contains(element))
                return true;
        }

        return false;
    }

    private void Backtrack(int n, List<char> candidates, List<char> perm, List<string> result)
    {
        // base case
        if (perm.Count == n)
        {
            var str = new string(perm.ToArray());
            result.Add(str);
            return;
        }
        // recursive case
        var originalList = new List<char>(candidates);
        foreach (var candidate in originalList)
        {
            perm.Add(candidate);
            candidates.Remove(candidate);
            Backtrack(n, candidates, perm, result);
            perm.Remove(candidate);
            candidates.Add(candidate);
        }
    }

    // Sorting | TLE
    // TODO

    // Dictionary
    // Time: O((n2 - n1) * n1 )
    // Space: O(1)
    public bool CheckInclusion1(string s1, string s2)
    {
        // dict1 stores char -> count
        var dict1 = new Dictionary<char, int>();
        foreach (char c in s1)
        {
            if (!dict1.ContainsKey(c))
                dict1[c] = 0;
            dict1[c]++;
        }
        // iterate through s2 to get every substring
        // foreach subtring, create dict2 char -> count
        // compare dict1 and dict2
        for (int i = 0; i <= s2.Length - s1.Length; i++)
        {
            var dict2 = new Dictionary<char, int>();
            for (int j = i; j < i + s1.Length; j++)
            {
                var c2 = s2[j];
                if (!dict2.ContainsKey(c2))
                    dict2[c2] = 0;
                dict2[c2]++;
            }
            if (Compare(dict1, dict2))
                return true;
        }

        return false;
    }

    private bool Compare(Dictionary<char, int> dict1, Dictionary<char, int> dict2)
    {
        foreach (var kv1 in dict1)
        {
            if (!dict2.ContainsKey(kv1.Key) || dict2[kv1.Key] != kv1.Value)
                return false;
        }

        return true;
    }

    // Array
    // Time: O((n2 - n1) * n1 )
    // Space: O(1)
    public bool CheckInclusion2(string s1, string s2)
    {
        int[] arr1 = new int[26];
        foreach (char c1 in s1)
        {
            arr1[c1 - 'a']++;
        }

        // iterate through every substring in s2
        // use arr2 to store counts for each letter
        // compare arr1 and arr2
        for (int i = 0; i <= s2.Length - s1.Length; i++)
        {
            int[] arr2 = new int[26];
            for (int j = i; j < i + s1.Length; j++)
            {
                char c2 = s2[j];
                arr2[c2 - 'a']++;
            }
            if (Compare(arr1, arr2))
                return true;
        }

        return false;
    }

    private bool Compare(int[] arr1, int[] arr2)
    {
        for (int i = 0; i < arr1.Length; i++)
        {
            if (arr1[i] != arr2[i])
                return false;
        }

        return true;
    }

    // Sliding Window
    // Time: O(n1 + n2 - n1)
    // Space: O(1)
    public bool CheckInclusion3(string s1, string s2)
    {
        if (s1.Length > s2.Length)
            return false;
        // pre populate arrays for the starting position
        int[] arr1 = new int[26];
        int[] arr2 = new int[26];
        for (int i = 0; i < s1.Length; i++)
        {
            arr1[s1[i] - 'a']++;
            arr2[s2[i] - 'a']++;
        }
        // move forward, increase count for the front, decrease count for the end
        // compare arr1 and arr2
        for (int i = 0; i < s2.Length - s1.Length; i++)
        {
            if (Compare(arr1, arr2))
                return true;
            arr2[s2[i] - 'a']--;
            arr2[s2[i + s1.Length] - 'a']++;
        }

        return Compare(arr1, arr2);
    }

    // Sliding Window
    // Time: O(n1 + n2)
    // Space: O(n1 + n2)
    public bool CheckInclusion4(string s1, string s2)
    {
        int n1 = s1.Length; // target
        int n2 = s2.Length; // source
        // edge case
        if (n1 > n2)
            return false;

        var needDict = new Dictionary<char, int>();
        foreach (var c in s1)
            needDict[c] = needDict.GetValueOrDefault(c, 0) + 1;
        var windowDict = new Dictionary<char, int>();
        int expected = needDict.Count;
        int actual = 0;

        int left = 0, right = 0;
        while (right < n2)
        {
            char c = s2[right];
            right++;
            // update data in window
            if (needDict.ContainsKey(c))
            {
                windowDict[c] = windowDict.GetValueOrDefault(c, 0) + 1;
                if (windowDict[c] == needDict[c])
                    actual++;
            }
            
            // check if we need to shrink window
            if (right - left == n1)
            {
                // update answer
                if (actual == expected)
                    return true;

                char d = s2[left];
                left++;
                // update data in window
                if (needDict.ContainsKey(d))
                {
                    if (windowDict[d] == needDict[d])
                        actual--;
                    windowDict[d]--;

                    if (windowDict[d] == 0)
                        windowDict.Remove(d);
                }
            }
        }

        return false;
    }
}

var s = new Solution();
Console.WriteLine(s.CheckInclusion1("adc", "dcda"));
Console.WriteLine(s.CheckInclusion4("trinitrophenylmethylnitramine", "dinitrophenylhydrazinetrinitrophenylmethylnitramine"));
