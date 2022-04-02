public class Solution
{
    // Brute force
    // Time: O(S) in worst
    // S is the sum of all chars in all strs
    // Space: O(1)
    public string LongestCommonPrefix(string[] strs)
    {
        var commonPrefix = new StringBuilder();
        int len = int.MaxValue;
        foreach (var str in strs)
        {
            len = Math.Min(len, str.Length);
        }

        for (int i = 0; i < len; i++)
        {
            char c = strs[0][i];
            if (!HasCommonChar(strs, i, c))
                break;
            commonPrefix.Append(c);
        }

        return commonPrefix.ToString();
    }

    private bool HasCommonChar(string[] strs, int index, char target)
    {
        for (int i = 0; i < strs.Length; i++)
        {
            if (strs[i][index] != target)
                return false;
        }

        return true;
    }

    // Binary Search
    // Time: O(n log n)
    // n is the min len of str in all strs
    // Space: O(n)
    public string LongestCommonPrefix1(string[] strs)
    {
        // ans = [0, len], where len is the min len of str in all strs
        // binary search on [0, len], find the right most candidate
        int len = int.MaxValue;
        foreach (var str in strs)
        {
            len = Math.Min(len, str.Length);
        }
        int left = 0;
        int right = len;
        string result = string.Empty;
        while (left < right)
        {
            int mid = left + (right - left + 1) / 2;
            string target = strs[0].Substring(0, mid);
            if (HasCommonPrefix(strs, mid, target))
            {
                left = mid;
                result = target;
            }
            else
                right = mid - 1;
        }

        return result;
    }

    private bool HasCommonPrefix(string[] strs, int len, string target)
    {
        for (int i = 1; i < strs.Length; i++)
        {
            if (target != strs[i].Substring(0, len))
                return false;
        }

        return true;
    }
}
