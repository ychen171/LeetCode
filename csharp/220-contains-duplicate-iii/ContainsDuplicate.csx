using System.Collections.Generic;
public class Solution
{
    // Linear Search
    // Time: O(N^2)
    // Space: O(1)
    public bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t)
    {
        for (int i = 0; i < nums.Length - 1; i++)
        {
            for (int j = i + 1; j < i + 1 + k && j < nums.Length; j++)
            {
                long diff = (long)nums[i] - nums[j];
                if (diff <= t && diff >= -t)
                    return true;
            }
        }
        return false;
    }

    // Binary Search Tree
    // Time: O(n*log(Min(n, k)))
    // Space: O(Min(n, k))
    public bool ContainsNearbyAlmostDuplicate1(int[] nums, int k, int t)
    {
        SortedSet<long> set = new SortedSet<long>();
        for (int i = 0; i < nums.Length; i++)
        {
            // find the successor of current element
            long? successor = set.Count == 0 ? null : set.Min(x => x >= nums[i] ? x : null);
            if (successor != null && successor <= nums[i] + (long)t) return true;
            // find the predecessor of current element
            long? predecessor = set.Count == 0 ? null : set.Max(x => x <= nums[i] ? x : null);
            if (predecessor != null && predecessor >= nums[i] - (long)t) return true;

            set.Add(nums[i]);
            if (set.Count > k)
                set.Remove(nums[i - k]);
        }
        return false;
    }

    // Buckets + Dictionary
    // Time: O(n)
    // Space: O(Min(n, k))
    public bool ContainsNearbyAlmostDuplicate2(int[] nums, int k, int t)
    {
        if (t < 0) return false;
        Dictionary<long, long> dict = new Dictionary<long, long>();
        long w = (long)t + 1;
        for (int i = 0; i < nums.Length; i++)
        {
            long m = GetId(nums[i], w);
            // check if bucket m is empty, each bucket may contain at most one element
            if (dict.ContainsKey(m))
                return true;
            // check the neighbor buckets for almost duplicate
            if (dict.ContainsKey(m - 1) && Math.Abs(nums[i] - dict[m - 1]) < w)
                return true;
            if (dict.ContainsKey(m + 1) && Math.Abs(nums[i] - dict[m + 1]) < w)
                return true;
            // now bucket m is empty and no almost duplicate in neighbor buckets
            dict[m] = (long)nums[i];
            if (i >= k) dict.Remove(GetId(nums[i - k], w));
        }
        return false;
    }
    // Get the ID of the bucket from element value x and bucket width w
    // In C#, -3 / 5 = 0, but we need -3 / 5 = -1
    private long GetId(long x, long w)
    {
        return x < 0 ? (x + 1) / w - 1 : x / w;
    }

    // Sliding Window + SortedList
    // Time: O(n log Min(n, k))
    // Space: O(Min(n, k))
    public bool ContainsNearbyAlmostDuplicate3(int[] nums, int indexDiff, int valueDiff)
    {
        int n = nums.Length;
        var window = new SortedList<int, int>();
        // [left, right)
        int left = 0, right = 0;
        while (right < n)
        {
            // expand window
            var c = nums[right];
            window[c] = window.GetValueOrDefault(c, 0) + 1;
            right++;
            // shrink window
            while (right - 1 - left > indexDiff)
            {
                var d = nums[left];
                window[d]--;
                if (window[d] == 0)
                    window.Remove(d);
                left++;
            }
            // update result
            if (window.Count != 0)
            {
                // valueDiff == 0
                if (window.ContainsKey(c) && window[c] > 1)
                    return true;
                int index = window.IndexOfKey(c);
                // find next smaller num
                if (index > 0 && c - window.Keys[index - 1] <= valueDiff)
                    return true;
                // find next greater num
                if (index < window.Count - 1 && window.Keys[index + 1] - c <= valueDiff)
                    return true;
            }
        }
        return false;
    }
}


var s = new Solution();
// var result = s.ContainsNearbyAlmostDuplicate1(new int[] { -2147483648, -2147483647 }, 3, 3);
// result = s.ContainsNearbyAlmostDuplicate2(new int[] { -1, -3 }, 3, 4);
// Console.WriteLine(result);
Console.WriteLine(s.ContainsNearbyAlmostDuplicate3(new int[] { 1, 2, 3, 1 }, 3, 0));
Console.WriteLine(s.ContainsNearbyAlmostDuplicate3(new int[] { 1, 5, 9, 1, 5, 9 }, 2, 3));


