public class Solution
{
    // Sort + Two Pointers
    // Time: O(n log n)
    // Space: O(n)
    public int TwoSumLessThanK(int[] nums, int k)
    {
        int n = nums.Length;
        if (n < 2)
            return -1;

        // sort
        Array.Sort(nums);
        // Two Pointers
        int left = 0;
        int right = n - 1;
        int ans = -1;
        while (left < right)
        {
            var sum = nums[left] + nums[right];
            if (sum < k)
            {
                ans = Math.Max(ans, sum);
                left++;
            }
            else
            {
                right--;
            }
        }

        return ans;
    }

    // Sort + Binary Search
    // Time: O(n log n)
    // Space: O(n)
    public int TwoSumLessThanK1(int[] nums, int k)
    {
        int n = nums.Length;
        if (n < 2)
            return -1;

        // sort
        Array.Sort(nums);

        // foreach nums[i], binary search in [i+1, n-1], target == k - nums[i] - 1
        // find the right most index j (nums[j] >= target)
        int ans = -1;
        for (int i = 0; i < n - 1; i++)
        {
            int left = i + 1;
            int right = n - 1;
            int target = k - nums[i] - 1;

            while (left < right)
            {
                // [..., mid-1][mid, ...]
                int mid = left + (right - left + 1) / 2;
                if (nums[mid] > target)
                    right = mid - 1;
                else // nums[mid] <= target
                    left = mid;
            }
            int j = nums[right] > target ? right - 1 : right;
            if (i < j)
                ans = Math.Max(ans, nums[i] + nums[j]);
        }

        return ans;
    }
}
