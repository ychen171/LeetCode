
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
                var left = 0;
                var right = list.Count - 1;
                while (left < right)
                {
                    var mid = left + (right - left) / 2;
                    if (list[mid] < target)
                        left = mid + 1;
                    else
                        right = mid;
                }

                if (list[left] > target) list[left] = target;
            }
        }

        return list.Count;
    }



    public int BinarySearch(int[] nums, int target)
    {
        var left = 0;
        var right = nums.Length - 1;
        while (left < right)
        {
            var mid = left + (right - left) / 2;
            if (nums[mid] < target)
                left = mid + 1;
            else
                right = mid;
        }
        if (nums[left] == target) return left;
        return -1;
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












