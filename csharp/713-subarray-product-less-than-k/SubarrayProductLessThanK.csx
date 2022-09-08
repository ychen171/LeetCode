public class Solution
{
    // Sliding Window | Two Pointers
    // Time: O(n)
    // Space: O(n)
    public int NumSubarrayProductLessThanK(int[] nums, int k)
    {
        int n = nums.Length;
        int window = 1;
        int ans = 0;
        int left = 0, right = 0;
        // [left, right)
        while (right < n)
        {
            var numToAdd = nums[right];
            right++;
            // update window
            window *= numToAdd;

            while (left < right && window >= k)
            {
                var numToRemove = nums[left];
                left++;
                // update window
                window /= numToRemove;
            }

            ans += right - left;
        }

        return ans;
    }
}
