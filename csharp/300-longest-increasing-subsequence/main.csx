
public class Solution
{
    // Dynamic Programming
    // Time: O(n^2)
    // Space: O(n)
    public int LengthOfLIS(int[] nums)
    {
        var dp = new int[nums.Length];
        Array.Fill(dp, 1);

        for (int i = 1; i < nums.Length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (nums[i] > nums[j])
                    dp[i] = Math.Max(dp[i], dp[j] + 1);
            }
        }

        return dp.Max();
    }

    // Intelligently build a subsequence
    // Time: O(n^2)
    // Space: O(n)
    public int LengthOfLIS2(int[] nums)
    {
        var list = new List<int>() { nums[0] };
        for (int i = 1; i < nums.Length; i++)
        {
            var target = nums[i];
            if (target > list.Last())
                list.Add(target);
            else
            {
                for (int j = 0; j < list.Count; j++)
                {
                    if (list[j] > target)
                    {
                        list[j] = target;
                        break;
                    }
                }
            }
        }

        return list.Count;
    }

    // Improve with Binary Search
    // Time: O(n log(n))
    // Space: O(n)
    public int LengthOfLIS3(int[] nums)
    {
        // create a new list
        var list = new List<int>() { nums[0] };
        for (int i = 1; i < nums.Length; i++)
        {
            var target = nums[i];
            // compare target with the last/greatest value in the new list
            // if target is greater, add it to the new list
            // else binary search to find the smallest value that is greater than target
            // replace it with target
            if (target > list.Last())
                list.Add(target);
            else // Binary Search
            {
                int index = BinarySearchLeftBound(list, target);
                if (index != -1)
                    list[index] = target;
            }
        }

        return list.Count;
    }
    
    public int BinarySearchLeftBound(List<int> nums, int target)
    {
        int left = 0;
        int right = nums.Count - 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (nums[mid] < target)
                left = mid + 1;
            else if (nums[mid] > target)
                right = mid - 1;
            else // ==
                right = mid - 1;
        }
        if (left == nums.Count) return -1;
        return left;
    }

    // Backtracking
    // Time: Slow
    // Space: O(n)
    public int LengthOfLIS4(int[] nums)
    {
        var result = new HashSet<int>();
        Backtrack(nums, new List<int>(), 0, result);
        return result.Max();
    }

    private void Backtrack(int[] nums, List<int> comb, int nextStart, HashSet<int> result)
    {
        // base case
        if (nextStart == nums.Length)
        {
            result.Add(comb.Count);
            return;
        }
        // recursive case
        for (int i = nextStart; i < nums.Length; i++)
        {
            if (comb.Count == 0 || nums[i] > comb.Last())
            {
                comb.Add(nums[i]);
                Backtrack(nums, comb, i + 1, result);
                comb.RemoveAt(comb.Count - 1);
            }
            else
            {
                Backtrack(nums, comb, i + 1, result);
            }
        }
    }
}



var s = new Solution();
Console.WriteLine(s.LengthOfLIS(new int[] { 10, 9, 2, 5, 3, 7, 101, 18 }));
Console.WriteLine(s.LengthOfLIS(new int[] { 0, 1, 0, 3, 2, 3 }));
Console.WriteLine(s.LengthOfLIS(new int[] { 7, 7, 7, 7, 7, 7, 7 }));
Console.WriteLine();

Console.WriteLine(s.LengthOfLIS2(new int[] { 10, 9, 2, 5, 3, 7, 101, 18 }));
Console.WriteLine(s.LengthOfLIS2(new int[] { 0, 1, 0, 3, 2, 3 }));
Console.WriteLine(s.LengthOfLIS2(new int[] { 7, 7, 7, 7, 7, 7, 7 }));
Console.WriteLine();

Console.WriteLine(s.LengthOfLIS3(new int[] { 10, 9, 2, 5, 3, 7, 101, 18 }));
Console.WriteLine(s.LengthOfLIS3(new int[] { 0, 1, 0, 3, 2, 3 }));
Console.WriteLine(s.LengthOfLIS3(new int[] { 7, 7, 7, 7, 7, 7, 7 }));
Console.WriteLine();












