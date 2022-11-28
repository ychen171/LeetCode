public class Solution
{
    public int LongestOnes(int[] nums, int k)
    {
        int n = nums.Length;
        int left = 0, right = 0;
        // [left, right)
        int result = 0;
        int windowOneCount = 0;
        while (right < n)
        {
            // expand window
            int c = nums[right];
            right++;
            if (c == 1)
                windowOneCount++;
            // shrink window
            while (right - left - windowOneCount > k)
            {
                int d = nums[left];
                left++;
                if (d == 1)
                    windowOneCount--;
            }
            // update result
            result = Math.Max(result, right - left);
        }
        return result;
    }
}
// Sliding Window
// Time: O(n)
// Space: O(1)
