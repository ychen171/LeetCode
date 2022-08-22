public class Solution
{
    // Two Pointers
    // Time: O(n)
    // Space: O(1)
    public bool IsSubsequence(string s, string t)
    {
        if (s.Length == 0) return true;
        if (t.Length == 0) return false;
        if (s.Length > t.Length) return false;

        int i = 0, j = 0;
        while (i < s.Length && j < t.Length)
        {
            if (s[i] == t[j])
            {
                i++;
                j++;
            }
            else
            {
                j++;
            }
        }

        return i == s.Length;
    }

    // Recursion
    // Time: O(t)
    // Space: O(t)
    public bool IsSubsequence1(string s, string t)
    {
        return Helper(s, t, 0, 0);
    }

    public bool Helper(string s, string t, int i, int j)
    {
        // base case
        if (i == s.Length)
            return true;
        if (j == t.Length)
            return i == s.Length;

        // recursive case
        if (s[i] == t[j])
            return Helper(s, t, i + 1, j + 1);
        else
            return Helper(s, t, i, j + 1);
    }

    // Dictionary + Linear Search
    // Time: O(t + s * t)
    // Space: O(t)
    public bool IsSubsequence2(string s, string t)
    {
        // build index dict
        var charToIndex = new Dictionary<char, List<int>>();
        for (int i = 0; i < t.Length; i++)
        {
            char c = t[i];
            if (!charToIndex.ContainsKey(c))
                charToIndex[c] = new List<int>();
            charToIndex[c].Add(i);
        }

        // iterate through char in s
        int lastIndex = -1;
        foreach (var c in s)
        {
            if (!charToIndex.ContainsKey(c))
                return false;

            var list = charToIndex[c];
            bool found = false;
            foreach (var index in list)
            {
                if (lastIndex < index)
                {
                    lastIndex = index;
                    found = true;
                    break;
                }
            }
            if (!found)
                return false;
        }

        return true;
    }

    // Dictionary + Binary Search
    // Time: O(t + s log t)
    // Space: O(t)
    public bool IsSubsequence3(string s, string t)
    {
        // build index dict
        var charToIndex = new Dictionary<char, List<int>>();
        for (int i = 0; i < t.Length; i++)
        {
            char c = t[i];
            if (!charToIndex.ContainsKey(c))
                charToIndex[c] = new List<int>();
            charToIndex[c].Add(i);
        }

        // iterate through char in s
        int lastIndex = -1;
        foreach (var c in s)
        {
            if (!charToIndex.ContainsKey(c))
                return false;

            var list = charToIndex[c];
            int index = BinarySearchLeftBound(list, lastIndex + 1);
            if (index == -1)
                return false;
            lastIndex = index;
        }

        return true;
    }

    public int BinarySearchLeftBound(List<int> nums, int target)
    {
        int n = nums.Count;
        int left = 0;
        int right = n - 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (nums[mid] < target)
                left = mid + 1;
            else if (nums[mid] > target)
                right = mid - 1;
            else // ==
                return target;
        }
        if (left == n) return -1;
        return nums[left];
    }
}
