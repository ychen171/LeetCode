public class Solution
{
    // Dictionary + Binary Search
    // Time: O(k * w log s)
    // Space: O(s)
    public int NumMatchingSubseq(string s, string[] words)
    {
        int count = 0;
        foreach (var word in words)
        {
            if (IsSubsequence(s, word))
                count++;
        }

        return count;
    }

    public bool IsSubsequence(string s, string word)
    {
        var charToIndex = new Dictionary<char, List<int>>();
        for (int i = 0; i < s.Length; i++)
        {
            var c = s[i];
            if (!charToIndex.ContainsKey(c))
                charToIndex[c] = new List<int>();
            charToIndex[c].Add(i);
        }

        int lastIndex = -1;
        foreach (var c in word)
        {
            if (!charToIndex.ContainsKey(c))
                return false;
            var indexList = charToIndex[c];
            var index = BinarySearchLeftBound(indexList, lastIndex + 1);
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
            else // nums[mid] == target
                return target;
        }
        if (left == n) return -1;
        return nums[left];
    }
}
