public class Solution
{
    // Sliding Window | Two Pointers
    // Time: O(n)
    // Space: O(n)
    public int[] GetAverages(int[] nums, int k)
    {
        int n = nums.Length;
        var result = new int[n];
        int left = 0, right = 0;
        // [left, right)
        long windowSum = 0;
        int len = 2 * k + 1;
        int center = 0;
        while (right < n)
        {
            var numToAdd = nums[right];
            right++;
            // update window
            windowSum += numToAdd;

            // shrink window
            while (right - left > len)
            {
                var numToRemove = nums[left];
                left++;
                // update window
                windowSum -= numToRemove;
            }

            // update result
            center = left + (right - left) / 2;
            if (right - left < len)
                result[center] = -1;
            else
                result[center] = (int)(windowSum / len);
        }
        while (center < n - 1)
        {
            center++;
            result[center] = -1;
        }

        return result;
    }
}
