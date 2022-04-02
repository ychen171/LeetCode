public class Solution
{
    // Binary Search
    // Time: O(n log n)
    // Space: O(n)
    public int MinSubArrayLen(int target, int[] nums)
    {
        // n = nums.Length
        // answer len = [0, n]
        // binary serach on len
        // given mid == len, check if nums contains subarray whose sum == target
        // find the left most candidate
        int n = nums.Length;
        int left = 0;
        int right = n;

        while (left < right)
        {
            int mid = left + (right - left) / 2;
            if (HasSubArray(nums, mid, target))
            {
                right = mid;
            }
            else
            {
                left = mid + 1;
            }
        }
        if (left == n && nums.Sum() < target)
            return 0;
        return left;
    }

    private bool HasSubArray(int[] nums, int len, int target)
    {
        int sum = 0;
        for (int i = 0; i < len; i++)
            sum += nums[i];
        if (sum >= target) return true;
        for (int i = 1; i <= nums.Length - len; i++)
        {
            sum = sum - nums[i - 1] + nums[i - 1 + len];
            if (sum >= target)
                return true;
        }

        return false;
    }

    // Two Pointers
    // Time: O(n)
    // Space: O(1)
    public int MinSubArrayLen1(int target, int[] nums)
    {
        int n = nums.Length;
        int left = 0;
        int right = 0;
        int sum = 0;
        int minLen = int.MaxValue;

        for (right = 0; right < n; right++)
        {
            sum += nums[right];
            while (sum >= target)
            {
                minLen = Math.Min(minLen, right - left + 1);
                sum -= nums[left];
                left++;
            }
        }

        return minLen == int.MaxValue ? 0 : minLen;
    }
}
