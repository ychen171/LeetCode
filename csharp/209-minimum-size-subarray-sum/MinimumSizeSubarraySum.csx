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

    // Prefix Sum + Binary Search
    // Time: O(n + n log n) => O(n log n)
    // Space: O(n)
    public int MinSubArrayLen2(int target, int[] nums)
    {
        /*
            preSum[j+1] - preSum[i] : [i, j]
            preSum[j+1] - preSum[i] >= target
            preSum[j+1] >= target + preSum[i]
            preSum[j+1] - target >= preSum[i]
            
                2   3   1   2   4   3
            0   2   5   6   8   12  15
            
        */
        int n = nums.Length;
        var preSum = new int[n + 1];
        for (int i = 1; i < n + 1; i++)
            preSum[i] = preSum[i - 1] + nums[i - 1];

        int ans = int.MaxValue;
        for (int j = 0; j < n; j++)
        {
            int need = preSum[j + 1] - target;
            int i = BinarySearchRB(preSum, need);
            if (i == -1)
                continue;
            ans = Math.Min(ans, j - i + 1);
        }

        return ans == int.MaxValue ? 0 : ans;
    }

    public int BinarySearchRB(int[] nums, int target)
    {
        int n = nums.Length;
        int left = 0, right = n - 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (nums[mid] < target)
                left = mid + 1;
            else if (nums[mid] > target)
                right = mid - 1;
            else // ==
                left = mid + 1;
        }
        if (right == -1) return -1;
        return right;
    }

    // Sliding Window
    // Time: O(n)
    // Space: O(n)
    public int MinSubArrayLen3(int target, int[] nums)
    {
        int n = nums.Length;
        int left = 0, right = 0;
        // [left, right)
        int windowSum = 0;
        int ans = int.MaxValue;
        while (right < n)
        {
            // expand window
            windowSum += nums[right];
            right++;
            while (windowSum >= target && left < right)
            {
                // update ans
                ans = Math.Min(ans, right - left);
                // shrink window
                windowSum -= nums[left];
                left++;
            }
        }

        return ans == int.MaxValue ? 0 : ans;
    }
}
